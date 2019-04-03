using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using SiteMapTask.DBContext;
using SiteMapTask.Models;

namespace SiteMapTask.Controllers
{
    public class RequestSitesController : Controller
    {
        private readonly SiteMapContext _dbContext = new SiteMapContext();
        [System.Web.Mvc.HttpGet]
        public async Task<int> TimeRequest([FromRoute] string url)
        {
            Stopwatch myStopWatch = new Stopwatch();
            myStopWatch.Start();
            await UrlResponse(url);
            int milliseconds = (int)myStopWatch.ElapsedMilliseconds;
            myStopWatch.Stop();
            foreach (var item in _dbContext.GetListSite())
            {
                if (item.NameSite == url)
                {
                    item.TimeNow = milliseconds;
                    if (milliseconds < item.TimeMini)
                    {
                        item.TimeMini = milliseconds;
                    }
                    else if (milliseconds > item.TimeMax)
                    {
                        item.TimeMax = milliseconds;
                    }
                    await _dbContext.Edit(item);
                    return milliseconds;
                }
            }

            var newModel = new SiteModel
            {
                NameSite = url,
                TimeNow = milliseconds,
                TimeMini = milliseconds,
                TimeMax = milliseconds
            };
            await _dbContext.Create(newModel);
            return milliseconds;
        }
        private async Task UrlResponse(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Connection.Add("keep-alive");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await client.SendAsync(requestMessage);
        }
    }
}