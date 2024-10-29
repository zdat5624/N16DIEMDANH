using System;
using System.Data;

namespace DiemDanhChoGV.DTO
{
    public class SinhVien
    {
        public int SinhVienID { get; set; }    // SinhVienID là khóa chính
        public string MaSinhVien { get; set; } // Mã sinh viên không bắt buộc
        public string HoTen { get; set; }

        public SinhVien(int sinhVienID, string maSinhVien, string hoTen)
        {
            SinhVienID = sinhVienID;
            MaSinhVien = maSinhVien;
            HoTen = hoTen;
        }

        public SinhVien(DataRow row)
        {
            SinhVienID = Convert.ToInt32(row["SinhVienID"]);
            MaSinhVien = row["MaSinhVien"].ToString();
            HoTen = row["HoTen"].ToString();
        }
    }
}
