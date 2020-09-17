using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Class
{
    class HoaDon
    {
       private string maHD ;
       private DateTime ngayLap ;
       private string maBN ;
        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        public string MaBN
        {
            get { return maBN; }
            set { maBN = value; }
        }
        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
    }
}
