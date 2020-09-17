using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PoweredSoft.ObjectStorage.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace WA.Dal.Collections
{
    [MongoCollection("Session")]
    public class SessionCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Ip { get; set; }
        public string Key { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Prime { get; set; }
    }
}
