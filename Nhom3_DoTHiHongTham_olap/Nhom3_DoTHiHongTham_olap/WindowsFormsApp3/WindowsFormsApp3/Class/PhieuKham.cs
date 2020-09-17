using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Class
{
    class PhieuKham
    {
         private string maPK ;
        private string maBN ;
        private string maNV ;
        private string mKhoa ;
        private string soPB ;
        private DateTime ngayKham ;
        private string chuanDoan;
        private string ketLuan;
        private string huongDieuTri;

        public string MaPK { get => maPK; set => maPK = value; }
        public string MaBN { get => maBN; set => maBN = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MKhoa { get => mKhoa; set => mKhoa = value; }
        public string SoPB { get => soPB; set => soPB = value; }
        public DateTime NgayKham { get => ngayKham; set => ngayKham = value; }
        public string ChuanDoan { get => chuanDoan; set => chuanDoan = value; }
        public string KetLuan { get => ketLuan; set => ketLuan = value; }
        public string HuongDieuTri { get => huongDieuTri; set => huongDieuTri = value; }
    }
}
