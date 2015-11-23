using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExamSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // Async partial view
        public async Task<ActionResult> List()
        {
            ViewBag.SyncOrAsync = "Asynchronous";
            string results = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(new Uri("http://externalfeedsite"));
                Byte[] downloadedBytes = await response.Content.ReadAsByteArrayAsync();
                Encoding encoding = new ASCIIEncoding();
                results = encoding.GetString(downloadedBytes);
            }
            return PartialView("partialViewName", results);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}