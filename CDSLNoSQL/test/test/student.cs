using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace test
{
    class student
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Ho")]
        public string Ho { get; set; }
        [BsonElement("Ten")]
        public string Ten { get; set; }
        public student()
        {

        }
        public student(string ho, string ten)
        {
            Ho = ho;
            Ten = ten;
        }
    }
}
