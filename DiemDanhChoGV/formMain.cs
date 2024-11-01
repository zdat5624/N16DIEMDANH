using DiemDanhChoGV.DAO;
using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace DiemDanhChoGV
{
    public partial class formMain : Form
    {
        private List<LopHoc> danhSachLopHoc;

        /// <summary>
        /// Đây là dữ liệu ứng với Lớp học đang được chọn để hiện thị trong Datagrid view
        /// </summary>

        private LopHoc lopHoc = null;
        private MonHoc monHoc = null;
        private List<SinhVien> danhSachSinhVien = null;
        private List<BuoiDiemDanh> danhSachBuoiDiemDanh = null;
        private List<DiemDanh> danhSachDiemDanh = null;
        
        private string kyHieuCoMat = "V";
        private string kyHieuVangMat = "X";
        private string kyHieuChuaDiemDanh = "-";

        public formMain()
        {
            InitializeComponent();
            
        }

        #region Methods
        void LoadForm()
        {
            List<LopHoc> dsLopHoc = LopHocDAO.Instance.GetDanhSachLopHoc();
            LoadDanhSachLopHoc(dsLopHoc);
        }

        void LoadDanhSachLopHoc(List<LopHoc> dsLopHoc)
        {
            this.danhSachLopHoc = dsLopHoc; 
            lvDanhSachLop.Items.Clear();

            foreach (LopHoc lopHoc in danhSachLopHoc)
            {
                ListViewItem item = new ListViewItem(lopHoc.MaLopHoc.ToString());
                item.SubItems.Add(lopHoc.MonHocID.ToString());
                item.SubItems.Add(MonHocDAO.Instance.GetMaMonHocByMonHocID(lopHoc.MonHocID));
                item.SubItems.Add(lopHoc.TenLop);
                lvDanhSachLop.Items.Add(item);
            }
            
            KhoiTaoListView();
        }

        void KhoiTaoListView()
        {
            lvDanhSachLop.Columns.Add("Mã lớp học",0);
            lvDanhSachLop.Columns.Add("Môn học ID", 0);
            lvDanhSachLop.Columns.Add("Mã môn học", 90);
            lvDanhSachLop.Columns.Add("Tên lớp", 400);

            lvDanhSachLop.View = View.Details;
            lvDanhSachLop.FullRowSelect = true;
        }



        void LoadDtgvDanhSachDiemDanh(int maLopHoc, int monHocID)
        {
            // Lấy dữ liệu
            this.monHoc = MonHocDAO.Instance.TimMonHocTheoMonHocID(monHocID);
            this.lopHoc = LopHocDAO.Instance.GetLopHocByMaLopHoc(maLopHoc);
            this.danhSachSinhVien = SinhVienDAO.Instance.GetDanhSachSinhVienByMaLopHoc(maLopHoc);
            this.danhSachBuoiDiemDanh = BuoiDiemDanhDAO.Instance.GetDanhSachBuoiDiemDanhByMaLopHoc(maLopHoc);
            this.danhSachDiemDanh = DiemDanhDAO.Instance.GetDanhSachDiemDanhByMaLopHoc(maLopHoc);

            // Tạo DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaSinhVien", typeof(string));
            dataTable.Columns.Add("HoTen", typeof(string));

            // Thêm cột
            foreach (var buoi in danhSachBuoiDiemDanh)
            {
                dataTable.Columns.Add("Buoi" + buoi.STT, typeof(string));
            }

            // Duyệt qua danh sách sinh viên và điền dữ liệu vào DataTable
            foreach (var sinhVien in danhSachSinhVien)
            {
                DataRow row = dataTable.NewRow();
                row["MaSinhVien"] = sinhVien.MaSinhVien;
                row["HoTen"] = sinhVien.HoTen;

                // Thêm trạng thái
                foreach (var buoi in danhSachBuoiDiemDanh)
                {
                    var diemDanh = danhSachDiemDanh
                        .FirstOrDefault(dd => dd.SinhVienID == sinhVien.SinhVienID && dd.MaBuoiDiemDanh == buoi.MaBuoiDiemDanh);

                    if (diemDanh != null)
                    {
                        row["Buoi" + buoi.STT] = diemDanh.TrangThai == 1 ? kyHieuCoMat : kyHieuVangMat;
                    }
                    else
                    {
                        row["Buoi" + buoi.STT] = kyHieuChuaDiemDanh;
                    }
                }

                dataTable.Rows.Add(row);
            }

            dtgvLopHoc.DataSource = dataTable;

            // Thiết lập header
            dtgvLopHoc.Columns["MaSinhVien"].HeaderText = "Mã số";
            dtgvLopHoc.Columns["MaSinhVien"].Name = "MaSinhVien";
            dtgvLopHoc.Columns["MaSinhVien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvLopHoc.Columns["MaSinhVien"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvLopHoc.Columns["HoTen"].HeaderText = "Họ và tên";
            dtgvLopHoc.Columns["HoTen"].Name = "HoTen";
            dtgvLopHoc.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvLopHoc.Columns["HoTen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (var buoi in danhSachBuoiDiemDanh)
            {
                string columnName = "Buoi" + buoi.STT;
                dtgvLopHoc.Columns[columnName].HeaderText = "Buổi " + buoi.STT;
                dtgvLopHoc.Columns[columnName].Name = columnName;
                dtgvLopHoc.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvLopHoc.Columns[columnName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            // Đặt tiêu đề
            lbTieuDe.Text = $"{this.lopHoc.TenLop} - {this.monHoc.MaMonHoc} - {this.monHoc.TenMonHoc} - {this.monHoc.SoTinChi} tín chỉ - {this.lopHoc.NgayBatDau:dd/MM/yyyy} đến {this.lopHoc.NgayKetThuc:dd/MM/yyyy}";

            btnDiemDanh.Visible = true;
            btnXoaLop.Visible = true;
            btnThemSinhVien.Visible = true;
            btnCapNhatSinhVien.Visible = true;
        }



        #endregion

        #region Events

        private void formMain_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void lvDanhSachLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Đảm bảo có item chọn
            if (lvDanhSachLop.SelectedItems.Count > 0)
            {

                ListViewItem selectedItem = lvDanhSachLop.SelectedItems[0];
                string maLopHocString = selectedItem.SubItems[0].Text;
                string monHocIDString = selectedItem.SubItems[1].Text;

                if (int.TryParse(maLopHocString, out int maLopHoc) && int.TryParse(monHocIDString, out int monHocID))
                {
                    LoadDtgvDanhSachDiemDanh(maLopHoc, monHocID);
                }


            }
            
        }

        

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            formChonBuoiDiemDanh f = new formChonBuoiDiemDanh(lopHoc, monHoc, danhSachSinhVien,danhSachBuoiDiemDanh, danhSachDiemDanh);
            f.ShowDialog();
            if (this.lopHoc != null)
            {
                LoadDtgvDanhSachDiemDanh(this.lopHoc.MaLopHoc, this.lopHoc.MonHocID);
            }
            
        }
        private void ExportToExcel(DataGridView dataGridView)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Data");

                // Tạo tiêu đề cột từ DataGridView
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                }

                // Thêm dữ liệu từ DataGridView vào Excel
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // Lưu file Excel
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save an Excel File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
                }
            }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            if (lvDanhSachLop.SelectedItems.Count > 0)
            {
                DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa lớp có mã "+ lvDanhSachLop.SelectedItems[0].Text, "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)
                {
                    int maLop = int.Parse(lvDanhSachLop.SelectedItems[0].Text);
                    LopHocDAO.Instance.DeleteLopHoc(maLop);
                    dtgvLopHoc.DataSource = null;
                    LoadForm();
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsXuatFileExcel_Click(object sender, EventArgs e)
        {
            if (lopHoc == null)
            {
                MessageBox.Show("Vui lòng mở một lớp học");
                return;
            }
            ExportToExcel(dtgvLopHoc);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsThemMonHoc_Click(object sender, EventArgs e)
        {
            formThemMonHoc f = new formThemMonHoc();
            f.ShowDialog();
        }

        #endregion

        private void tsMonHoc_Click(object sender, EventArgs e)
        {
            formQuanLyMonHoc f = new formQuanLyMonHoc();
            f.ShowDialog();
        }

        private void tsLopHoc_Click(object sender, EventArgs e)
        {
            formQuanLyLopHoc f = new formQuanLyLopHoc();

            // Đăng ký sự kiện DataChanged để cập nhật dữ liệu khi có thay đổi trong formQuanLyLopHoc
            f.DataChanged += LoadForm;

            f.ShowDialog();
        }

        private void tsThemLopHoc_Click(object sender, EventArgs e)
        {
            formThemLopHoc f = new formThemLopHoc();
            f.ShowDialog();
            LoadForm();
            if (this.lopHoc != null)
            {
                LoadDtgvDanhSachDiemDanh(this.lopHoc.MaLopHoc, this.lopHoc.MonHocID);
            }
        }

        private void btnThemSinhVien_Click(object sender, EventArgs e)
        {
            if (this.lopHoc == null )
            {
                MessageBox.Show("Vui lòng chọn một lớp học trong danh sách lớp học");
                return;
            }

            formThemSinhVien f = new formThemSinhVien(this.lopHoc);
            f.ShowDialog();
            LoadForm();
            if (this.lopHoc != null)
            {
                LoadDtgvDanhSachDiemDanh(this.lopHoc.MaLopHoc, this.lopHoc.MonHocID);
            }
        }

        private void btnCapNhatSinhVien_Click(object sender, EventArgs e)
        {
            if (this.lopHoc == null)
            {
                MessageBox.Show("Vui lòng chọn một lớp học trong danh sách lớp học");
                return;
            }

            // Kiểm tra xem người dùng đã chọn sinh viên nào để cập nhật chưa
            if (dtgvLopHoc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin sinh viên đã chọn
            string maSinhVien = dtgvLopHoc.CurrentRow.Cells["MaSinhVien"].Value.ToString();

            // Mở form cập nhật lớp học và truyền vào maLopHoc
            formCapNhatSinhVien f = new formCapNhatSinhVien(maSinhVien);
            f.ShowDialog();

            // Tải lại danh sách sinh viên sau khi cập nhật
            LoadForm();
            if (this.lopHoc != null)
            {
                LoadDtgvDanhSachDiemDanh(this.lopHoc.MaLopHoc, this.lopHoc.MonHocID);
            }
        }
    }
}
