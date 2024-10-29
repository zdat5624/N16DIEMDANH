using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DAO
{
    public class SinhVienDAO
    {
        private static SinhVienDAO instance;

        // Phương thức truy cập Singleton
        public static SinhVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SinhVienDAO();
                return instance;
            }
            private set => instance = value;
        }

        private SinhVienDAO() { }

        // Lấy danh sách sinh viên theo Mã Lớp Học
        public List<SinhVien> GetDanhSachSinhVienByMaLopHoc(int maLopHoc)
        {
            List<SinhVien> listSinhVien = new List<SinhVien>();
            string query = @"SELECT sv.SinhVienID, sv.MaSinhVien, sv.HoTen
                             FROM SinhVien sv
                             WHERE sv.MaLopHoc = @MaLopHoc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLopHoc });
            foreach (DataRow item in data.Rows)
            {
                SinhVien sinhVien = new SinhVien(item);
                listSinhVien.Add(sinhVien);
            }
            return listSinhVien;
        }
    }
}
