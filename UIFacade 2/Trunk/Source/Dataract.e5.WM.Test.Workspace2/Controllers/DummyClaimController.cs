using System.Web.Mvc;

namespace Dataract.e5.WM.Test.Workspace2.Controllers
{
    public class DummyClaimController : Controller
    {
        public ActionResult Index(string claimNumber)
        {
            ViewBag.ClaimNumber = claimNumber;
            return View();
        }
    }
}
