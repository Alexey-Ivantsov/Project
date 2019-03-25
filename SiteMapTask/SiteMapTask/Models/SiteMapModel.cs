using System.ComponentModel.DataAnnotations;

namespace SiteMapTask.Models
{
    public class SiteMapModel
    {
        [Display(Name = "Site")]
        public string SiteName { get; set; }
        [Display(Name = "URL")]
        public string Url { get; set; }
        [Display(Name = "Time")]
        public int Time { get; set; }
    }
}