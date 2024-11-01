﻿using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DAO
{
    public class LopHocDAO
    {
        private static LopHocDAO instance;

        // Phương thức truy cập Singleton
        public static LopHocDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LopHocDAO();
                return instance;
            }
            private set => instance = value;
        }
        private LopHocDAO() { }

        // Phương thức lấy danh sách lớp học
        public List<LopHoc> GetDanhSachLopHoc()
        {
            List<LopHoc> listLopHoc = new List<LopHoc>();
            string query = "SELECT * FROM LopHoc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                LopHoc lopHoc = new LopHoc(item);
                listLopHoc.Add(lopHoc);
            }
            return listLopHoc;
        }

        public LopHoc GetLopHocByMaLopHoc(int maLopHoc)
        {
            LopHoc lopHoc = null;
            string query = "SELECT * FROM LopHoc WHERE MaLopHoc = @MaLopHoc ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLopHoc });

            if (data.Rows.Count > 0)
            {
                DataRow item = data.Rows[0];
                lopHoc = new LopHoc(item);
            }

            return lopHoc;
        }
        public void DeleteLopHoc(int maLop)
        {
            string query = "EXEC DeleteLopHoc @MaLopHoc = "+ maLop;
            DataProvider.Instance.ExecuteScalar(query);
        }

        public int ThemLopHocVaLayID(string tenLop, int monHocID, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            string query = "INSERT INTO LopHoc (TenLop, MonHocID, NgayBatDau, NgayKetThuc) " +
                           "OUTPUT INSERTED.MaLopHoc " +
                           "VALUES ( @TenLop , @MonHocID , @NgayBatDau , @NgayKetThuc )";

            try
            {
                // Thực hiện truy vấn và lấy kết quả
                object result = DataProvider.Instance.ExecuteScalar(query, new object[] { tenLop, monHocID, ngayBatDau, ngayKetThuc });

                // Chuyển đổi kết quả sang int và trả về LopHocID nếu thành công, -1 nếu thất bại
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi chi tiết nếu có vấn đề xảy ra
                Console.WriteLine("Lỗi khi thêm lớp học: " + ex.Message);
                return -1;
            }
        }

        public bool UpdateLopHoc(int maLopHoc, string tenLop, int monHocID, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            string query = "UPDATE LopHoc SET TenLop = @tenLop , MonHocID = @monHocID , NgayBatDau = @ngayBatDau , NgayKetThuc = @ngayKetThuc WHERE MaLopHoc = @maLopHoc ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenLop, monHocID, ngayBatDau, ngayKetThuc, maLopHoc });
            return result > 0;
        }
    }
}
