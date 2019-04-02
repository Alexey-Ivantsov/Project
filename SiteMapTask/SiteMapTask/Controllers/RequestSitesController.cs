using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMapTask.Models;

namespace SiteMapTask.Controllers
{
    public class RequestSitesController : HomeController
    {
        [System.Web.Mvc.HttpGet]
        public async Task<int> TimeRequest([FromRoute] string url)
        {
            Stopwatch myStopWatch = new Stopwatch();
            myStopWatch.Start();
            await UrlResponse(url);
            int milliseconds = (int)myStopWatch.ElapsedMilliseconds;
            myStopWatch.Stop();
            SiteModel newModel = new SiteModel
            {
                NameSite = url,
                TimeNow = milliseconds
            };
            Create(newModel);
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