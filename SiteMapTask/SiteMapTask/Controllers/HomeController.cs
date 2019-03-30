using System.Threading.Tasks;
using System.Web.Mvc;
using SiteMapTask.DBContext;
using SiteMapTask.Models;

namespace SiteMapTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteMapContext db = new SiteMapContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(SiteModel c)
        {
            await db.Create(c);
            return RedirectToAction("Index");
        }

    }
}