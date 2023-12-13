using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DoUong
    {
        public DataTable DanhSachDoUong()
        {
            return KetNoiSQL.GetData(string.Format("select * FROM DoUong"));
        }
        public DataTable HinhAnhDoUong(string MaDoUong)
        {
            return KetNoiSQL.GetData(string.Format("select HinhAnh FROM DoUong WHERE MaDo_Uong = '"+MaDoUong+"'"));
        }
        public DataTable DanhSachDoUongTheoGia(string MaDo_Uong)
        {
            return KetNoiSQL.GetData(string.Format("select * FROM DoUong WHERE MaDo_Uong = '"+ MaDo_Uong + "'"));
        }
        public DataTable DanhSachTimKiem(string MaDo_Uong, string TenDo_Uong, string DonGia, string SoLuongTon,string GhiChu)
        {
            string strSQL = string.Format("select * FROM DoUong WHERE MaDo_Uong LIKE N'%" + MaDo_Uong + "%' AND TenDo_Uong LIKE N'%" + TenDo_Uong + "%' AND DonGia LIKE '%" + DonGia + "%' AND SoLuongTon LIKE '%" + SoLuongTon + "%' AND GhiChu LIKE N'%" + GhiChu + "%'");
            return KetNoiSQL.GetData(strSQL);
        }
        public void Xoa(DTO_DoUong MaDo_Uong)
        {
            string strSQL = "DELETE DoUong  where MaDo_Uong = '" + MaDo_Uong.MaDo_Uong + "'";
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Sua(DTO_DoUong MaDo_Uong)
        {
            string strSQL = string.Format(@"UPDATE DoUong set MaDo_Uong = '" + MaDo_Uong.MaDo_Uong + "', TenDo_Uong = N'" + MaDo_Uong.TenDo_Uong + "',DonGia = " + MaDo_Uong.DonGia + ",SoLuongTon = " + MaDo_Uong.SoLuongTon + ",GhiChu = N'" + MaDo_Uong.GhiChu + "',HinhAnh = '"+MaDo_Uong.HinhAnh+"' where MaDo_Uong = '" + MaDo_Uong.MaDo_Uong_Sua + "'");
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Them(DTO_DoUong MaDo_Uong)
        {
            string strSQL = "INSERT INTO DoUong(MaDo_Uong,TenDo_Uong,DonGia,SoLuongTon,GhiChu,HinhAnh)  VALUES ( '" + MaDo_Uong.MaDo_Uong + "',N'" + MaDo_Uong.TenDo_Uong + "'," + MaDo_Uong.DonGia + "," + MaDo_Uong.SoLuongTon + ",N'" + MaDo_Uong.GhiChu + "','"+MaDo_Uong.HinhAnh+"')";
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public int KiemTraTrung(string MaDo_Uong)
        {
            int i = 0;
            string strSQL = "SELECT * FROM DoUong WHERE MaDo_Uong = '" + MaDo_Uong + "'";
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
