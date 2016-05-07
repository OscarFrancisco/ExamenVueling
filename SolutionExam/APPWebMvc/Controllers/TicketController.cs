using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APPWebMvc.Controllers
{
    public class TicketController : Controller
    {
        private readonly IHttpClientSync _httpclient = new HttpClientSync();
        public async Task<ActionResult> Index()
        {
            var task = await _httpclient.GetAsync("http://localhost:1228/ServiceArticle.svc/");
            var jsonString = await task.Content.ReadAsStringAsync();
            return View(_httpclient.GetListArticlesJson<Article>(jsonString));
        }
   }
}