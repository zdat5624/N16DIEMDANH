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
    public partial class formQuanLyMonHoc : Form
    {
        public formQuanLyMonHoc()
        {
            InitializeComponent();
        }

        void LoadForm()
        {
            dataGridViewMonHoc.DataSource = MonHocDAO.Instance.GetDanhSachMonHoc();
            dataGridViewMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewMonHoc.Columns["MaMonHoc"].HeaderText = "Mã Môn Học";
            dataGridViewMonHoc.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";
            dataGridViewMonHoc.Columns["SoTinChi"].HeaderText = "Số Tín Chỉ";

            dataGridViewMonHoc.Columns["MonHocID"].Visible = false;

        }

        private void formQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnXoaMonHoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn môn học nào để xóa chưa
            if (dataGridViewMonHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một môn học để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin môn học đã chọn
            int monHocID = (int)dataGridViewMonHoc.SelectedRows[0].Cells["MonHocID"].Value;

            // Hiển thị thông báo cảnh báo người dùng
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này? Tất cả các lớp học liên quan sẽ bị xóa.", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                // Gọi phương thức xóa môn học từ DAO
                bool isDeleted = MonHocDAO.Instance.DeleteMonHoc(monHocID);
                if (isDeleted)
                {
                    MessageBox.Show("Môn học đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadForm();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa môn học!, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            formThemMonHoc f = new formThemMonHoc();
            f.ShowDialog();
            LoadForm();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn môn học nào để cập nhật chưa
            if (dataGridViewMonHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một môn học để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin môn học đã chọn
            int monHocID = (int)dataGridViewMonHoc.SelectedRows[0].Cells["MonHocID"].Value;

            // Mở form cập nhật môn học và truyền vào monHocID
            formCapNhatMonHoc f = new formCapNhatMonHoc(monHocID);
            f.ShowDialog();

            // Tải lại danh sách môn học sau khi cập nhật
            LoadForm();
        }

    }
}
