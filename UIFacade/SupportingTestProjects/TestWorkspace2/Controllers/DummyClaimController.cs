using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWorkspace2.Controllers
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
