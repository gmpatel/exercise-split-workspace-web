using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWorkspace2.Controllers
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
