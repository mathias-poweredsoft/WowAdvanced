using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PoweredSoft.ObjectStorage.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace WA.Dal.Collections
{
    [MongoCollection("Test")]
    public class TestCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Value { get; set; }
        public bool IsTrusted { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
