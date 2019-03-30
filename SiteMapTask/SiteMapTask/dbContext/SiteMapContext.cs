using System.Configuration;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SiteMapTask.Models;

namespace SiteMapTask.DBContext
{
    public class SiteMapContext
    {
        IMongoDatabase database;
        public SiteMapContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            database = client.GetDatabase(connection.DatabaseName);
        }
        public IMongoCollection<SiteModel> MapCollection => database.GetCollection<SiteModel>("SiteMap");

        public async Task<SiteModel> MapTask(string id)
        {
            return await MapCollection.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        public async Task Create(SiteModel c)
        {
            await MapCollection.InsertOneAsync(c);
        }
    }
}