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
    public partial class formChonBuoiDiemDanh : Form
    {

        /// <summary>
        /// Đây là dữ liệu ứng với Lớp học đang được chọn để hiện thị trong Datagrid view
        /// 
        /// </summary>

        private LopHoc lopHoc = null;
        private MonHoc monHoc = null;
        private List<SinhVien> danhSachSinhVien = null;
        private List<BuoiDiemDanh> danhSachBuoiDiemDanh = null;
        private List<DiemDanh> danhSachDiemDanh = null;

        public formChonBuoiDiemDanh(LopHoc lopHoc, MonHoc monHoc, List<SinhVien> danhSachSinhVien, List<BuoiDiemDanh> danhSachBuoiDiemDanh, List<DiemDanh> danhSachDiemDanh)
        {
            InitializeComponent();
            this.lopHoc = lopHoc;
            this.monHoc = monHoc;
            this.danhSachSinhVien = danhSachSinhVien;
            this.danhSachBuoiDiemDanh = danhSachBuoiDiemDanh;
            this.danhSachDiemDanh = danhSachDiemDanh;
        }

        void LoadForm()
        {
            foreach(BuoiDiemDanh bdd in this.danhSachBuoiDiemDanh)
            {
                Button btn = new Button
                {
                    Text = $"Buổi {bdd.STT}",
                    Tag = bdd,
                    Height = 70,
                    Width = 70,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += btn_Click;
                flpChonBuoiDiemDanh.Controls.Add(btn);
                
            }
            //MessageBox.Show($"Số buổi điểm danh: {this.danhSachBuoiDiemDanh.Count}");
        }

        // Xử lý khi nút được nhấn,
        private void btn_Click(object sender, EventArgs e)
        {
            int maBuoiDiemDanh = ((sender as Button).Tag as BuoiDiemDanh).MaBuoiDiemDanh;
            //MessageBox.Show(maBuoiDiemDanh.ToString());
            formChonPhuongThucDiemDanh f = new formChonPhuongThucDiemDanh(lopHoc, monHoc, danhSachSinhVien, danhSachBuoiDiemDanh, danhSachDiemDanh, maBuoiDiemDanh);
            this.Close();
            f.ShowDialog();
            

        }

        private void formChonBuoiDiemDanh_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
