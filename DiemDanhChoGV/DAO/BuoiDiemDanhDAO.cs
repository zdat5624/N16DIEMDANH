using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DAO
{
    public class BuoiDiemDanhDAO
    {
        private static BuoiDiemDanhDAO instance;

        // Phương thức truy cập Singleton
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

        // Phương thức lấy danh sách buổi điểm danh theo mã lớp học
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


        // Phương thức thêm buổi điểm danh
        public bool ThemBuoiDiemDanh(int maLopHoc, int stt)
        {
            string query = "INSERT INTO BuoiDiemDanh (MaLopHoc, STT) VALUES (@MaLopHoc, @STT)";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maLopHoc, stt });
            return result > 0;
        }

        // Phương thức cập nhật buổi điểm danh
        public bool CapNhatBuoiDiemDanh(int maBuoiDiemDanh, int maLopHoc, int stt)
        {
            string query = "UPDATE BuoiDiemDanh SET MaLopHoc = @MaLopHoc, STT = @STT WHERE MaBuoiDiemDanh = @MaBuoiDiemDanh";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maLopHoc, stt, maBuoiDiemDanh });
            return result > 0;
        }

        // Phương thức xóa buổi điểm danh
        public bool XoaBuoiDiemDanh(int maBuoiDiemDanh)
        {
            string query = "DELETE FROM BuoiDiemDanh WHERE MaBuoiDiemDanh = @MaBuoiDiemDanh";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maBuoiDiemDanh });
            return result > 0;
        }
    }

    
}
