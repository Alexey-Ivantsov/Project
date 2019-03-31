using System.Configuration;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SiteMapTask.Models;

namespace SiteMapTask.DBContext
{
    public class SiteMapContext
    {
        public IMongoDatabase database;
        public SiteMapContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            database = client.GetDatabase(connection.DatabaseName);
        }
    }
}