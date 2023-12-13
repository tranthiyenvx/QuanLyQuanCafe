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
    public class BUS_Ban
    {
        public DataTable DanhSachBan()
        {
            DAL_Ban DAL = new DAL_Ban();
            return DAL.DanhSachBan();
        }
        public DataTable DanhSachTimKiem(string MaBan, string TenBan, string SoLuongNguoi, string GhiChu)
        {
            DAL_Ban DAL = new DAL_Ban();
            DataTable dtList = DAL.DanhSachTimKiem(MaBan, TenBan, SoLuongNguoi, GhiChu);
            return dtList;
        }
        public void Xoa(DTO_Ban MaBan)
        {
            DAL_Ban DAL = new DAL_Ban();
            DAL.Xoa(MaBan);
        }
        public void Sua(DTO_Ban MaBan)
        {
            DAL_Ban DAL = new DAL_Ban();
            DAL.Sua(MaBan);
        }
        public void Them(DTO_Ban MaBan)
        {
            DAL_Ban DAL = new DAL_Ban();
            DAL.Them(MaBan);
        }
        public int KiemTraTrung(string MaBan)
        {
            DAL_Ban DAL = new DAL_Ban();
            int i = DAL.KiemTraTrung(MaBan);
            return i;
        }
    }
}
