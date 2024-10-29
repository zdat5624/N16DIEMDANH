using DiemDanhChoGV.DTO;
using System.Collections.Generic;
using System.Data;

namespace DiemDanhChoGV.DAO
{
    public class BuoiDiemDanhDAO
    {
        private static BuoiDiemDanhDAO instance;

        public static BuoiDiemDanhDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BuoiDiemDanhDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BuoiDiemDanhDAO() { }

        public List<BuoiDiemDanh> GetDanhSachBuoiDiemDanhByMaLopHoc(int maLopHoc)
        {
            List<BuoiDiemDanh> listBuoiDiemDanh = new List<BuoiDiemDanh>();
            string query = "SELECT * FROM BuoiDiemDanh WHERE MaLopHoc = @MaLopHoc ORDER BY STT";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLopHoc });
            foreach (DataRow item in data.Rows)
            {
                BuoiDiemDanh buoiDiemDanh = new BuoiDiemDanh(item);
                listBuoiDiemDanh.Add(buoiDiemDanh);
            }
            return listBuoiDiemDanh;
        }
    }
}
