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
using ZXing; //Thu vien doc barcode
using AForge.Video;
using AForge.Video.DirectShow;


namespace DiemDanhChoGV
{
    public partial class formDiemDanhMaVach : Form
    {
        private int maBuoiDiemDanh;
        private LopHoc lopHoc = null;
        private MonHoc monHoc = null;
        private List<SinhVien> danhSachSinhVien = null;
        private List<BuoiDiemDanh> danhSachBuoiDiemDanh = null;
        private List<DiemDanh> danhSachDiemDanh = null;

        FilterInfoCollection filterInfoCollection = null; // Bien luu thong tin cac thiet bi
        VideoCaptureDevice videoCaptureDevice = null; // Bien tuong tac voi thiet bi video

        public formDiemDanhMaVach(LopHoc lopHoc, MonHoc monHoc, List<SinhVien> danhSachSinhVien, List<BuoiDiemDanh> danhSachBuoiDiemDanh, List<DiemDanh> danhSachDiemDanh, int maBuoiDiemDanh)
        {
            InitializeComponent();
            this.lopHoc = lopHoc;
            this.monHoc = monHoc;
            this.danhSachSinhVien = danhSachSinhVien;
            this.danhSachBuoiDiemDanh = danhSachBuoiDiemDanh;
            this.danhSachDiemDanh = danhSachDiemDanh;
            this.maBuoiDiemDanh = maBuoiDiemDanh;

            LoadDataGridView();
        }

        #region Medthods

        void LoadForm()
        {
            // lay danh sach cac thiet bi video duoc ket noi voi may tinh
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // them vao comboBox
            foreach(FilterInfo filterInfo in filterInfoCollection)
            {
                cbbCamera.Items.Add(filterInfo.Name);
            }

            // Tu dong chon thiet bi dau tien trong danh sach
            cbbCamera.SelectedIndex = cbbCamera.Items.Count > 0 ? 0 : -1;

        }
        private void LoadDataGridView()
        {
            dtgvDiemDanh.Columns.Clear();
            dtgvDiemDanh.AutoGenerateColumns = false;

            // Cột Mã số sinh viên
            DataGridViewTextBoxColumn maSVColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã số",
                DataPropertyName = "MaSinhVien",
                Name = "MSSV",
                Width = 150,
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dtgvDiemDanh.Columns.Add(maSVColumn);

            // Cột Tên sinh viên
            DataGridViewTextBoxColumn tenSVColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Họ tên",
                DataPropertyName = "HoTen",
                Name = "Ten",
                Width = 250,
                ReadOnly = true
            };
            dtgvDiemDanh.Columns.Add(tenSVColumn);

            // Cột Có mặt
            DataGridViewCheckBoxColumn coMatColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Có",
                Name = "coMat",
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            };
            coMatColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDiemDanh.Columns.Add(coMatColumn);

            // Cột Vắng mặt
            DataGridViewCheckBoxColumn vangMatColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Vắng",
                Name = "vangMat",
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            vangMatColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDiemDanh.Columns.Add(vangMatColumn);

