using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dataract.e5.WM.Test.Workspace1.Controllers
{
    public class DummyFindController : Controller
    {
        public ActionResult Index(string findType, string findNumber)
        {
            ViewBag.FindType = findType.ToUpper();
            ViewBag.FindNumber = findNumber;
            return View();
        }
    }
}