using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiemDanhChoGV.DAO;
using DiemDanhChoGV.DTO;
using Newtonsoft.Json.Linq;
namespace XuLyGPS
{
    public partial class formWebGps : Form
    {
        private HttpListener listener;

        private double myLatitude = 21.028511; // Vĩ độ của bạn
        private double myLongitude = 105.804817; // Kinh độ của bạn

        private int portNumber = 5000;
        private int maBuoiDiemDanh;
        private LopHoc lopHoc = null;
        private MonHoc monHoc = null;
        private List<SinhVien> danhSachSinhVien = null;
        private List<BuoiDiemDanh> danhSachBuoiDiemDanh = null;
        private List<DiemDanh> danhSachDiemDanh = null;

        public formWebGps(LopHoc lopHoc, MonHoc monHoc, List<SinhVien> danhSachSinhVien, List<BuoiDiemDanh> danhSachBuoiDiemDanh, List<DiemDanh> danhSachDiemDanh, int maBuoiDiemDanh)
        {
            InitializeComponent();
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:"+portNumber+"/api/attendance/");
            listener.Start();

            this.lopHoc = lopHoc;
            this.monHoc = monHoc;
            this.danhSachSinhVien = danhSachSinhVien;
            this.danhSachBuoiDiemDanh = danhSachBuoiDiemDanh;
            this.danhSachDiemDanh = danhSachDiemDanh;
            this.maBuoiDiemDanh = maBuoiDiemDanh;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dtgvDiemDanh.Columns.Clear();
            dtgvDiemDanh.AutoGenerateColumns = false;

            // Cột Mã số sinh viên
            DataGridViewTextBoxColumn maSVColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã số sinh viên",
                DataPropertyName = "MaSinhVien",
                Name = "MSSV",
                Width = 150,
                ReadOnly = true
            };
            dtgvDiemDanh.Columns.Add(maSVColumn);

            // Cột Tên sinh viên
            DataGridViewTextBoxColumn tenSVColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sinh viên",
                DataPropertyName = "HoTen",
                Name = "Ten",
                Width = 250,
                ReadOnly = true
            };
            dtgvDiemDanh.Columns.Add(tenSVColumn);

            // Cột Có mặt
            DataGridViewCheckBoxColumn coMatColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Có mặt",
                Name = "coMat",
                Width = 80
            };
            dtgvDiemDanh.Columns.Add(coMatColumn);

           

            // Duyệt qua danh sách sinh viên để thêm vào DataGridView
            foreach (var sinhVien in danhSachSinhVien)
            {
                // Kiểm tra xem sinh viên đã điểm danh hay chưa
                var diemDanh = danhSachDiemDanh.FirstOrDefault(dd => dd.SinhVienID == sinhVien.SinhVienID && dd.MaBuoiDiemDanh == maBuoiDiemDanh);

                bool coMat = diemDanh != null && diemDanh.TrangThai == 1; // Giả sử TrangThai = 1 là có mặt
                bool vangMat = diemDanh != null && diemDanh.TrangThai == 0; // Giả sử TrangThai = 0 là vắng mặt

                dtgvDiemDanh.Rows.Add(sinhVien.MaSinhVien, sinhVien.HoTen, coMat, vangMat);
            }
        }

        private async void ListenForAttendance()
        {

            while (listener.IsListening)
            {
                var context = await listener.GetContextAsync();
                var request = context.Request;
                double distance = 0;

                if (request != null)
                {

                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        string json = reader.ReadToEnd();
                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            // Chỉ hiển thị chuỗi JSON không rỗng
                            JObject data = JObject.Parse(json);
                            double studentLatitude = (double)data["latitude"];
                            double studentLongitude = (double)data["longitude"];
                            string mssv = (string)data["mssv"];
                            distance = CalculateDistance(myLatitude, myLongitude, studentLatitude, studentLongitude);

                            int sinhVienID = GetSinhVienIDbyMaSinhVien(mssv);
                            if(sinhVienID != -1)
                            {
                                UpdateAttendanceStatus(mssv, true);
                            }
                        }
                    }

                    
                    var response = context.Response;
                    string responseString = distance < 0.5?"{\"status\":\"OK\"}": "{\"status\":\"err\"}";

                    response.Headers.Add("Access-Control-Allow-Origin", "https://dat9999999.github.io");
                    response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                    response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    response.OutputStream.Close();
                }
            }
        }
        private void UpdateAttendanceStatus(string mssv, bool isPresent)
        {
            foreach (DataGridViewRow row in dtgvDiemDanh.Rows)
            {
                if (row.Cells["MSSV"].Value.ToString() == mssv)
                {
                    row.Cells["coMat"].Value = isPresent;
                    break;
                }
            }
        }

        // Hàm tính khoảng cách giữa hai tọa độ
        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Bán kính Trái Đất (km)
            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private async void formWebGps_Load(object sender, EventArgs e)
        {
            
            await Task.Run(() => ListenForAttendance());
        }

        private void formWebGps_FormClosed(object sender, FormClosedEventArgs e)
        {
            listener.Prefixes.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgvDiemDanh.Rows)
            {

                string maSinhVien = (row.Cells["MSSV"].Value).ToString();
                int sinhVienID = GetSinhVienIDbyMaSinhVien(maSinhVien);
                int maBuoiDiemDanh = this.maBuoiDiemDanh; // Lấy mã buổi điểm danh hiện tại

                if (sinhVienID == -1)
                {
                    return;
                }

                // Kiểm tra trạng thái
                int? trangThai = 0; // Mặc định là 0
                if (row.Cells["coMat"].Value != null && (bool)row.Cells["coMat"].Value == true)
                {
                    trangThai = 1; // Có mặt
                }
                DiemDanhDAO.Instance.LuuDiemDanh(maBuoiDiemDanh, sinhVienID, trangThai);
            }
            MessageBox.Show("Điểm danh đã được lưu.");
        }

        public int GetSinhVienIDbyMaSinhVien(string maSinhVien)
        {
            foreach (SinhVien sv in danhSachSinhVien)
            {
                if ((sv.MaSinhVien).Equals(maSinhVien))
                {
                    return sv.SinhVienID;
                }
            }
            return -1;
        }
    }
}
