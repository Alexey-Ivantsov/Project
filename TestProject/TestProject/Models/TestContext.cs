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
        public IMongoCollection<dbStruct> dbStructs
        {
            get { return database.GetCollection<dbStruct>("dbStructs"); }
        }
        public async Task<dbStruct> GetComputer(string id)
        {
            return await dbStructs.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        public async Task Create(dbStruct c)
        {
            await dbStructs.InsertOneAsync(c);
        }
    }
}