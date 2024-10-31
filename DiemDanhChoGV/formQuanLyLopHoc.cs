using DiemDanhChoGV.DAO;
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
    public partial class formQuanLyLopHoc : Form
    {
        public formQuanLyLopHoc()
        {
            InitializeComponent();
        }


        void LoadForm()
        {
            dataGridViewLopHoc.DataSource = LopHocDAO.Instance.GetDanhSachLopHoc();
            dataGridViewLopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewLopHoc.Columns["MonHocID"].HeaderText = "ID môn học";
            dataGridViewLopHoc.Columns["TenLop"].HeaderText = "Tên Lớp Học";
            dataGridViewLopHoc.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
            dataGridViewLopHoc.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";

            dataGridViewLopHoc.Columns["MaLopHoc"].Visible = false;

        }

        private void formQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnXoaLopHoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn lớp học nào để xóa chưa
            if (dataGridViewLopHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin lớp học đã chọn
            int maLopHoc = (int)dataGridViewLopHoc.SelectedRows[0].Cells["MaLopHoc"].Value;

            // Hiển thị thông báo cảnh báo người dùng
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                // Gọi phương thức xóa lớp học từ DAO
                LopHocDAO.Instance.DeleteLopHoc(maLopHoc);
                MessageBox.Show("lớp học đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadForm();
            }
        }



        private void btnThemLopHoc_Click(object sender, EventArgs e)
        {
            formThemLopHoc f = new formThemLopHoc();
            f.ShowDialog();
            LoadForm();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn lớp học nào để cập nhật chưa
            if (dataGridViewLopHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin lớp học đã chọn
            int maLopHoc = (int)dataGridViewLopHoc.SelectedRows[0].Cells["MaLopHoc"].Value;

            // Mở form cập nhật lớp học và truyền vào maLopHoc
            formCapNhatLopHoc f = new formCapNhatLopHoc(maLopHoc);
            f.ShowDialog();

            // Tải lại danh sách môn học sau khi cập nhật
            LoadForm();
        }
    }
}
