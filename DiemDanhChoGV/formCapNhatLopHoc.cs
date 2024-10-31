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
        List<MonHoc> danhSachMonHoc = null;
        public formCapNhatLopHoc(int MaLopHoc)
        {
            InitializeComponent();
            this.maLopHoc = MaLopHoc;
            this.danhSachMonHoc = MonHocDAO.Instance.GetDanhSachMonHoc();
        }

        void LoadForm()
        {
            // Lấy dữ liệu lớp học từ DAO
            LopHoc lopHoc = LopHocDAO.Instance.GetLopHocByMaLopHoc(maLopHoc);
            if (lopHoc != null)
            {
                // Xóa các mục hiện có trong ComboBox
                cbxTenMonHoc.Items.Clear();

                // Thêm từng môn học vào ComboBox
                foreach (MonHoc monHoc in danhSachMonHoc)
                {
                    cbxTenMonHoc.Items.Add(monHoc);
                }
                cbxTenMonHoc.DisplayMember = "TenMonHoc";
                // Gán giá trị vào các TextBox và DateTimePicker
                cbxTenMonHoc.SelectedIndex = lopHoc.MonHocID - 1;
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
            string tenMonHoc = cbxTenMonHoc.Text;
            int monHocID = MonHocDAO.Instance.TimMonHocIDTheoTenMonHoc(tenMonHoc);
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
