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
            string tenLop = txtTenLop.Text.Trim();
            int monHocID = -1;

            // Kiểm tra và lấy MonHocID từ ComboBox
            if (cbbTenMonHoc.SelectedItem is MonHoc selectedMonHoc)
            {
                monHocID = selectedMonHoc.MonHocID;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
            int soBuoi = (int)numericUpDownSoBuoi.Value;

            // Kiểm tra dữ liệu đầu vào
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

            // Thêm lớp học và kiểm tra kết quả
            int lopHocID = LopHocDAO.Instance.ThemLopHocVaLayID(tenLop, monHocID, ngayBatDau, ngayKetThuc);
            if (lopHocID > 0)
            {
                // Thêm buổi điểm danh
                for (int i = 1; i <= soBuoi; i++)
                {
                    BuoiDiemDanhDAO.Instance.ThemBuoiDiemDanh(lopHocID, i); // Truyền vào STT của buổi điểm danh
                }

                MessageBox.Show("Thêm lớp học và buổi điểm danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
            ThemLopHoc();
        }
    }
}
