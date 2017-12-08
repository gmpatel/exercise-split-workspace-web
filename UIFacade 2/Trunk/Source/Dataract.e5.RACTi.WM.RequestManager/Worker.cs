using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dataract.e5.WM.Interface;

namespace Dataract.e5.RACTi.WM.RequestManager
{
    public class Worker : IRequestManager
    {
        public object Process(string messageCode, string workspaceId, Dictionary<string, object> postData)
        {
            switch (messageCode.ToLower())
            {
                case "openclaim":
                    {
                        var claimNumber = (postData.ContainsKey("claimNumber") ? postData["claimNumber"].ToString() : string.Empty);

                        return Helper.ProcessClaimNumber(workspaceId, claimNumber);
                    }
                case "openwork":
                    {
                        var workReference = (postData.ContainsKey("workReference") ? postData["workReference"].ToString() : string.Empty);

                        return Helper.ProcessWorkReference(workspaceId, workReference);
                    }
                case "openpolicy":
                    {
                        var policyNumber = (postData.ContainsKey("policyNumber") ? postData["policyNumber"].ToString() : string.Empty);

                        return Helper.ProcessPolicyNumber(workspaceId, policyNumber);
                    }
                case "unlockwork":
                    {
                        var workId = (postData.ContainsKey("workId") ? postData["workId"].ToString() : string.Empty);

                        return Helper.ProcessUnlockWork(workId);
                    }
                default:
                    {
                        return new List<object>();
                    }
            }
        }
    }
}