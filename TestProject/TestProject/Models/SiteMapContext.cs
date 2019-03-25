using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using System.Threading.Tasks;

namespace TestProject.Models
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
        public IMongoCollection<SiteMapModel> MapCollection => database.GetCollection<SiteMapModel>("SiteMap");

        public async Task<SiteMapModel> MapTask(string id)
        {
            return await MapCollection.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        public async Task Create(SiteMapModel c)
        {
            await MapCollection.InsertOneAsync(c);
        }
    }
}