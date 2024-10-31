using DiemDanhChoGV.DAO;
using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
//using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace DiemDanhChoGV
{
    public partial class formThemSinhVien : Form
    {
        LopHoc lopHoc;
        private List<SinhVien> danhSachSinhVien;

        public formThemSinhVien(LopHoc lopHoc)
        {
            this.lopHoc = lopHoc;
            this.danhSachSinhVien = new List<SinhVien>();
            InitializeComponent();
        }

        #region Methods
        void LoadDtgvDanhSachSinhVien()
        {
            if (danhSachSinhVien.Count > 0)
            {
                // Đặt lại DataSource để cập nhật
                dtgvDanhSachSinhVien.DataSource = null;

                // Tạo một cột số thứ tự nếu chưa có
                if (!dtgvDanhSachSinhVien.Columns.Contains("SoThuTu"))
                {
                    DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "SoThuTu",
                        HeaderText = "STT",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };
                    dtgvDanhSachSinhVien.Columns.Insert(0, sttColumn);
                }

                // Đặt DataSource và cập nhật số thứ tự
                dtgvDanhSachSinhVien.DataSource = danhSachSinhVien;
                dtgvDanhSachSinhVien.Columns["SinhVienID"].Visible = false;
                dtgvDanhSachSinhVien.Columns["MaLopHoc"].Visible = false;
                dtgvDanhSachSinhVien.Columns["MaSinhVien"].HeaderText = "Mã số";
                dtgvDanhSachSinhVien.Columns["HoTen"].HeaderText = "Họ tên";
                dtgvDanhSachSinhVien.Columns["MaSinhVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgvDanhSachSinhVien.Columns["MaSinhVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Cập nhật số thứ tự
                for (int i = 0; i < dtgvDanhSachSinhVien.Rows.Count; i++)
                {
                    dtgvDanhSachSinhVien.Rows[i].Cells["SoThuTu"].Value = i + 1;
                }
            }
            else
            {
                dtgvDanhSachSinhVien.Columns.Clear();
                dtgvDanhSachSinhVien.DataSource = null;
            }
        }

        void ThemMotSinhVienTuTextBox()
        {
            string maSinhVien = txtMaSinhVien.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            // Kiểm tra thông tin đầu vào
            if (string.IsNullOrEmpty(maSinhVien) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã sinh viên và họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng SinhVien
            SinhVien sinhVien = new SinhVien
            {
                SinhVienID = -1,
                MaSinhVien = maSinhVien,
                HoTen = hoTen,
                MaLopHoc = this.lopHoc.MaLopHoc // Gán mã lớp học
            };

            // Thêm sinh viên vào danh sách
            if (!KiemTraTonTaiSinhVien(sinhVien))
            {
                danhSachSinhVien.Add(sinhVien);
                LoadDtgvDanhSachSinhVien();
            }

            txtMaSinhVien.Clear();
            txtHoTen.Clear();
        }

        public void DocFileExcelVaThemVaoDanhSach(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo đường dẫn cho file tạm
            string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(filePath));

            try
            {
                // Sao chép file gốc sang file tạm
                File.Copy(filePath, tempFilePath, true);

                // Lấy vị trí ô từ TextBox
                string maSinhVienCell = txtMaSinhVienCell.Text.Trim();
                string hoTenCell = txtHoTenCell.Text.Trim();

                // Mở file Excel tạm
                using (var workbook = new XLWorkbook(tempFilePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed();

                    // Xác định vị trí cột và hàng
                    int maSinhVienColumn = GetColumnIndex(maSinhVienCell); // Cột cho Mã sinh viên
                    int hoTenColumn = GetColumnIndex(hoTenCell);           // Cột cho Họ tên
                    int startRow = Math.Max(GetRowIndex(maSinhVienCell), GetRowIndex(hoTenCell)) + 1; // hàng bắt đầu đọc

                    for (int rowIndex = startRow; rowIndex <= worksheet.LastRowUsed().RowNumber(); rowIndex++)
                    {
                        var maSinhVienCellValue = worksheet.Cell(rowIndex, maSinhVienColumn);
                        var hoTenCellValue = worksheet.Cell(rowIndex, hoTenColumn);

                        string maSinhVien = maSinhVienCellValue.GetString().Trim();
                        string hoTen = hoTenCellValue.GetString().Trim();

                        if (string.IsNullOrEmpty(maSinhVien) || string.IsNullOrEmpty(hoTen))
                            continue;

                        // Thêm sinh viên vào danh sách
                        SinhVien sinhVien = new SinhVien
                        {
                            SinhVienID = -1,
                            MaSinhVien = maSinhVien,
                            HoTen = hoTen,
                            MaLopHoc = this.lopHoc.MaLopHoc
                        };

                        if (!KiemTraTonTaiSinhVien(sinhVien))
                        {
                            danhSachSinhVien.Add(sinhVien);
                        }
                    }
                }

                // Cập nhật lại DataGridView
                LoadDtgvDanhSachSinhVien();
                MessageBox.Show("Đọc dữ liệu từ file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi đọc file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Xóa file tạm sau khi sử dụng
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
        }

        private void PasteSinhVienDataFromClipboard()
        {
            // Kiểm tra xem có dữ liệu trong Clipboard không
            if (Clipboard.ContainsText())
            {
                string clipboardData = Clipboard.GetText();
                string[] rows = clipboardData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string row in rows)
                {
                    // Tách mã sinh viên và họ tên bằng ký tự tab
                    string[] columns = row.Split('\t');

                    if (columns.Length >= 2)
                    {
                        string maSinhVien = columns[0].Trim();
                        string hoTen = columns[1].Trim();

                        // Kiểm tra dữ liệu hợp lệ trước khi thêm vào danh sách
                        if (!string.IsNullOrEmpty(maSinhVien) && !string.IsNullOrEmpty(hoTen))
                        {
                            SinhVien sinhVien = new SinhVien
                            {
                                SinhVienID = -1,  // Có thể sử dụng -1 để tạm thời cho ID chưa xác định
                                MaSinhVien = maSinhVien,
                                HoTen = hoTen,
                                MaLopHoc = this.lopHoc.MaLopHoc
                            };

                            if (!KiemTraTonTaiSinhVien(sinhVien))
                            {
                                danhSachSinhVien.Add(sinhVien);
                            }
                        }
                    }
                }

                // Cập nhật lại DataGridView
                LoadDtgvDanhSachSinhVien();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu trong Clipboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Phương thức để lấy chỉ số cột từ tên cột (ví dụ: "B" -> 2)
        private int GetColumnIndex(string cellReference)
        {
            string columnLetter = new string(cellReference.TakeWhile(char.IsLetter).ToArray());
            int columnIndex = 0;

            for (int i = 0; i < columnLetter.Length; i++)
            {
                columnIndex = columnIndex * 26 + (columnLetter[i] - 'A' + 1);
            }

            return columnIndex;
        }

        // Phương thức để lấy chỉ số hàng từ tên ô (ví dụ: "B2" -> 2)
        private int GetRowIndex(string cellReference)
        {
            string rowNumber = new string(cellReference.SkipWhile(char.IsLetter).ToArray());
            return int.Parse(rowNumber);
        }

        private void ThemSinhVienTuDanhSach(List<SinhVien> danhSachSinhVien)
        {
            string str = "- Đã lưu sinh viên -\n\n";
            foreach (var sinhVien in danhSachSinhVien)
            {
                if (!SinhVienDAO.Instance.ThemSinhVien(sinhVien.MaSinhVien, sinhVien.HoTen, sinhVien.MaLopHoc))
                {
                    str += $"Lưu sinh viên {sinhVien.HoTen} - {sinhVien.MaSinhVien} thất bại! Kiểm tra lại dữ liệu, tránh trùng lặp.\n";
                }
                
            }
            MessageBox.Show(str);
        }

        private bool KiemTraTonTaiSinhVien(SinhVien sv)
        {
            foreach(SinhVien item in this.danhSachSinhVien)
            {
                if (item.MaSinhVien.Equals(sv.MaSinhVien))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Events
        private void btnThemMotSinhVien_Click(object sender, EventArgs e)
        {
            ThemMotSinhVienTuTextBox();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThemSinhVienTuDanhSach(this.danhSachSinhVien);
            danhSachSinhVien.Clear(); // Xóa danh sách sau khi lưu
            LoadDtgvDanhSachSinhVien(); // Cập nhật lại DataGridView
        }

        private void TxtHoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThemMotSinhVienTuTextBox();
                e.SuppressKeyPress = true;
            }
        }

        private void btnDocFileExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Chọn file Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DocFileExcelVaThemVaoDanhSach(openFileDialog.FileName);
                }
            }
        }

        private void btnDan_Click(object sender, EventArgs e)
        {
            string clipboardData = Clipboard.GetText();

            if (string.IsNullOrEmpty(clipboardData))
            {
                MessageBox.Show("Không có dữ liệu trong Clipboard!");
                return;
            }

            // Hiển thị xem trước và xác nhận
            DialogResult result = MessageBox.Show($"Dữ liệu dán:\n\n{clipboardData}\n\nBạn có muốn thêm không? Đảm bảo hai cột mã số và họ tên phải liên kề trong excel", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                PasteSinhVienDataFromClipboard();
            }
        }

        private void dtgvDanhSachSinhVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy SinhVienID từ cột tương ứng trong DataGridView
                var sinhVienID = dtgvDanhSachSinhVien.Rows[e.RowIndex].Cells["SinhVienID"].Value.ToString();

                // Tìm sinh viên trong danh sách
                var sinhVienToRemove = danhSachSinhVien.FirstOrDefault(sv => sv.SinhVienID.ToString() == sinhVienID);

                if (sinhVienToRemove != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        danhSachSinhVien.Remove(sinhVienToRemove);
                        LoadDtgvDanhSachSinhVien();
                    }
                }
            }
        }



        #endregion

        private void formThemSinhVien_Load(object sender, EventArgs e)
        {

        }
    }
}
