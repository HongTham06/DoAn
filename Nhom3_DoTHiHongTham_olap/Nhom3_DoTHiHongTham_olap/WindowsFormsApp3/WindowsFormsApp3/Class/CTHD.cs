using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Class
{
    class CTHD
    {
        private string maHD;
        private string tenThuoc;
        private int sL ;
        private float donGiaXuat ;

        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        public string TenThuoc
        {
            get { return tenThuoc; }
            set { tenThuoc = value; }
        }
        public int SL
        {
            get { return sL; }
            set { sL = value; }
        }
        public float DonGiaXuat
        {
            get { return donGiaXuat; }
            set { donGiaXuat = value; }
        }
    }
}
