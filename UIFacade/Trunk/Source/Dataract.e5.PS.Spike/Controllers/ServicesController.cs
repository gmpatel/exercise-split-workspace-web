using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Dataract.e5.PS.Spike.Interfaces;

namespace Dataract.e5.PS.Spike.Controllers
{
    public class ServicesController : Controller
    {
        [HttpGet]
        public ActionResult Test(string data)
        {
            return Content(data);
        }

        [HttpPost]
        public ActionResult Api(string data)
        {
            var postData = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(data);
 
            var messageCode = (postData.ContainsKey("messageCode")) ? postData["messageCode"].ToString().ToLower() : null;
            var workspaceId = (postData.ContainsKey("workspaceId")) ? postData["workspaceId"].ToString().ToLower() : null;
            
            var processor = Statics.Container.Resolve<IRequestManager>();

            if (processor != null)
            {
                return Json(processor.Process(messageCode, workspaceId, postData));    
            }

            return Json(new List<object>());
        }
    }
}