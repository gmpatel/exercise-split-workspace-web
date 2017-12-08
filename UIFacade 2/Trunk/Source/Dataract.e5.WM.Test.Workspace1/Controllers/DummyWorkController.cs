using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dataract.e5.WM.Test.Workspace1.Controllers
{
    public class DummyWorkController : Controller
    {
        public ActionResult Index(string workReference)
        {
            ViewBag.WorkReference = workReference;
            return View();
        }
    }
}
