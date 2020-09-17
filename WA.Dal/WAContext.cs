using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PoweredSoft.ObjectStorage.Core;
using PoweredSoft.ObjectStorage.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;
using WA.Dal.Collections;

namespace WA.Dal
{
    public class WAContext : MongoObjectStorageContext
    {
        public IObjectStorageCollection<SessionCollection> Sessions => GetCollection<SessionCollection>(); 
        public IObjectStorageCollection<TestCollection> Tests => GetCollection<TestCollection>();

        public WAContext(IConfiguration configuration) : base(GetDatabase(configuration))
        {
        }

        private static IMongoDatabase GetDatabase(IConfiguration configuration)
        {
            var connectionString = configuration["Mongo:ConnectionString"];
            var dbName = configuration["Mongo:Database"];
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            return db;
        }
    }
}
