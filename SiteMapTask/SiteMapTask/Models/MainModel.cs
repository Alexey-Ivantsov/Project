using System.Collections.Generic;

namespace SiteMapTask.Models
{
    public class MainModel
    {
        public SiteModel MainSite { get; set; }

        public List<SiteModel> Subsites { get; set; }
    }
}