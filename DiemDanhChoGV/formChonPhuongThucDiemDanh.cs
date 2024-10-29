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
    public partial class formChonPhuongThucDiemDanh : Form
    {
        private int maBuoiDiemDanh;
        private LopHoc lopHoc = null;
        private MonHoc monHoc = null;
        private List<SinhVien> danhSachSinhVien = null;
        private List<BuoiDiemDanh> danhSachBuoiDiemDanh = null;
        private List<DiemDanh> danhSachDiemDanh = null;

        public formChonPhuongThucDiemDanh(LopHoc lopHoc, MonHoc monHoc, List<SinhVien> danhSachSinhVien, List<BuoiDiemDanh> danhSachBuoiDiemDanh, List<DiemDanh> danhSachDiemDanh, int maBuoiDiemDanh)
        {
            InitializeComponent();
            this.lopHoc = lopHoc;
            this.monHoc = monHoc;
            this.danhSachSinhVien = danhSachSinhVien;
            this.danhSachBuoiDiemDanh = danhSachBuoiDiemDanh;
            this.danhSachDiemDanh = danhSachDiemDanh;
            this.maBuoiDiemDanh = maBuoiDiemDanh;
        }

        private void btnDiemDanhThuCong_Click(object sender, EventArgs e)
        {
            formDiemDanhThuCong f = new formDiemDanhThuCong(lopHoc, monHoc, danhSachSinhVien, danhSachBuoiDiemDanh, danhSachDiemDanh, maBuoiDiemDanh);
            this.Close();
            f.ShowDialog();
            
        }
    }
}
