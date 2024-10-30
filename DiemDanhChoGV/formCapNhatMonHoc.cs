using DiemDanhChoGV.DAO;
using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiemDanhChoGV
{
    public partial class formCapNhatMonHoc : Form
    {
        int monHocID;

        public formCapNhatMonHoc(int MonHocID)
        {
            InitializeComponent();
            this.monHocID = MonHocID;
        }

        void LoadForm()
        {
            // Lấy dữ liệu môn học từ DAO
            MonHoc monHoc = MonHocDAO.Instance.TimMonHocTheoMonHocID(monHocID);
            if (monHoc != null)
            {
                // Gán giá trị vào các TextBox và NumericUpDown
                txtMaMonHoc.Text = monHoc.MaMonHoc;
                txtTenMonHoc.Text = monHoc.TenMonHoc;
                nudSoTinChi.Value = monHoc.SoTinChi; // NumericUpDown cho số tín chỉ
            }
            else
            {
                MessageBox.Show("Không tìm thấy môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu không tìm thấy môn học
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox và NumericUpDown
            string maMonHoc = txtMaMonHoc.Text;
            string tenMonHoc = txtTenMonHoc.Text;
            int soTinChi = (int)nudSoTinChi.Value;

            // Gọi phương thức cập nhật từ DAO
            if (MonHocDAO.Instance.UpdateMonHoc(monHocID, maMonHoc, tenMonHoc, soTinChi))
            {
                MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formCapNhatMonHoc_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
