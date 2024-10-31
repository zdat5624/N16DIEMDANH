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
    public partial class formCapNhatLopHoc : Form
    {
        int maLopHoc;
        public formCapNhatLopHoc(int MaLopHoc)
        {
            InitializeComponent();
            this.maLopHoc = MaLopHoc;
        }

        void LoadForm()
        {
            // Lấy dữ liệu lớp học từ DAO
            LopHoc lopHoc = LopHocDAO.Instance.GetLopHocByMaLopHoc(maLopHoc);
            if (lopHoc != null)
            {
                // Gán giá trị vào các TextBox và DateTimePicker
                txtMonHocID.Text = Convert.ToString(lopHoc.MonHocID);
                txtTenLopHoc.Text = lopHoc.TenLop;
                dtpNgayBatDau.Value = lopHoc.NgayBatDau;
                dtpNgayKetThuc.Value = lopHoc.NgayKetThuc;
            }
            else
            {
                MessageBox.Show("Không tìm thấy lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu không tìm thấy lớp học
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox và DateTimePicker
            int  monHocID = Convert.ToInt32(txtMonHocID.Text);
            string tenLop = txtTenLopHoc.Text;
            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;

            // Gọi phương thức cập nhật từ DAO
            if (LopHocDAO.Instance.UpdateLopHoc(maLopHoc, tenLop, monHocID, ngayBatDau, ngayKetThuc))
            {
                MessageBox.Show("Cập nhật lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formCapNhatLopHoc_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
