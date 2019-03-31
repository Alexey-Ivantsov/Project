using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SiteMapTask.Models
{
    public class SiteModel
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string SiteName { get; set; }
        [Display(Name = "URL")]
        public string Url { get; set; }
        //[Display(Name = "Time")]
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