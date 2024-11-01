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

        // Phương thức tìm kiếm môn học theo 
        public MonHoc TimMonHocTheoMonHocID(int monHocID)
        {
            string query = "SELECT * FROM MonHoc WHERE MonHocID = @monHocID ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { monHocID });

            if (data.Rows.Count > 0)
            {
                return new MonHoc(data.Rows[0]);
            }

            return null;
        }

        public int TimMonHocIDTheoTenMonHoc(string tenMonHoc)
        {
            string query = "SELECT MonHocID FROM MonHoc WHERE TenMonHoc = @tenMonHoc ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenMonHoc });

            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["MonHocID"]);
            }

            return -1;
        }

        // Phương thức để lấy tên môn học
        public string GetTenMonHoc(int monHocID)
        {
            string query = "SELECT TenMonHoc FROM MonHoc WHERE MonHocID = @monHocID";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { monHocID });

            if (data.Rows.Count > 0)
            {
                return data.Rows[0]["TenMonHoc"].ToString(); // Trả về tên môn học
            }

            return null; // Nếu không tìm thấy, trả về null hoặc giá trị mặc định
        }

        public List<MonHoc> GetDanhSachMonHoc()
        {
            List<MonHoc> list = new List<MonHoc>();
            string query = "SELECT * FROM MonHoc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new MonHoc(row));
            }

            return list;
        }

        public string GetMaMonHocByMonHocID(int monHocID)
        {
            string query = "SELECT MaMonHoc FROM MonHoc WHERE MonHocID = @monHocID ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { monHocID });

            if (data.Rows.Count > 0)
            {
                return data.Rows[0]["MaMonHoc"].ToString();
            }

            return null; // Trả về null nếu không tìm thấy
        }

        // Phương thức thêm môn học
        public bool ThemMonHoc(string maMonHoc, string tenMonHoc, int soTinChi)
        {
            string query = "INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi) VALUES ( @MaMonHoc , @TenMonHoc ,   @SoTinChi )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maMonHoc, tenMonHoc, soTinChi });
            return result > 0;
        }
        public bool KiemTraMaMonHocTonTai(string maMonHoc)
        {
            string query = "SELECT COUNT(*) FROM MonHoc WHERE MaMonHoc = @MaMonHoc ";
            int result = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { maMonHoc });
            return result > 0;
        }

        public bool DeleteMonHoc(int monHocID)
        {
            string query = "EXEC DeleteMonHoc @MonHocID ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { monHocID });
            return result > 0;
        }

        public bool UpdateMonHoc(int monHocID, string maMonHoc, string tenMonHoc, int soTinChi)
        {
            string query = "UPDATE MonHoc SET MaMonHoc = @MaMonHoc , TenMonHoc = @TenMonHoc , SoTinChi = @SoTinChi WHERE MonHocID = @MonHocID ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maMonHoc, tenMonHoc, soTinChi, monHocID });
            return result > 0;
        }

    }
}
