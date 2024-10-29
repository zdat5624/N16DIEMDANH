using System;
using System.Data;

namespace DiemDanhChoGV.DTO
{
    public class DiemDanh
    {
        public int SinhVienID { get; set; }
        public int MaBuoiDiemDanh { get; set; }
        public int TrangThai { get; set; } // 1: Có mặt, 0: Vắng mặt

        public DiemDanh(DataRow row)
        {
            SinhVienID = (int)row["SinhVienID"];
            MaBuoiDiemDanh = (int)row["MaBuoiDiemDanh"];
            TrangThai = (int)row["TrangThai"];
        }

        public DiemDanh(int sinhVienID, int maBuoiDiemDanh, int trangThai)
        {
            SinhVienID = sinhVienID;
            MaBuoiDiemDanh = maBuoiDiemDanh;
            TrangThai = trangThai;
        }
    }
}
