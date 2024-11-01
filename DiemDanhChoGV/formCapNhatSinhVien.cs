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
    public partial class formCapNhatSinhVien : Form
    {
        string maSinhVien;
        public formCapNhatSinhVien(string MaSinhVien)
        {
            InitializeComponent();
            this.maSinhVien = MaSinhVien;
        }

        void LoadForm()
        {
            int sinhVienID = SinhVienDAO.Instance.GetSinhVienIDByMaSinhVien(maSinhVien);
            // Lấy dữ liệu lớp học từ DAO
            SinhVien sinhVien = SinhVienDAO.Instance.GetSinhVienBySinhVienID(sinhVienID);
            if (sinhVien != null)
            {
                txtMaSoSinhVien.Text = this.maSinhVien.ToString();
                txtHoTenSinhVien.Text = sinhVien.HoTen;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu không tìm thấy sinh viên
            }
            
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int sinhVienID = SinhVienDAO.Instance.GetSinhVienIDByMaSinhVien(maSinhVien);
            SinhVien sinhVien = SinhVienDAO.Instance.GetSinhVienBySinhVienID(sinhVienID);
            // Lấy thông tin từ các TextBox
            string hoTen = txtHoTenSinhVien.Text;
            string maSinhVienMoi = txtMaSoSinhVien.Text;
            // Gọi phương thức cập nhật từ DAO
            if (maSinhVien != maSinhVienMoi && SinhVienDAO.Instance.KiemTraMaSinhVienTonTai(maSinhVienMoi))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (SinhVienDAO.Instance.CapNhatSinhVien(sinhVienID, maSinhVienMoi, hoTen, sinhVien.MaLopHoc))
            {
                MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formCapNhatSinhVien_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
