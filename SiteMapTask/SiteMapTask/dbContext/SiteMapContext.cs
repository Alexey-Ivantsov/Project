using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SiteMapTask.Models;

namespace SiteMapTask.DBContext
{
    public class SiteMapContext
    {
        public readonly IMongoCollection<SiteModel> _mapCollection;
        public SiteMapContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase(connection.DatabaseName);
            _mapCollection = database.GetCollection<SiteModel>("SiteMap");
        }
        public async Task Create(SiteModel c)
        {
            await _mapCollection.InsertOneAsync(c);
        }
        public async Task Edit(SiteModel editedSite)
        {
            await _mapCollection.ReplaceOneAsync(new BsonDocument("_id", editedSite.Id), editedSite);
        }
        public List<SiteModel> GetListSite()
        {
            List<SiteModel> siteList = _mapCollection.AsQueryable().ToList();
            var sortedList = siteList.OrderBy(t => t.TimeMini).ToList();
            return sortedList;
        }
    }
}