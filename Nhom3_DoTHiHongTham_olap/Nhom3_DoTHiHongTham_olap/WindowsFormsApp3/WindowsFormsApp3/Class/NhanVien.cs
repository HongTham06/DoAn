using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Class
{
    class NhanVien
    {
        private string maNV;
        private string tenNV;
        private string maKhoa;
        private string kVCongTac;

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string KVCongTac { get => kVCongTac; set => kVCongTac = value; }
    }
 }
