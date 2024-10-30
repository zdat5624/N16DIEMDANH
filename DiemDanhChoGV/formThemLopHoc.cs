using DiemDanhChoGV.DAO;
using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiemDanhChoGV
{
    public partial class formThemLopHoc : Form
    {
        List<MonHoc> danhSachMonHoc = null;

        public formThemLopHoc()
        {
            InitializeComponent();
            this.danhSachMonHoc = MonHocDAO.Instance.GetDanhSachMonHoc();
            LoadForm();
        }

        void LoadForm()
        {
            // Xóa các mục hiện có trong ComboBox
            cbbTenMonHoc.Items.Clear();

            // Thêm từng môn học vào ComboBox
            foreach (MonHoc monHoc in danhSachMonHoc)
            {
                cbbTenMonHoc.Items.Add(monHoc);
            }
            cbbTenMonHoc.DisplayMember = "TenMonHoc";

            // Đặt SelectedIndex về -1 để không có lựa chọn ban đầu
            cbbTenMonHoc.SelectedIndex = -1;
        }




        private void cbbTenMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có lựa chọn hợp lệ trong ComboBox
            if (cbbTenMonHoc.SelectedItem is MonHoc selectedMonHoc)
            {
                // Lấy mã môn học trực tiếp từ đối tượng MonHocItem
                txtMaMonHoc.Text = selectedMonHoc.MaMonHoc;
            }
        }



        void ThemLopHoc()
        {
            string tenLop = txtTenLop.Text;
            int monHocID = -1;
            if (cbbTenMonHoc.SelectedItem is MonHoc selectedMonHoc)
            {
                monHocID = selectedMonHoc.MonHocID;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học hợp lệ");
                return;
            } 
            
            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;

            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Tên lớp không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return;
            }

            if (ngayBatDau > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayBatDau.Focus();
                return;
            }

            if (LopHocDAO.Instance.ThemLopHoc(tenLop, monHocID, ngayBatDau, ngayKetThuc))
            {
                MessageBox.Show("Thêm lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form thêm lớp học sau khi thêm thành công
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Gọi hàm ThemLopHoc để thêm lớp học vào cơ sở dữ liệu
            ThemLopHoc();
        }
    }
}
