using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dataract.e5.PS.Spike.RequestManager
{
    public class Process
    {
        public object Message(Dictionary<string, object> messageData)
        {
            var messageCode = (messageData.ContainsKey("messageCode")) ? messageData["messageCode"].ToString().ToLower() : string.Empty;

            var workspaceId = (messageData.ContainsKey("workspaceId")) ? messageData["workspaceId"].ToString().ToLower() : string.Empty;

            switch (messageCode)
            {
                case "openclaim":
                    {
                        var claimNumber = (messageData.ContainsKey("claimNumber") ? messageData["claimNumber"].ToString() : string.Empty);

                        return Helper.Demo.GetData_For_Message_OpenClaim(workspaceId, claimNumber);
                    }
                case "openwork":
                    {
                        var workReference = (messageData.ContainsKey("workReference") ? messageData["workReference"].ToString() : string.Empty);

                        return Helper.Demo.GetData_For_Message_OpenWork(workspaceId, workReference);
                    }
                case "openpolicy":
                    {
                        var policyNumber = (messageData.ContainsKey("policyNumber") ? messageData["policyNumber"].ToString() : string.Empty);

                        return Helper.Demo.GetData_For_Message_OpenPolicy(workspaceId, policyNumber);
                    }
                default:
                    {
                        return new List<object>();
                    }
            }
        }
    }
}