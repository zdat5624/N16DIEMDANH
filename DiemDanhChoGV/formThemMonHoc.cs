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
    public partial class formThemMonHoc : Form
    {
        public formThemMonHoc()
        {
            InitializeComponent();
            txtMaMonHoc.TabIndex = 0; // Chuyển đến đầu tiên
            txtTenMonHoc.TabIndex = 1; // Chuyển đến sau txtMaMonHoc
            nudSoTinChi.TabIndex = 2;
        }

        void ThemMonHoc()
        {
            // Lấy dữ liệu từ các TextBox và NumericUpDown
            string maMonHoc = txtMaMonHoc.Text.Trim();
            string tenMonHoc = txtTenMonHoc.Text.Trim();
            int soTinChi = (int)nudSoTinChi.Value;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maMonHoc) || string.IsNullOrEmpty(tenMonHoc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã môn học có tồn tại
            if (MonHocDAO.Instance.KiemTraMaMonHocTonTai(maMonHoc))
            {
                MessageBox.Show("Mã môn học đã tồn tại. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm môn học bằng cách gọi phương thức trong MonHocDAO
            bool isAdded = MonHocDAO.Instance.ThemMonHoc(maMonHoc, tenMonHoc, soTinChi);

            if (isAdded)
            {
                MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close(); // Đóng form sau khi thêm thành công
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            ThemMonHoc();
        }
    }
}
