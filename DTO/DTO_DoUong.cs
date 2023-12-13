using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DoUong
    {
        public static string _MaDo_Uong;
        public static string _MaDo_Uong_Sua;
        public static string _TenDo_Uong;
        public static decimal _DonGia;
        public static decimal _SoLuongTon;
        public static string _GhiChu;
        public static string _HinhAnh;

        public string MaDo_Uong
        {
            get { return _MaDo_Uong; }
            set { _MaDo_Uong = value; }
        }
        public string MaDo_Uong_Sua
        {
            get { return _MaDo_Uong_Sua; }
            set { _MaDo_Uong_Sua = value; }
        }
        public string TenDo_Uong
        {
            get { return _TenDo_Uong; }
            set { _TenDo_Uong = value; }
        }
        public decimal DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        public decimal SoLuongTon
        {
            get { return _SoLuongTon; }
            set { _SoLuongTon = value; }
        }
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        public string HinhAnh
        {
            get { return _HinhAnh; }
            set { _HinhAnh = value; }
        }
    }
}
