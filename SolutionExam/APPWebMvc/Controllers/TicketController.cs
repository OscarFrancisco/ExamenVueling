using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APPWebMvc.Controllers
{
    public class TicketController : Controller
    {
        private readonly IHttpClientSync _httpclient;
        public TicketController()
        {
            _httpclient = new HttpClientSync();
            ViewBag.Title = ViewBag.Message = "Venta de Articulos";
            ViewBag.CORSTicket = ConfigurationManager.AppSettings["URLServiceTicket"];
        }
        public async Task<ActionResult> Index()
        {
            try
            {
                var task = await _httpclient.GetAsync(ConfigurationManager.AppSettings["URLServiceArticle"]);
                var jsonString = await task.Content.ReadAsStringAsync();
                return View(_httpclient.GetListJson<Article>(jsonString));
            }
            catch(Exception)
            {
                ViewBag.Title = "Error al obtener informacion de los Articulos";
                ViewBag.Message = string.Empty;
                return View(new List<Article>());
            }

        }
   }
}