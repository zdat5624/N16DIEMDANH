using System;
using System.Data;

namespace DiemDanhChoGV.DTO
{
    public class SinhVien
    {
        public int SinhVienID { get; set; }    // SinhVienID là khóa chính
        public string MaSinhVien { get; set; } // Mã sinh viên không bắt buộc
        public string HoTen { get; set; }
        public int MaLopHoc { get; set; } // Thêm thuộc tính MaLopHoc

        // Constructor
        public SinhVien(int sinhVienID, string maSinhVien, string hoTen, int maLopHoc)
        {
            SinhVienID = sinhVienID;
            MaSinhVien = maSinhVien;
            HoTen = hoTen;
            MaLopHoc = maLopHoc; // Khởi tạo MaLopHoc
        }

        public SinhVien() { }

        // Constructor từ DataRow
        public SinhVien(DataRow row)
        {
            SinhVienID = Convert.ToInt32(row["SinhVienID"]);
            MaSinhVien = row["MaSinhVien"].ToString();
            HoTen = row["HoTen"].ToString();
            MaLopHoc = Convert.ToInt32(row["MaLopHoc"]); // Lấy MaLopHoc từ DataRow
        }
    }
}
