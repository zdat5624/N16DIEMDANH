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
    public partial class formMain : Form
    {
        private List<LopHoc> danhSachLopHoc;



        /// <summary>
        /// Đây là dữ liệu ứng với Lớp học đang được chọn để hiện thị trong Datagrid view
        /// 
        /// </summary>

        private LopHoc lopHoc = null;
        private MonHoc monHoc = null;
        private List<SinhVien> danhSachSinhVien = null;
        private List<BuoiDiemDanh> danhSachBuoiDiemDanh = null;
        private List<DiemDanh> danhSachDiemDanh = null;
        private List<SinhVienThamGiaLopHoc> danhSachSinhVienThamGiaLopHoc = null;
        
        private string kyHieuCoMat = "V";
        private string kyHieuVangMat = "X";
        private string kyHieuChuaDiemDanh = "";

        public formMain()
        {
            InitializeComponent();
            
        }

        #region Methods
        void LoadForm()
        {
            List<LopHoc> dsLopHoc = LopHocDAO.Instance.GetDanhSachLopHoc();
            LoadDanhSachLopHoc(dsLopHoc);
        }

        void LoadDanhSachLopHoc(List<LopHoc> dsLopHoc)
        {
            this.danhSachLopHoc = dsLopHoc; 
            lvDanhSachLop.Items.Clear();

            foreach (LopHoc lopHoc in danhSachLopHoc)
            {
                ListViewItem item = new ListViewItem(lopHoc.MaLopHoc.ToString());
                item.SubItems.Add(lopHoc.MaMonHoc);
                item.SubItems.Add(lopHoc.TenLop);
                lvDanhSachLop.Items.Add(item);
            }
            KhoiTaoListView();
        }

        void KhoiTaoListView()
        {
            lvDanhSachLop.Columns.Add("Mã lớp học",0);
            lvDanhSachLop.Columns.Add("Mã môn học", 90);
            lvDanhSachLop.Columns.Add("Tên lớp", 400);

            lvDanhSachLop.View = View.Details;
            lvDanhSachLop.FullRowSelect = true;
        }

        //void LoadDtgvDanhSachDiemDanh(int maLopHoc, string maMonHoc)
        //{
        //    // Lay du lieu
        //    this.monHoc = MonHocDAO.Instance.TimMonHocTheoMa(maMonHoc);
        //    this.lopHoc = LopHocDAO.Instance.GetLopHocByMaLopHoc(maLopHoc);
        //    this.danhSachSinhVien = SinhVienDAO.Instance.GetDanhSachSinhVienByMaLopHoc(maLopHoc);
        //    this.danhSachSinhVienThamGiaLopHoc = SinhVienThamGiaLopHocDAO.Instance.GetDanhSachSinhVienThamGiaLopHoc(maLopHoc);
        //    this.danhSachBuoiDiemDanh = BuoiDiemDanhDAO.Instance.GetDanhSachBuoiDiemDanhByMaLopHoc(maLopHoc);
        //    this.danhSachDiemDanh = DiemDanhDAO.Instance.GetDanhSachDiemDanhByMaLopHoc(maLopHoc);
        //    dtgvLopHoc.DataSource = danhSachSinhVien;


        //    lbTieuDe.Text = this.lopHoc.TenLop + " - " + this.monHoc.MaMonHoc + " - " + this.monHoc.TenMonHoc + " - " + this.monHoc.SoTinChi;
        //}

        void LoadDtgvDanhSachDiemDanh(int maLopHoc, string maMonHoc)
        {
            // Lấy dữ liệu
            this.monHoc = MonHocDAO.Instance.TimMonHocTheoMa(maMonHoc);
            this.lopHoc = LopHocDAO.Instance.GetLopHocByMaLopHoc(maLopHoc);
            this.danhSachSinhVien = SinhVienDAO.Instance.GetDanhSachSinhVienByMaLopHoc(maLopHoc);
            this.danhSachBuoiDiemDanh = BuoiDiemDanhDAO.Instance.GetDanhSachBuoiDiemDanhByMaLopHoc(maLopHoc);
            this.danhSachDiemDanh = DiemDanhDAO.Instance.GetDanhSachDiemDanhByMaLopHoc(maLopHoc);

            // Tạo DataTable để hiển thị
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Mã số sinh viên", typeof(string));
            dataTable.Columns.Add("Tên sinh viên", typeof(string));

            // Thêm cột tương ứng với từng buổi điểm danh
            foreach (var buoi in danhSachBuoiDiemDanh)
            {
                dataTable.Columns.Add("Buổi " + buoi.STT, typeof(string));
            }

            // Duyệt qua danh sách sinh viên và điền dữ liệu vào DataTable
            foreach (var sinhVien in danhSachSinhVien)
            {
                DataRow row = dataTable.NewRow();
                row["Mã số sinh viên"] = sinhVien.MaSinhVien;
                row["Tên sinh viên"] = sinhVien.HoTen;

                // Thêm trạng thái điểm danh cho từng buổi
                foreach (var buoi in danhSachBuoiDiemDanh)
                {
                    var diemDanh = danhSachDiemDanh
                        .FirstOrDefault(dd => dd.MaSinhVien == sinhVien.MaSinhVien && dd.MaBuoiDiemDanh == buoi.MaBuoiDiemDanh);

                    if (diemDanh != null)
                    {
                        row["Buổi " + buoi.STT] = diemDanh.TrangThai == 1 ? kyHieuCoMat : kyHieuVangMat;
                    }
                    else
                    {
                        row["Buổi " + buoi.STT] = kyHieuChuaDiemDanh;
                    }
                }

                dataTable.Rows.Add(row);
            }

            dtgvLopHoc.DataSource = dataTable;

            // Đặt tiêu đề
            lbTieuDe.Text = $"{this.lopHoc.TenLop} - {this.monHoc.MaMonHoc} - {this.monHoc.TenMonHoc} - {this.monHoc.SoTinChi} tín chỉ - {this.lopHoc.NgayBatDau.ToString("dd/MM/yyyy")} đến {this.lopHoc.NgayKetThuc.ToString("dd/MM/yyyy")}";

        }


        #endregion

        #region Events

        private void formMain_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void lvDanhSachLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Đảm bảo có item chọn
            if (lvDanhSachLop.SelectedItems.Count > 0)
            {

                ListViewItem selectedItem = lvDanhSachLop.SelectedItems[0];
                string maLopHocString = selectedItem.SubItems[0].Text;
                string maMonHoc = selectedItem.SubItems[1].Text;

                if (int.TryParse(maLopHocString, out int maLopHoc))
                {

                    MessageBox.Show("Mã lớp học được chọn: " + maLopHoc);
                    MessageBox.Show("Mã môn được chọn: " + maMonHoc);
                    LoadDtgvDanhSachDiemDanh(maLopHoc, maMonHoc);
                }

                
            }

            
        }

        #endregion
    }
}
