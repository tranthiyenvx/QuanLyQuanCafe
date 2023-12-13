using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Ban
    {
        public static string _MaBan;
        public static string _MaBan_Sua;
        public static string _TenBan;
        public static decimal _SoLuongNguoi;
        public static string _GhiChu;

        public string MaBan
        {
            get { return _MaBan; }
            set { _MaBan = value; }
        }
        public string MaBan_Sua
        {
            get { return _MaBan_Sua; }
            set { _MaBan_Sua = value; }
        }
        public string TenBan
        {
            get { return _TenBan; }
            set { _TenBan = value; }
        }
        public decimal SoLuongNguoi
        {
            get { return _SoLuongNguoi; }
            set { _SoLuongNguoi = value; }
        }
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}
