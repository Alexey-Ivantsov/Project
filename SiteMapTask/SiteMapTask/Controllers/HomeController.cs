using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SiteMapTask.DBContext;
using SiteMapTask.Models;
using ActionResult = System.Web.Mvc.ActionResult;

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
        [System.Web.Mvc.HttpPost]
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
        [System.Web.Mvc.HttpGet]
        public async Task<string> TimeResponse([FromRoute] string url)
        {
            Stopwatch myStopWatch = new Stopwatch();
            HttpClient client = new HttpClient();
            myStopWatch.Start();
            client.DefaultRequestHeaders.Connection.Add("keep-alive");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await client.SendAsync(requestMessage);
            string milliseconds = myStopWatch.ElapsedMilliseconds.ToString();
            myStopWatch.Stop();
            return milliseconds;
        }

    }
}