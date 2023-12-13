using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThongKe
    {
        public DataTable XemLaiHoaDon(DateTime ngay1, DateTime ngay2, string MaBan)
        {
            string strSQL = "SELECT NgayHoaDon,TenBan,TenKH,TenDo_Uong,a.DonGia,a.SoLuong,ThanhTien ";
            strSQL += "FROM HoaDon a LEFT JOIN Ban b ON a.MaBan = b.MaBan ";
            strSQL += "LEFT JOIN KhachHang c ON a.MaKH = c.MaKH ";
            strSQL += "LEFT JOIN DoUong d ON a.MaDo_Uong = d.MaDo_Uong ";
            strSQL += " WHERE CONVERT(DATETIME, NgayHoaDon,103) BETWEEN CONVERT(DATETIME, '" + ngay1 + "',103) AND CONVERT(DATETIME, '" + ngay2 + "',103) AND a.MaBan ='" + MaBan + "' AND TrangThai = '1'";
            return KetNoiSQL.GetData(strSQL);
        }
        public DataTable ThongKeDoanhThu(DateTime ngay1, DateTime ngay2)
        {
            string strSQL = "SELECT SUM(ThanhTien) AS ThanhTien,NgayHoaDon,TenBan FROM HoaDon a LEFT JOIN Ban b ON a.MaBan = b.MaBan WHERE CONVERT(DATETIME, NgayHoaDon,103) BETWEEN CONVERT(DATETIME, '" + ngay1 + "',103) AND CONVERT(DATETIME, '" + ngay2 + "',103) AND TrangThai = '1' GROUP BY NgayHoaDon,TenBan ";
            return KetNoiSQL.GetData(strSQL);
        }
        public DataTable ThongKeDoanhThuNhanVien(DateTime ngay1, DateTime ngay2)
        {
            string strSQL = "SELECT a.MaTK_NV,b.TenTK_NV,SUM(ThanhTien) as ThanhTien FROM HoaDon a INNER JOIN TaiKhoan_NhanVien b ON a.MaTK_NV = b.MaTK_NV  WHERE CONVERT(DATETIME, NgayHoaDon,103) BETWEEN CONVERT(DATETIME, '" + ngay1 + "',103) AND CONVERT(DATETIME, '" + ngay2 + "',103) AND TrangThai = '1' GROUP BY a.MaTK_NV,b.TenTK_NV ";
            return KetNoiSQL.GetData(strSQL);
        }
        public DataTable ThongKeHangHoaBanRa(DateTime ngay1, DateTime ngay2)
        {
            string strSQL = "SELECT a.MaDo_Uong,b.TenDo_Uong,SUM(SoLuong) AS SoLuong FROM HoaDon a INNER JOIN DoUong b ON a.MaDo_Uong = b.MaDo_Uong  WHERE CONVERT(DATETIME, NgayHoaDon,103) BETWEEN CONVERT(DATETIME, '" + ngay1 + "',103) AND CONVERT(DATETIME, '" + ngay2 + "',103) AND TrangThai = '1' GROUP BY a.MaDo_Uong,b.TenDo_Uong ORDER BY SoLuong DESC ";
            return KetNoiSQL.GetData(strSQL);
        }
    }
}
