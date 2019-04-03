using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MongoDB.Driver;
using SiteMapTask.DBContext;
using SiteMapTask.Models;

namespace SiteMapTask.Controllers
{
    public class HomeController : Controller
    {
        SiteMapContext dbContext = new SiteMapContext();
        public ActionResult Index()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Index(SiteModel c)
        {
            //await Create(c);
            return RedirectToAction("Index");
        }
        public ActionResult In()
        {
            List<SiteModel> pr = dbContext.GetListSite();
            string test = "https://www.metanit.com";
            bool s = dbContext.ValidationSiteMap(test);
            return View(pr);
        }
    }
}