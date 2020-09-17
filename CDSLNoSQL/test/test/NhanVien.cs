using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace test
{
    class NhanVien
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("MaNV")]
        public string MaNV { get; set; }
        [BsonElement("HoTen")]
        public string HoTen { get; set; }
        [BsonElement("Luong")]
        public double Luong { get; set; }
  
        public NhanVien()
        {

        }

        public NhanVien(string maNV, string hoTen, double luong)
        {
            MaNV = maNV;
            HoTen = hoTen;
            Luong = luong;
           
        }
    }
}