            // Duyệt qua danh sách sinh viên để thêm vào DataGridView
            foreach (var sinhVien in danhSachSinhVien)
            {
                // Kiểm tra xem sinh viên đã điểm danh hay chưa
                var diemDanh = danhSachDiemDanh.FirstOrDefault(dd => dd.SinhVienID == sinhVien.SinhVienID && dd.MaBuoiDiemDanh == maBuoiDiemDanh);

                bool coMat = diemDanh != null && diemDanh.TrangThai == 1; // Giả sử TrangThai = 1 là có mặt
                bool vangMat = diemDanh != null && diemDanh.TrangThai == 0; // Giả sử TrangThai = 0 là vắng mặt

                dtgvDiemDanh.Rows.Add(sinhVien.MaSinhVien, sinhVien.HoTen, coMat, vangMat);
            }
        }

        public int GetSinhVienIDbyMaSinhVien(string maSinhVien)
        {
            foreach (SinhVien sv in danhSachSinhVien)
            {
                if ((sv.MaSinhVien).Equals(maSinhVien))
                {
                    return sv.SinhVienID;
                }
            }
            return 0;
        }

        void Start_DiemDanhMaVach()
        {
            Stop_DiemDanhMaVach();

            if (cbbCamera.Items.Count > 0)
            {
                //Khoi tao thiet bi video, dua tren thiet bi duoc chon tren cbbCamera
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbbCamera.SelectedIndex].MonikerString);
                // dang ky nhan su kien frame moi tu camera
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;

                videoCaptureDevice.Start();
            }
            
        }

        void Stop_DiemDanhMaVach()
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                    if (ptbCamera.Image != null)
                    {
                        ptbCamera.Image.Dispose(); // Giải phóng hình ảnh hiện tại trước khi gán null
                        ptbCamera.Image = null;
                    }
                }
            }
        }


        //private void DiemDanhSinhVien(string maSinhVien)
        //{
        //    if (string.IsNullOrEmpty(maSinhVien))
        //    {
        //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    bool flag = false;
        //    // Duyệt qua từng hàng của DataGridView để tìm sinh viên có mã số phù hợp
        //    foreach (DataGridViewRow row in dtgvDiemDanh.Rows)
        //    {
        //        // Kiểm tra nếu mã sinh viên trong hàng trùng với mã được truyền vào
        //        if (row.Cells["MSSV"].Value != null && (row.Cells["MSSV"].Value.ToString()).Equals(maSinhVien))
        //        {
        //            row.Cells["coMat"].Value = true;
        //            row.Cells["vangMat"].Value = false;
        //            flag = true;
        //            break;
        //        }
        //    }

        //    if (flag)
        //    {
        //        richTextBoxThongBao.Text = $"Thành công! Điểm danh sinh viên '{maSinhVien}'";
        //        richTextBoxThongBao.BackColor = Color.Green;
        //        txtMaSinhVien.Clear();
        //    }
        //    else
        //    {
        //        richTextBoxThongBao.Text = $"Thất bại! Không tìm thấy sinh viên '{maSinhVien}'";
        //        richTextBoxThongBao.BackColor = Color.Red;
        //    }
        //}

        private void DiemDanhSinhVien(string maSinhVien)
        {
            if (string.IsNullOrEmpty(maSinhVien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dtgvDiemDanh.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["MSSV"].Value?.ToString() == maSinhVien);

            if (row != null)
            {
                row.Cells["coMat"].Value = true;
                row.Cells["vangMat"].Value = false;
                richTextBoxThongBao.Text = $"Thành công! Điểm danh sinh viên '{maSinhVien}'";
                richTextBoxThongBao.BackColor = Color.Green;
                txtMaSinhVien.Clear();
            }
            else
            {
                richTextBoxThongBao.Text = $"Thất bại! Không tìm thấy sinh viên '{maSinhVien}'";
                richTextBoxThongBao.BackColor = Color.Red;
            }
            
        }

        #endregion

        #region Events
        // Sự kiện để đảm bảo chỉ chọn một trong hai ô Có mặt hoặc Vắng mặt
        private void dtgvDiemDanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Kiểm tra nếu người dùng đã nhấn vào cột Có mặt
                if (e.ColumnIndex == dtgvDiemDanh.Columns["coMat"].Index)
                {
                    // Đặt tất cả ô Vắng mặt trong cùng hàng thành false
                    dtgvDiemDanh.Rows[e.RowIndex].Cells["vangMat"].Value = false;
                }

                // Kiểm tra nếu người dùng đã nhấn vào cột Vắng mặt
                if (e.ColumnIndex == dtgvDiemDanh.Columns["vangMat"].Index)
                {
                    // Đặt tất cả ô Có mặt trong cùng hàng thành false
                    dtgvDiemDanh.Rows[e.RowIndex].Cells["coMat"].Value = false;
                }
            }
        }

        private void btnLuuDiemDanh_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgvDiemDanh.Rows)
            {

                string maSinhVien = (row.Cells["MSSV"].Value).ToString();
                int sinhVienID = GetSinhVienIDbyMaSinhVien(maSinhVien);
                int maBuoiDiemDanh = this.maBuoiDiemDanh; // Lấy mã buổi điểm danh hiện tại

                if (sinhVienID == 0)
                {
                    return;
                }

                // Kiểm tra trạng thái
                int? trangThai = null; // Mặc định là null
                if (row.Cells["coMat"].Value != null && (bool)row.Cells["coMat"].Value == true)
                {
                    trangThai = 1; // Có mặt
                }
                else if (row.Cells["vangMat"].Value != null && (bool)row.Cells["vangMat"].Value == true)
                {
                    trangThai = 0; // Vắng mặt
                }
                else if ((bool)row.Cells["coMat"].Value == false && (bool)row.Cells["vangMat"].Value == false && row.Cells["coMat"].Value != null && row.Cells["vangMat"].Value != null)
                {
                    if (checkBoxTuDongVang.Checked)
                    {
                        trangThai = 0; // Vắng mặt
                    }
                }

                // Gọi phương thức lưu điểm danh từ DAO
                DiemDanhDAO.Instance.LuuDiemDanh(maBuoiDiemDanh, sinhVienID, trangThai);
            }
            MessageBox.Show("Điểm danh đã được lưu.");
        }

        private int frameCounter = 0;
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //frameCounter++;

            //// Đọc mã vạch mỗi 3 khung hình để cải thiện tốc độ
            //if (frameCounter % 2 != 0)
            //    return;

            //frameCounter = 0; // Đặt lại bộ đếm khung hình sau khi đọc

            using (Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone())
            {
                BarcodeReader reader = new BarcodeReader
                {
                    Options = new ZXing.Common.DecodingOptions
                    {
                        PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.CODE_39, BarcodeFormat.CODE_128 }
                    }
                };

                var result = reader.Decode(bitmap);
                if (result != null)
                {
                    txtMaSinhVien.Invoke(new MethodInvoker(delegate
                    {
                        string maSV = result.Text;
                        txtMaSinhVien.Text = maSV;
                        DiemDanhSinhVien(maSV);
                    }));
                }

                if (ptbCamera.Image != null)
                {
                    ptbCamera.Image.Dispose(); // Giải phóng hình ảnh hiện tại trước khi cập nhật
                }

                ptbCamera.Image = (Bitmap)bitmap.Clone();
            }
        }

        //private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        //{
        //    frameCounter++;

        //    // Đọc mã vạch mỗi 3 khung hình
        //    if (frameCounter % 3 != 0)
        //        return;

        //    frameCounter = 0;

        //    using (Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone())
        //    {
        //        // Xác định vùng giữa của ảnh
        //        int centerX = bitmap.Width / 2;
        //        int centerY = bitmap.Height / 2;
        //        int regionWidth = bitmap.Width / 4; // Kích thước vùng giữa (có thể điều chỉnh)
        //        int regionHeight = bitmap.Height / 4;

        //        Rectangle centerRegion = new Rectangle(
        //            centerX - regionWidth / 2,
        //            centerY - regionHeight / 2,
        //            regionWidth,
        //            regionHeight
        //        );

        //        using (Bitmap croppedBitmap = bitmap.Clone(centerRegion, bitmap.PixelFormat))
        //        {
        //            BarcodeReader reader = new BarcodeReader
        //            {
        //                Options = new ZXing.Common.DecodingOptions
        //                {
        //                    PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.CODE_39, BarcodeFormat.CODE_128 }
        //                }
        //            };

        //            var result = reader.Decode(croppedBitmap);
        //            if (result != null)
        //            {
        //                txtMaSinhVien.Invoke(new MethodInvoker(delegate
        //                {
        //                    string maSV = result.Text;
        //                    txtMaSinhVien.Text = maSV;
        //                    DiemDanhSinhVien(maSV);
        //                }));
        //            }

        //            // Cập nhật ảnh hiện tại trong PictureBox
        //            if (ptbCamera.Image != null)
        //            {
        //                ptbCamera.Image.Dispose();
        //            }
        //            ptbCamera.Image = (Bitmap)bitmap.Clone();
        //        }
        //    }
        //}





        private void formDiemDanhMaVach_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop_DiemDanhMaVach();
        }

        private void formDiemDanhMaVach_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start_DiemDanhMaVach();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop_DiemDanhMaVach();
        }

        private void txtMaSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DiemDanhSinhVien(txtMaSinhVien.Text);
                e.SuppressKeyPress = true;
            }
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            DiemDanhSinhVien(txtMaSinhVien.Text);
        }

        #endregion
    }
}
