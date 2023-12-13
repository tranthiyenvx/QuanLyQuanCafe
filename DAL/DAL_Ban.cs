using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Ban
    {
        public DataTable DanhSachBan()
        {
            return KetNoiSQL.GetData(string.Format("select * FROM Ban"));
        }
        public DataTable DanhSachTimKiem(string MaBan, string TenBan, string SoLuongNguoi, string GhiChu)
        {
            string strSQL = string.Format("select * FROM Ban WHERE MaBan LIKE N'%" + MaBan + "%' AND TenBan LIKE N'%" + TenBan + "%' AND SoLuongNguoi LIKE '%" + SoLuongNguoi + "%' AND GhiChu LIKE N'%" + GhiChu + "%'");
            return KetNoiSQL.GetData(strSQL);
        }
        public void Xoa(DTO_Ban MaBan)
        {
            string strSQL = "DELETE Ban  where MaBan = '" + MaBan.MaBan + "'";
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Sua(DTO_Ban MaBan)
        {
            string strSQL = string.Format(@"UPDATE Ban set MaBan = '" + MaBan.MaBan + "', TenBan = N'" + MaBan.TenBan + "',SoLuongNguoi = " + MaBan.SoLuongNguoi + ",GhiChu = N'" + MaBan.GhiChu + "' where MaBan = '" + MaBan.MaBan_Sua + "'");
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Them(DTO_Ban MaBan)
        {
            string strSQL = "INSERT INTO Ban(MaBan,TenBan,SoLuongNguoi,GhiChu)  VALUES ( '" + MaBan.MaBan + "',N'" + MaBan.TenBan + "'," + MaBan.SoLuongNguoi + ",N'" + MaBan.GhiChu + "')";
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public int KiemTraTrung(string MaBan)
        {
            int i = 0;
            string strSQL = "SELECT * FROM Ban WHERE MaBan = '" + MaBan + "'";
            DataTable dt = KetNoiSQL.GetData(strSQL);
            if (dt == null || dt.Rows.Count > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }
    }
}
