using System;
using System.Collections.Generic;
using System.Data;

namespace DiemDanhChoGV.DTO
{
    public class MonHoc
    {
        public int MonHocID { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }

        public MonHoc(int monHocID, string maMonHoc, string tenMonHoc, int soTinChi)
        {
            MonHocID = monHocID;
            MaMonHoc = maMonHoc;
            TenMonHoc = tenMonHoc;
            SoTinChi = soTinChi;
        }

        public MonHoc(DataRow row)
        {
            MonHocID = Convert.ToInt32(row["MonHocID"]);
            MaMonHoc = row["MaMonHoc"].ToString();
            TenMonHoc = row["TenMonHoc"].ToString();
            SoTinChi = Convert.ToInt32(row["SoTinChi"]);
        }
    }
}
