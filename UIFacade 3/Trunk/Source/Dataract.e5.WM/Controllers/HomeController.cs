using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Dataract.e5.WM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Workspace1HomeUrl = WebConfigurationManager.AppSettings["Workspace1HomeUrl"];
            ViewBag.Workspace1HomeUrlAlt = WebConfigurationManager.AppSettings["Workspace1HomeUrlAlt"];
            ViewBag.Workspace2HomeUrl = WebConfigurationManager.AppSettings["Workspace2HomeUrl"];            
            ViewBag.Workspace2HomeUrlAlt = WebConfigurationManager.AppSettings["Workspace2HomeUrlAlt"];
            ViewBag.WorkspaceManagerTitle = WebConfigurationManager.AppSettings["WorkspaceManagerTitle"];

            return View();
        }
    }
}