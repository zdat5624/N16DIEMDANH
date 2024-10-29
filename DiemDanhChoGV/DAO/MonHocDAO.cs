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

    }
}
