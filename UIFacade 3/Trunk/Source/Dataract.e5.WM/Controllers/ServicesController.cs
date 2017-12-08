using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Dataract.e5.WM.Interface;

namespace Dataract.e5.WM.Controllers
{
    public class ServicesController : Controller
    {
        public ActionResult Index()
        {
            return Content(@"Index Controller Action");
        }

        public ActionResult Test(string data)
        {
            return Content(data);
        }

        [HttpPost]
        public ActionResult Api(string data)
        {
            var level = "0";

            try
            {
                level = string.Concat(new []{level, "|1"});

                var postData = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(data);

                level = string.Concat(new[] { level, "|2" });

                var messageCode = (postData.ContainsKey("messageCode")) ? postData["messageCode"].ToString().ToLower() : null;

                level = string.Concat(new[] { level, "|3" });

                var workspaceId = (postData.ContainsKey("workspaceId")) ? postData["workspaceId"].ToString().ToLower() : null;

                level = string.Concat(new[] { level, "|4|New" });

                var processor = new RACTi.WM.RequestManager.Worker(); //Container.Resolver.Resolve<IRequestManager>();

                level = string.Concat(new[] { level, "|5" });

                if (processor != null)
                {
                    level = string.Concat(new[] { level, "|6" });

                    object x = processor.Process(messageCode, workspaceId, postData);

                    level = string.Concat(new[] { level, "|7" });

                    return Json(x);
                }

                level = string.Concat(new[] { level, "|8" });

                return Json(new List<object>());
            }
            catch (Exception ex)
            {
                level = string.Concat(new[] { level, "|9" });

                return Json(new { value = "Exception", url = string.Concat(new[] { level, " >>> ", ex.Message }) });    
            }
        }
    }
}