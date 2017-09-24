using System.Web.Mvc;

namespace NumberToWordConverter.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home Page Action
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            ViewBag.Message = "Convert Number to Words(Upto Billion)";
            ViewBag.ServiceHostUrl = System.Configuration.ConfigurationManager.AppSettings["ServiceHostUrl"];
            return View();
        }
    }
}