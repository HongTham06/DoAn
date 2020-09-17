using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace test
{
    class Lop
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("MaLop")]
        public string MaLop { get; set; }
        [BsonElement("TenLop")]
        public string TenLop { get; set; }
        [BsonElement("MaKhoa")]
        public string MaKhoa { get; set; }
        public Lop()
        {

        }
        public Lop(string maLop, string tenLop, string maKhoa)
        {
            MaLop = maLop;
            TenLop = tenLop;
            MaKhoa = maKhoa;
        }
    }
}
