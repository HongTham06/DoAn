using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlapApp
{
    class TrungGiang
    {
        public static string MaNV = "";
        public static string Nhom = "";
        public void luuTen(string taiKhoan, string nhom)
        {
            MaNV = taiKhoan;
            Nhom = nhom;

        }
        public string layTen()
        {

            return MaNV;
        }
       
        public string layTen2()
        {

            return Nhom;
        }
    }
}
