using DiemDanhChoGV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DAO
{
    public class SinhVienThamGiaLopHocDAO
    {
        private static SinhVienThamGiaLopHocDAO instance;

        // Phương thức truy cập Singleton
        public static SinhVienThamGiaLopHocDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SinhVienThamGiaLopHocDAO();
                return instance;
            }
            private set => instance = value;
        }

        // Phương thức lấy danh sách sinh viên tham gia lớp học theo mã lớp học
        public List<SinhVienThamGiaLopHoc> GetDanhSachSinhVienThamGiaLopHoc(int maLopHoc)
        {
            List<SinhVienThamGiaLopHoc> listSinhVienThamGia = new List<SinhVienThamGiaLopHoc>();
            string query = "SELECT * FROM SinhVienThamGiaLopHoc WHERE MaLopHoc = @MaLopHoc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLopHoc });
            foreach (DataRow item in data.Rows)
            {
                SinhVienThamGiaLopHoc sinhVienThamGia = new SinhVienThamGiaLopHoc()
                {
                    MaSinhVien = item["MaSinhVien"].ToString(),
                    MaLopHoc = (int)item["MaLopHoc"]
                };
                listSinhVienThamGia.Add(sinhVienThamGia);
            }
            return listSinhVienThamGia;
        }

        // Phương thức thêm sinh viên tham gia lớp học
        public bool ThemSinhVienThamGiaLopHoc(string maSinhVien, int maLopHoc)
        {
            string query = "INSERT INTO SinhVienThamGiaLopHoc (MaSinhVien, MaLopHoc) VALUES (@MaSinhVien, @MaLopHoc)";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSinhVien, maLopHoc });
            return result > 0;
        }

        // Phương thức xóa sinh viên tham gia lớp học
        public bool XoaSinhVienThamGiaLopHoc(string maSinhVien, int maLopHoc)
        {
            string query = "DELETE FROM SinhVienThamGiaLopHoc WHERE MaSinhVien = @MaSinhVien AND MaLopHoc = @MaLopHoc";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSinhVien, maLopHoc });
            return result > 0;
        }
    }
}
