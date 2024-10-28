using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DTO
{
    public class SinhVien
    {
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }

        public SinhVien(string maSinhVien, string hoTen)
        {
            MaSinhVien = maSinhVien;
            HoTen = hoTen;
        }

        public SinhVien(DataRow row)
        {
            MaSinhVien = row["MaSinhVien"].ToString();
            HoTen = row["HoTen"].ToString();
        }
    }
}
