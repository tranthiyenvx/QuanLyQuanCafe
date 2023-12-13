using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachHang
    {
        public DataTable DanhSachKhachHang()
        {
            return KetNoiSQL.GetData(string.Format("select * FROM KhachHang"));
        }
        public DataTable DanhSachTimKiem(string MaKH, string TenKH, string SoDienThoai, string DiaChi)
        {
            string strSQL = string.Format("select * FROM KhachHang WHERE MaKH LIKE N'%" + MaKH + "%' AND TenKH LIKE N'%" + TenKH + "%' AND SoDienThoai LIKE '%" + SoDienThoai + "%' AND DiaChi LIKE N'%" + DiaChi + "%'");
            return KetNoiSQL.GetData(strSQL);
        }
        public void Xoa(DTO_KhachHang MaKH)
        {
            string strSQL = "DELETE KhachHang  where MaKH = '" + MaKH.MaKH + "'";
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Sua(DTO_KhachHang MaKH)
        {
            string strSQL = string.Format(@"UPDATE KhachHang set MaKH = '" + MaKH.MaKH + "', TenKH = N'" + MaKH.TenKH + "',SoDienThoai = '" + MaKH.SoDienThoai + "',DiaChi = N'" + MaKH.DiaChi + "' where MaKH = '" + MaKH.MaKH_Sua + "'");
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Them(DTO_KhachHang MaKH)
        {
            string strSQL = "INSERT INTO KhachHang(MaKH,TenKH,SoDienThoai,DiaChi)  VALUES ( '" + MaKH.MaKH + "',N'" + MaKH.TenKH + "','" + MaKH.SoDienThoai + "',N'" + MaKH.DiaChi + "')";
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public int KiemTraTrung(string MaKH)
        {
            int i = 0;
            string strSQL = "SELECT * FROM KhachHang WHERE MaKH = '" + MaKH + "'";
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
