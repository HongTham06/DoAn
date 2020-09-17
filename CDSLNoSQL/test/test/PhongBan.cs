using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace test
{
    class PhongBan
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("MaPH")]
        public string MaPH { get; set; }
        [BsonElement("TenPH")]
        public string TenPH { get; set; }
        public PhongBan()
        {

        }
        public PhongBan(string maPH, string tenPH)
        {
            MaPH = maPH;
            TenPH = tenPH;
        }
    }
}
