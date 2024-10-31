using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Data;

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
            string query = @"SELECT sv.SinhVienID, sv.MaSinhVien, sv.HoTen, sv.MaLopHoc
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

        // Thêm sinh viên
        public bool ThemSinhVien(string maSinhVien, string hoTen, int maLopHoc)
        {
            string query = @"INSERT INTO SinhVien (MaSinhVien, HoTen, MaLopHoc) VALUES ( @MaSinhVien , @HoTen , @MaLopHoc )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSinhVien, hoTen, maLopHoc });
            return result > 0;
        }
    }
}
