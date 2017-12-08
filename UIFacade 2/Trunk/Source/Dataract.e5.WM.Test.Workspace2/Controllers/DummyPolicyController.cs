using System.Web.Mvc;

namespace Dataract.e5.WM.Test.Workspace2.Controllers
{
    public class DummyPolicyController : Controller
    {
        public ActionResult Index(string policyNumber)
        {
            ViewBag.PolicyNumber = policyNumber;
            return View();
        }
    }
}
