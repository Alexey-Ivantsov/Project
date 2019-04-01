using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SiteMapTask.Models
{
    public class SiteModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string SiteName { get; set; }
        public string Url { get; set; }
        public int Time { get; set; }
        public string NameSite { get; set; }
        public int TimeMini { get; set; }
        public int TimeNow { get; set; }
        public int TimeMax { get; set; }
        public SiteModel()
        {
            NameSite = Url;
        }
    }
}