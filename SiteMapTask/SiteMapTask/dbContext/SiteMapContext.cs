using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
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

        public async Task<IEnumerable<SiteModel>> GetMapTask()
        {
            var builder = new FilterDefinitionBuilder<SiteModel>();
            var filter = builder.Empty;
            return await MapCollection.Find(filter).ToListAsync();
        }
        public async Task Create(SiteModel c)
        {
            c.NameSite = c.Url;
            await MapCollection.InsertOneAsync(c);
        }
    }
}