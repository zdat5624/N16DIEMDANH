using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DTO
{
    public class LopHoc
    {
        public int MaLopHoc { get; set; }
        public int MonHocID { get; set; }
        public string TenLop { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public LopHoc(int maLopHoc, int monHocID, string tenLop, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            MaLopHoc = maLopHoc;
            MonHocID = monHocID;
            TenLop = tenLop;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
        }

        public LopHoc(DataRow row)
        {
            MaLopHoc = Convert.ToInt32(row["MaLopHoc"]);
            MonHocID = Convert.ToInt32(row["MonHocID"]);
            TenLop = row["TenLop"].ToString();
            NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]);
            NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]);
        }
    }
}
