using System.Collections.Generic;

namespace SiteMapTask.Models
{
    public class MainModel
    {
        public string NameSite { get; set; }
        public int TimeMini { get; set; }
        public int TimeNow { get; set; }
        public int TimeMax { get; set; }
    }

    public class SubSitesModel
    {
        public ICollection<MainModel> ModelsCollection { get; set; }
        public SubSitesModel()
        {
            ModelsCollection = new List<MainModel>();
        }
    }
}