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
