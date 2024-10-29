using DiemDanhChoGV.DTO;
using System.Collections.Generic;
using System.Data;

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

        private DiemDanhDAO() { }

        public List<DiemDanh> GetDanhSachDiemDanhByMaLopHoc(int maLopHoc)
        {
            List<DiemDanh> listDiemDanh = new List<DiemDanh>();

            string query = @"
                SELECT dd.SinhVienID, dd.MaBuoiDiemDanh, dd.TrangThai
                FROM DiemDanh dd
                JOIN BuoiDiemDanh bd ON dd.MaBuoiDiemDanh = bd.MaBuoiDiemDanh
                WHERE bd.MaLopHoc = @MaLopHoc";

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
