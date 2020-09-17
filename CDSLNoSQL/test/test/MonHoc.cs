using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace test
{
    class MonHoc
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("MaMH")]
        public string MaMH { get; set; }
        [BsonElement("TenMH")]
        public string TenMH { get; set; }
        [BsonElement("SoTC")]
        public double SoTC { get; set; }
        public MonHoc()
        {

        }

        public MonHoc(string maMH, string tenMH, double soTC)
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoTC = soTC;
        }
    }
}
