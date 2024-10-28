using System;
using System.Data;

namespace DiemDanhChoGV.DTO
{
    public class BuoiDiemDanh
    {
        public int MaBuoiDiemDanh { get; set; }
        public int MaLopHoc { get; set; }
        public int STT { get; set; }


        public BuoiDiemDanh(DataRow row)
        {
            MaBuoiDiemDanh = (int)row["MaBuoiDiemDanh"];
            MaLopHoc = (int)row["MaLopHoc"];
            STT = (int)row["STT"];
        }
    }
}
