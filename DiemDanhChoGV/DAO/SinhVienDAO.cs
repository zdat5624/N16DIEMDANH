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
        // Lấy sinh viên theo ID sinh viên
        public SinhVien GetSinhVienBySinhVienID(int sinhVienID)
        {
            string query = "SELECT * FROM SinhVien WHERE SinhVienID = @sinhVienID ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { sinhVienID });

            if (data.Rows.Count > 0)
            {
                return new SinhVien(data.Rows[0]);
            }

            return null;
        }

        // Lấy ID sinh viên theo mã số sinh viên
        public int GetSinhVienIDByMaSinhVien(string maSinhVien)
        {
            string query = "SELECT SinhVienID FROM SinhVien WHERE MaSinhVien = @maSinhVien ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maSinhVien });

            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["SinhVienID"]);
            }

            return -1;
        }
        // Kiểm tra mã sinh viên đã tồn tại
        public bool KiemTraMaSinhVienTonTai(string maSinhVien)
        {
            string query = "SELECT COUNT(*) FROM SinhVien WHERE MaSinhVien = @maSinhVien ";
            int result = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { maSinhVien });
            return result > 0;
        }
        // Thêm sinh viên
        public bool ThemSinhVien(string maSinhVien, string hoTen, int maLopHoc)
        {
            string query = @"INSERT INTO SinhVien (MaSinhVien, HoTen, MaLopHoc) VALUES ( @MaSinhVien , @HoTen , @MaLopHoc )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSinhVien, hoTen, maLopHoc });
            return result > 0;
        }

        // Cập nhật thông tin sinh viên
        public bool CapNhatSinhVien(int sinhVienID, string maSinhVien, string hoTen, int maLopHoc)
        {
            string query = "UPDATE SinhVien SET MaSinhVien = @maSinhVien , HoTen = @hoTen , MaLopHoc = @maLopHoc WHERE SinhVienID = @sinhVienID ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSinhVien, hoTen, maLopHoc, sinhVienID });
            return result > 0;
        }
        // Xóa sinh viên
        public void XoaSinhVien(int sinhVienID)
        {
            string query = "EXEC DeleteSinhVien @SinhVienID = " + sinhVienID;
            DataProvider.Instance.ExecuteScalar(query);
        }
    }
}
