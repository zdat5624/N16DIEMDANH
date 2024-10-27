using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DAO
{
    public class MonHocDAO
    {
        private static MonHocDAO instance;

        public static MonHocDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MonHocDAO();
                }
                return instance;
            }
        }

        private MonHocDAO() { }

        // Phương thức thêm mới môn học
        public bool ThemMonHoc(string maMonHoc, string tenMonHoc, int soTinChi)
        {
            string query = "INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi) VALUES (@MaMonHoc , @TenMonHoc , @SoTinChi )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maMonHoc, tenMonHoc, soTinChi });
            return result > 0;
        }

        // Phương thức sửa thông tin môn học
        public bool SuaMonHoc(string maMonHoc, string tenMonHoc, int soTinChi)
        {
            string query = "UPDATE MonHoc SET TenMonHoc = @TenMonHoc , SoTinChi = @SoTinChi WHERE MaMonHoc = @MaMonHoc ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenMonHoc, soTinChi, maMonHoc });
            return result > 0;
        }

        // Phương thức xóa môn học
        public bool XoaMonHoc(string maMonHoc)
        {
            string query = "DELETE FROM MonHoc WHERE MaMonHoc = @MaMonHoc ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maMonHoc });
            return result > 0;
        }

        // Phương thức lấy danh sách tất cả môn học
        public List<MonHoc> LayDanhSachMonHoc()
        {
            List<MonHoc> danhSachMonHoc = new List<MonHoc>();
            string query = "SELECT * FROM MonHoc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                MonHoc monHoc = new MonHoc(row);
                danhSachMonHoc.Add(monHoc);
            }

            return danhSachMonHoc;
        }

        // Phương thức tìm kiếm môn học theo mã môn học
        public MonHoc TimMonHocTheoMa(string maMonHoc)
        {
            string query = "SELECT * FROM MonHoc WHERE MaMonHoc = @MaMonHoc ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maMonHoc });

            if (data.Rows.Count > 0)
            {
                return new MonHoc(data.Rows[0]);
            }

            return null;
        }
    }
}
