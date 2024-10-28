using DiemDanhChoGV.DTO;
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

        // Phương thức thêm lớp học
        public bool ThemLopHoc(string maMonHoc, string tenLop, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            string query = "INSERT INTO LopHoc (MaMonHoc, TenLop, NgayBatDau, NgayKetThuc) VALUES (@MaMonHoc , @TenLop , @NgayBatDau , @NgayKetThuc )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maMonHoc, tenLop, ngayBatDau, ngayKetThuc });
            return result > 0;
        }

        // Phương thức cập nhật lớp học
        public bool CapNhatLopHoc(int maLopHoc, string maMonHoc, string tenLop, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            string query = "UPDATE LopHoc SET MaMonHoc = @MaMonHoc, TenLop = @TenLop , NgayBatDau = @NgayBatDau , NgayKetThuc = @NgayKetThuc WHERE MaLopHoc = @MaLopHoc ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maMonHoc, tenLop, ngayBatDau, ngayKetThuc, maLopHoc });
            return result > 0;
        }

        // Phương thức xóa lớp học
        public bool XoaLopHoc(int maLopHoc)
        {
            string query = "DELETE FROM LopHoc WHERE MaLopHoc = @MaLopHoc ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maLopHoc });
            return result > 0;
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
    }
}
