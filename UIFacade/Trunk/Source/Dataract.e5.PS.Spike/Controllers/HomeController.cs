using System.Globalization;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Dataract.e5.PS.Spike.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult Index4()
        {
            //ViewBag.WorkSpace1Url = WebConfigurationManager.AppSettings["WorkSpace1Url"].ToString(CultureInfo.InvariantCulture);
            //ViewBag.WorkSpace2Url = WebConfigurationManager.AppSettings["WorkSpace2Url"].ToString(CultureInfo.InvariantCulture);
            return View();
        }
    }
}
