using DiemDanhChoGV.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DTO
{
    public class DiemDanh
    {
        public string MaSinhVien { get; set; }
        public int MaBuoiDiemDanh { get; set; }
        public int TrangThai { get; set; } // 1: Có mặt, 0: Vắng mặt

        public DiemDanh(DataRow row)
        {
            MaSinhVien = row["MaSinhVien"].ToString();
            MaBuoiDiemDanh = (int)row["MaBuoiDiemDanh"];
            TrangThai = (int)row["TrangThai"];
        }

        public DiemDanh(string maSinhVien, int maBuoiDiemDanh, int trangThai)
        {
            MaSinhVien = maSinhVien;
            MaBuoiDiemDanh = maBuoiDiemDanh;
            TrangThai = trangThai;
        }

        
    }
}
