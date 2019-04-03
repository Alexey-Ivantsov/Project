using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
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
        public SiteModel GetSiteModel(string nameSite)
        {
            String[] values = File.ReadAllText("https://www.arcticpaper.com/sitemap.xml").Split('>');
            var getModel = _mapCollection.Find(new BsonDocument("NameSite", nameSite)).FirstOrDefault();
            return getModel;
        }
        public bool ValidationSiteMap(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string[] values = client.DownloadString(url + "/sitemap.xml").Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    return values.Any(x => x.Contains(url));
                }
                catch { return false; }
            }
        }
    }
}