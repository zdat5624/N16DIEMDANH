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
        // Phương thức lấy danh sách lớp học
        public List<LopHoc> GetDanhSachLopHoc()
        {
            List<LopHoc> listLopHoc = new List<LopHoc>();
            string query = "SELECT * FROM LopHoc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                LopHoc lopHoc = new LopHoc()
                {
                    MaLopHoc = (int)item["MaLopHoc"],
                    MaMonHoc = item["MaMonHoc"].ToString(),
                    TenLop = item["TenLop"].ToString(),
                    NgayBatDau = (DateTime)item["NgayBatDau"],
                    NgayKetThuc = (DateTime)item["NgayKetThuc"]
                };
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
    }
}
