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
                WHERE bd.MaLopHoc = @MaLopHoc ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLopHoc });

            foreach (DataRow row in data.Rows)
            {
                DiemDanh diemDanh = new DiemDanh(row);
                listDiemDanh.Add(diemDanh);
            }

            return listDiemDanh;
        }

        public void LuuDiemDanh(int maBuoiDiemDanh, int sinhVienID, int? trangThai)
        {
            string query;

            // Nếu trạng thái là null, chúng ta cần xóa điểm danh
            if (trangThai == null)
            {
                query = @" EXEC DeleteDiemDanh @SinhVienID , @MaBuoiDiemDanh ";
            }
            else
            {
                // Thêm mới hoặc cập nhật điểm danh
                query = @" EXEC UpsertDiemDanh @SinhVienID , @MaBuoiDiemDanh , @TrangThai ";

            }

            DataProvider.Instance.ExecuteNonQuery(query, new object[] { sinhVienID, maBuoiDiemDanh, trangThai });
        }


    }
}
