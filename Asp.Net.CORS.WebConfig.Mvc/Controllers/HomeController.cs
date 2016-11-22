using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Asp.Net.CORS.WebConfig.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var result = await ReadValues();
            ViewBag.Values = result;
            return View();
        }

        private static async Task<List<string>> ReadValues()
        {
            var url = "http://localhost:16980/api/Values/";

            using (var client = new HttpClient())
            {
                var httpResponseMessage = await client.GetAsync(url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<List<string>>(jsonString);
                    return result;
                }
                else
                {
                    throw new Exception(httpResponseMessage.ReasonPhrase);
                }
            }

        }

    }
}