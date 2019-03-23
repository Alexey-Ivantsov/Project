using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestProject.Models
{
    public class TestContext
    {
        IMongoDatabase database;
        IGridFSBucket gridFS;
        public TestContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            database = client.GetDatabase(connection.DatabaseName);
            gridFS = new GridFSBucket(database);
        }
        public IMongoCollection<DbStruct> DbStructs
        {
            get { return database.GetCollection<DbStruct>("dbStructs"); }
        }
        public async Task<DbStruct> GetComputer(string id)
        {
            return await DbStructs.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        public async Task Create(DbStruct c)
        {
            await DbStructs.InsertOneAsync(c);
        }
    }
}