using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiemDanhChoGV.DTO
{
    public class MonHoc
    {
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }

        public MonHoc() { }

        public MonHoc(string maMonHoc, string tenMonHoc, int soTinChi)
        {
            MaMonHoc = maMonHoc;
            TenMonHoc = tenMonHoc;
            SoTinChi = soTinChi;
        }

        public MonHoc(DataRow row)
        {
            MaMonHoc = row["MaMonHoc"].ToString();
            TenMonHoc = row["TenMonHoc"].ToString();
            SoTinChi = Convert.ToInt32(row["SoTinChi"]);
        }
    }
}
