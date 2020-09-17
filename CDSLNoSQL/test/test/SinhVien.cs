using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace test
{
    class SinhVien
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("MaSV")]
        public string MaSV { get; set; }
        [BsonElement("HoTen")]
        public string HoTen { get; set; }
        [BsonElement("MaLop")]
        public string MaLop { get; set; }
        public SinhVien()
        {

        }

        public SinhVien(string maSV, string hoTen, string maLop)
        {
            MaSV = maSV;
            HoTen = hoTen;
            MaLop = maLop;
        }
    }
}
