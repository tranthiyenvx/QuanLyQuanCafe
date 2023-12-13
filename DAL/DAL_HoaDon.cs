using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoaDon
    {
        public DataTable Table_No()
        {
            string strSQL = "SELECT MaBan,TenBan FROM Ban  WHERE MaBan NOT IN (SELECT MaBan FROM HoaDon WHERE TrangThai = '0')";
            strSQL = strSQL + "UNION ALL ";
            strSQL = strSQL + "SELECT a.MaBan,TenBan FROM HoaDon a INNER JOIN Ban b ON a.MaBan = b.MaBan ";
            strSQL = strSQL + "WHERE TrangThai = '1' AND a.MaBan NOT IN (SELECT MaBan FROM Ban) ";
            return KetNoiSQL.GetData(strSQL);
        }
        public DataTable Table_Yes()
        {
            string strSQL = "SELECT DISTINCT a.MaBan,TenBan FROM HoaDon a INNER JOIN Ban b ON a.MaBan = b.MaBan WHERE TrangThai = '0'";
            return KetNoiSQL.GetData(strSQL);
        }
        public DataTable HoaDonTheoMa(string MaHD)
        {
            string strSQL = "SELECT * FROM  HoaDon  WHERE MaHD = '" + MaHD + "'";
            return KetNoiSQL.GetData(strSQL);
        }
        public DataTable DanhSachHoaDon(string MaBan)
        {
            string strSQL = "SELECT MaHD,HinhAnh,TenDo_Uong,a.DonGia,SoLuong,ThanhTien FROM  HoaDon a LEFT JOIN DoUong b ON a.MaDo_Uong = b.MaDo_Uong WHERE a.MaBan = '" + MaBan + "' AND TrangThai = '0'";
            return KetNoiSQL.GetData(strSQL);
        }
        public DataTable InHoaDon(string MaBan)
        {
            string strSQL = "SELECT TenDo_Uong as TenHH,SoLuong,a.DonGia,ThanhTien FROM  HoaDon a LEFT JOIN DoUong b ON a.MaDo_Uong = b.MaDo_Uong WHERE a.MaBan = '" + MaBan + "' AND TrangThai = '0'";
            return KetNoiSQL.GetData(strSQL);
        }
        public DataTable InHoaDonThongTinChung(string MaBan)
        {
            string strSQL = "SELECT TenKH,TenTK_NV,NgayHoaDon FROM  HoaDon a LEFT JOIN KhachHang b ON a.MaKH = b.MaKH LEFT JOIN TaiKhoan_NhanVien c ON a.MaTK_NV = c.MaTK_NV WHERE a.MaBan = '" + MaBan + "' AND TrangThai = '0'";
            return KetNoiSQL.GetData(strSQL);
        }
        public void Them(DTO_HoaDon HoaDon,string SLTon)
        {
            string strSQL = "INSERT INTO HoaDon(MaHD,MaBan,MaKH,MaTK_NV,NgayHoaDon,MaDo_Uong,DonGia,SoLuong,ThanhTien,TrangThai)  VALUES ";
            strSQL = strSQL + "('" + HoaDon.MaHD + "', '" + HoaDon.MaBan + "','" + HoaDon.MaKH + "','" + HoaDon.MaTK_NV + "',GETDATE(),'"+HoaDon.MaDo_Uong+"',"+ HoaDon.DonGia +","+ HoaDon.SoLuong +","+ HoaDon.ThanhTien +",'0')";

            strSQL = strSQL + " ; update DoUong set SoLuongTon = SoLuongTon - "+ SLTon + " WHERE MaDo_Uong = '"+HoaDon.MaDo_Uong+"'";
            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Sua(DTO_HoaDon HoaDon,string SLTonold,string SLTonnew)
        {
            string strSQL = string.Format(@"UPDATE HoaDon set MaDo_Uong = '" + HoaDon.MaDo_Uong + "',DonGia = " + HoaDon.DonGia + ",SoLuong = " + HoaDon.SoLuong + " where MaHD = '" + HoaDon.MaHD + "'");
            strSQL = strSQL + " ; update DoUong set SoLuongTon = SoLuongTon + " + SLTonold + " WHERE MaDo_Uong = '" + HoaDon.MaDo_Uong + "'";
            strSQL = strSQL + " ; update DoUong set SoLuongTon = SoLuongTon - " + SLTonnew + " WHERE MaDo_Uong = '" + HoaDon.MaDo_Uong + "'";

            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public void Xoa(DTO_HoaDon HoaDon,string SLTon)
        {
            string strSQL = "DELETE HoaDon WHERE MAHD = '"+ HoaDon.MaHD+ "' ";

            strSQL = strSQL + " ; update DoUong set SoLuongTon = SoLuongTon + " + SLTon + " WHERE MaDo_Uong = '" + HoaDon.MaDo_Uong + "'";

            KetNoiSQL.ExecuteNonQuery(strSQL);
        }
        public DataTable KiemTraSoLuongTon(string MaDoUong)
        {
            string strSQL = "SELECT * FROM  DoUong  WHERE MaDo_Uong = '" + MaDoUong + "'";
            return KetNoiSQL.GetData(strSQL);
        }
    }
}
