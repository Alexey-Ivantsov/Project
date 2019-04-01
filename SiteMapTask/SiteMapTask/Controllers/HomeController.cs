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
        public IMongoCollection<SiteModel> MapCollection;
        public async Task Create(SiteModel c)
        {
            c.NameSite = c.Url;
            await MapCollection.InsertOneAsync(c);
        }
        public HomeController()
        {
            var db = new SiteMapContext();
            MapCollection = db.database.GetCollection<SiteModel>("SiteMap");
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(SiteModel c)
        {
            await Create(c);
            return RedirectToAction("Index");
        }
        public ActionResult In()
        {
            List<SiteModel> pr = MapCollection.AsQueryable().ToList();
            return View(pr);
        }
    }
}