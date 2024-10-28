using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DAO
{
    public class DiemDanhDAO
    {
        private static DiemDanhDAO instance;

        // Phương thức truy cập Singleton
        public static DiemDanhDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiemDanhDAO();
                return instance;
            }
            private set => instance = value;
        }

        public List<DiemDanh> GetDiemDanhByMaBuoiDiemDanh(int maBuoiDiemDanh)
        {
            List<DiemDanh> listDiemDanh = new List<DiemDanh>();
            string query = "SELECT * FROM DiemDanh WHERE MaBuoiDiemDanh = @MaBuoiDiemDanh";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maBuoiDiemDanh });

            foreach (DataRow item in data.Rows)
            {
                DiemDanh diemDanh = new DiemDanh(item);
                listDiemDanh.Add(diemDanh);
            }
            return listDiemDanh;
        }


        // Phương thức thêm điểm danh
        public bool ThemDiemDanh(string maSinhVien, int maBuoiDiemDanh, int trangThai)
        {
            string query = "INSERT INTO DiemDanh (MaSinhVien, MaBuoiDiemDanh, TrangThai) VALUES (@MaSinhVien, @MaBuoiDiemDanh, @TrangThai)";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSinhVien, maBuoiDiemDanh, trangThai });
            return result > 0;
        }

        // Phương thức cập nhật điểm danh
        public bool CapNhatDiemDanh(string maSinhVien, int maBuoiDiemDanh, int trangThai)
        {
            string query = "UPDATE DiemDanh SET TrangThai = @TrangThai WHERE MaSinhVien = @MaSinhVien AND MaBuoiDiemDanh = @MaBuoiDiemDanh";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { trangThai, maSinhVien, maBuoiDiemDanh });
            return result > 0;
        }

        // Phương thức xóa điểm danh
        public bool XoaDiemDanh(string maSinhVien, int maBuoiDiemDanh)
        {
            string query = "DELETE FROM DiemDanh WHERE MaSinhVien = @MaSinhVien AND MaBuoiDiemDanh = @MaBuoiDiemDanh";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSinhVien, maBuoiDiemDanh });
            return result > 0;
        }

        public List<DiemDanh> GetDanhSachDiemDanhByMaLopHoc(int maLopHoc)
        {
            List<DiemDanh> listDiemDanh = new List<DiemDanh>();

            string query = @"
                SELECT dd.MaSinhVien, dd.MaBuoiDiemDanh, dd.TrangThai
                FROM DiemDanh dd
                JOIN BuoiDiemDanh bd ON dd.MaBuoiDiemDanh = bd.MaBuoiDiemDanh
                WHERE bd.MaLopHoc = @MaLopHoc ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLopHoc });

            foreach (DataRow row in data.Rows)
            {
                DiemDanh diemDanh = new DiemDanh(row);
                listDiemDanh.Add(diemDanh);
            }

            return listDiemDanh;
        }
    }
}
