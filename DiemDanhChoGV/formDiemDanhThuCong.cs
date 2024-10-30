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

namespace DiemDanhChoGV
{
    public partial class formDiemDanhThuCong : Form
    {
        private int maBuoiDiemDanh;
        private LopHoc lopHoc = null;
        private MonHoc monHoc = null;
        private List<SinhVien> danhSachSinhVien = null;
        private List<BuoiDiemDanh> danhSachBuoiDiemDanh = null;
        private List<DiemDanh> danhSachDiemDanh = null;

        public formDiemDanhThuCong(LopHoc lopHoc, MonHoc monHoc, List<SinhVien> danhSachSinhVien, List<BuoiDiemDanh> danhSachBuoiDiemDanh, List<DiemDanh> danhSachDiemDanh, int maBuoiDiemDanh)
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

        private void LoadDataGridView()
        {
            dtgvDiemDanh.Columns.Clear();
            dtgvDiemDanh.AutoGenerateColumns = false;

            // Cột Mã số sinh viên
            DataGridViewTextBoxColumn maSVColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã số sinh viên",
                DataPropertyName = "MaSinhVien",
                Name = "MSSV",
                Width = 150,
                ReadOnly = true
            };
            dtgvDiemDanh.Columns.Add(maSVColumn);

            // Cột Tên sinh viên
            DataGridViewTextBoxColumn tenSVColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sinh viên",
                DataPropertyName = "HoTen",
                Name = "Ten",
                Width = 250,
                ReadOnly = true
            };
            dtgvDiemDanh.Columns.Add(tenSVColumn);

            // Cột Có mặt
            DataGridViewCheckBoxColumn coMatColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Có mặt",
                Name = "coMat",
                Width = 80
            };
            dtgvDiemDanh.Columns.Add(coMatColumn);

            // Cột Vắng mặt
            DataGridViewCheckBoxColumn vangMatColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Vắng mặt",
                Name = "vangMat",
                Width = 80
            };
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

        // Sự kiện lưu điểm danh
        private void btnLuuDiemDanh_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgvDiemDanh.Rows)
            {

                string maSinhVien = (row.Cells["MSSV"].Value).ToString();
                int sinhVienID = GetSinhVienIDbyMaSinhVien(maSinhVien);
                int maBuoiDiemDanh = this.maBuoiDiemDanh; // Lấy mã buổi điểm danh hiện tại

                if (sinhVienID==0)
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

                // Gọi phương thức lưu điểm danh từ DAO
                DiemDanhDAO.Instance.LuuDiemDanh(maBuoiDiemDanh, sinhVienID, trangThai);
            }
            MessageBox.Show("Điểm danh đã được lưu.");
        }

        public int GetSinhVienIDbyMaSinhVien(string maSinhVien)
        {
            foreach(SinhVien sv in danhSachSinhVien )
            {
                if ((sv.MaSinhVien).Equals(maSinhVien))
                {
                    return sv.SinhVienID;
                }
            }
            return 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
