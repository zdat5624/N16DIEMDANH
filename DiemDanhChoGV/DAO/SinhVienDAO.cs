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

        // Phương thức lấy danh sách sinh viên
        public List<SinhVien> GetDanhSachSinhVien()
        {
            List<SinhVien> listSinhVien = new List<SinhVien>();
            string query = "SELECT * FROM SinhVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                SinhVien sinhVien = new SinhVien(item);
                listSinhVien.Add(sinhVien);
            }
            return listSinhVien;
        }

        // Phương thức thêm sinh viên
        public bool ThemSinhVien(string maSinhVien, string hoTen)
        {
            string query = "INSERT INTO SinhVien (MaSinhVien, HoTen) VALUES (@MaSinhVien , @HoTen)";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSinhVien, hoTen });
            return result > 0;
        }

        // Phương thức cập nhật sinh viên
        public bool CapNhatSinhVien(string maSinhVien, string hoTen)
        {
            string query = "UPDATE SinhVien SET HoTen = @HoTen WHERE MaSinhVien = @MaSinhVien";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { hoTen, maSinhVien });
            return result > 0;
        }

        // Phương thức xóa sinh viên
        public bool XoaSinhVien(string maSinhVien)
        {
            string query = "DELETE FROM SinhVien WHERE MaSinhVien = @MaSinhVien";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSinhVien });
            return result > 0;
        }

        public List<SinhVien> GetDanhSachSinhVienByMaLopHoc(int maLopHoc)
        {
            List<SinhVien> listSinhVien = new List<SinhVien>();
            string query = @"SELECT sv.MaSinhVien, sv.HoTen 
                     FROM SinhVien sv
                     JOIN SinhVienThamGiaLopHoc svlh ON sv.MaSinhVien = svlh.MaSinhVien
                     WHERE svlh.MaLopHoc = @MaLopHoc ";

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
