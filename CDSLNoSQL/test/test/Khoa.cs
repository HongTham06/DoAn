using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace test
{
    class Khoa
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("MaKhoa")]
        public string MaKhoa { get; set; }
        [BsonElement("TenKhoa")]
        public string TenKhoa { get; set; }
        public Khoa()
        {

        }
        public Khoa(string maKhoa, string tenKhoa)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
        }
    }
}
