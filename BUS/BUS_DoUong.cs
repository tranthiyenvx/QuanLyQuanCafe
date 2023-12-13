using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_DoUong
    {
        public DataTable DanhSachDoUong()
        {
            DAL_DoUong DAL = new DAL_DoUong();
            return DAL.DanhSachDoUong();
        }
        public DataTable DanhSachDoUongTheoGia(string MaDo_Uong)
        {
            DAL_DoUong DAL = new DAL_DoUong();
            return DAL.DanhSachDoUongTheoGia(MaDo_Uong);
        }
        public DataTable DanhSachTimKiem(string MaDo_Uong, string TenDo_Uong, string DonGia, string SoLuongTon, string GhiChu)
        {
            DAL_DoUong DAL = new DAL_DoUong();
            DataTable dtList = DAL.DanhSachTimKiem(MaDo_Uong, TenDo_Uong, DonGia, SoLuongTon, GhiChu);
            return dtList;
        }
        public void Xoa(DTO_DoUong MaDo_Uong)
        {
            DAL_DoUong DAL = new DAL_DoUong();
            DAL.Xoa(MaDo_Uong);
        }
        public void Sua(DTO_DoUong MaDo_Uong)
        {
            DAL_DoUong DAL = new DAL_DoUong();
            DAL.Sua(MaDo_Uong);
        }
        public void Them(DTO_DoUong MaDo_Uong)
        {
            DAL_DoUong DAL = new DAL_DoUong();
            DAL.Them(MaDo_Uong);
        }
        public int KiemTraTrung(string MaDo_Uong)
        {
            DAL_DoUong DAL = new DAL_DoUong();
            int i = DAL.KiemTraTrung(MaDo_Uong);
            return i;
        }
        public DataTable HinhAnhDoUong(string MaDo_Uong)
        {
            DAL_DoUong DAL = new DAL_DoUong();
            return DAL.HinhAnhDoUong(MaDo_Uong);
        }
    }
}
