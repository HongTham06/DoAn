using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace test
{
    class DocGia
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Id_DG")]
        public string Id_DG { get; set; }
        [BsonElement("Id_TheTV")]
        public string Id_TheTV { get; set; }
        [BsonElement("SDTDG")]
        public string SDTDG { get; set; }

        public DocGia()
        {

        }
        public DocGia(string id_DG, string id_TheTV, string sDTDG)
        {
            Id_DG = id_DG;
            Id_TheTV = id_TheTV;
            SDTDG = sDTDG;
        }
    }
}
