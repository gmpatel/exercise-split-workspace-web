using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Dataract.e5.RACTi.WM.RequestManager
{
    internal static class Helper
    {
        private static readonly WorkerConfigurationSectionManager Config;

        private static readonly Database Db;

        static Helper()
        {
            Config = new WorkerConfigurationSectionManager();

            Db = DbHelper.GetDatabase(Config.E5ContentDbConnectionString);
        }

        internal static object ProcessUnlockWork(string msgCode, string wsId, string workId)
        {
            Guid work; string qry = workId;

            if (Guid.TryParse(workId, out work))
            {
                qry = string.Concat(new string[] { "EXEC Work_Unlock '", work.ToString(), "'" });
                DbHelper.ExecuteStoredProc(Db, "Work_Unlock", new object[] { work });
            }

            return new { value = workId, url = string.Concat(new string[] { "about:blank" }), query = qry };
        }

        internal static object ProcessWorkId(string msgCode, string wsId, string workId)
        {
            var listDataWorkSpace1 = new List<object>();
            var listDataWorkSpace2 = new List<object>();
            var workReference = string.Empty;

            try
            {
                var qry = string.Concat(new string[] {"Select Reference From Work Where Id = '", workId, "'"});
                var result = DbHelper.ExecuteTextScalar(Db, qry);
                if (result != null)
                {
                    workReference = result.ToString();
                }
            }
            catch
            {
                workReference = "Null";
            }

            listDataWorkSpace1.Add(
                    new { value = string.Concat(new string[] { "Work : ", workReference }), url = string.Concat(new string[] { Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", workId) }), pane = 0, key = string.Concat(new string[] { workId }), info = workId }
                );

            return new
            {
                messageCode = msgCode,
                messageFromWorkspace = wsId,
                referenceNumber = workId,
                
                processWorkSpace1 = 1,
                clearWorkSpace1HomeTabs = 0,
                dataWorkSpace1 = listDataWorkSpace1,

                processWorkSpace2 = 0,
                clearWorkSpace2HomeTabs = 0,
                dataWorkSpace2 = listDataWorkSpace2
            };
        }

        internal static object ProcessPolicyNumber(string msgCode, string wsId, string policyNumber)
        {
            var listDataWorkSpace1 = new List<object>();
            var listDataWorkSpace2 = new List<object>();

            if (wsId == "1")
            {
                listDataWorkSpace2.Add(
                    new { value = string.Concat(new string[] { "Dummy Policy : ", policyNumber }), url = Config.PurePolicyUrlTemplate.Trim().Replace("$#policy_number#$", policyNumber) }
                );

                return new
                {
                    messageCode = msgCode,
                    messageFromWorkspace = wsId,
                    referenceNumber = policyNumber,
                    
                    processWorkSpace1 = 0,
                    clearWorkSpace1HomeTabs = 0,
                    dataWorkSpace1 = listDataWorkSpace1,

                    processWorkSpace2 = 1,
                    clearWorkSpace2HomeTabs = 0,
                    dataWorkSpace2 = listDataWorkSpace2
                };
            }

            if (wsId == "2")
            {
                listDataWorkSpace1.Add(
                    new { value = string.Concat(new string[] { "Find Ploicy : ", policyNumber }), url = string.Concat(new string[] { Config.E5FindPolicyPageUrlTemplate.Trim().Replace("$#policy_number#$", policyNumber) }), pane = 1, key = string.Concat(new string[]{"e5-work-find-", policyNumber}) } //new { value = string.Concat(new string[] { "E5 Find : ", policyNumber }), url = Config.E5FindPolicyPageUrlTemplate.Trim().Replace("$#policy_number#$", policyNumber) }
                );
                
                /*
                try
                {
                    var work = DbHelper.ExecuteStoredProc(Db, "Custom_SP_FindWorkByPoliceId", new object[] { policyNumber });

                    if (work != null && work.Tables.Count > 0 && work.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in work.Tables[0].Rows)
                        {
                            listDataWorkSpace1.Add(
                                new { value = string.Concat(new string[] { "Work : ", row["Reference"].ToString() }), url = string.Concat(new string[] { Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", row["Id"].ToString()) }), work_id = row["Id"].ToString() }
                            );
                        }
                    }
                }
                catch
                {
                    listDataWorkSpace1.Add(
                        new { value = string.Concat(new string[] { "DB : ", "Error" }), url = string.Concat(new string[] { "about:blank" }) }
                    );
                }
                */

                listDataWorkSpace2.Add(
                    new { value = string.Concat(new string[] { "Dummy Policy : ", policyNumber }), url = Config.PurePolicyUrlTemplate.Trim().Replace("$#policy_number#$", policyNumber) }
                );

                return new
                {
                    messageCode = msgCode,
                    messageFromWorkspace = wsId,
                    referenceNumber = policyNumber,

                    processWorkSpace1 = 1,
                    clearWorkSpace1HomeTabs = 0,
                    dataWorkSpace1 = listDataWorkSpace1,

                    processWorkSpace2 = 1,
                    clearWorkSpace2HomeTabs = 0,
                    dataWorkSpace2 = listDataWorkSpace2
                };
            }

            return new List<object>();
        }

        internal static object ProcessWorkReference(string msgCode, string wsId, string workReference)
        {
            if (workReference == "10924")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10924", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", "236789"}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", "236789") },
                            }
                };
            }

            if (workReference == "10948")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10948", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", "549806"}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", "549806") },
                            }
                };
            }

            if (workReference == "10902")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10902", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", "384729"}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", "384729") },
                            }
                };
            }


            if (workReference == "10916")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10916", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", "983247"}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", "983247") },
                            }
                };
            }


            if (workReference == "10904")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10904", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", "458903"}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", "458903") },
                            }
                };
            }

            return new List<object>();
        }

        internal static object ProcessClaimNumber(string msgCode, string wsId, string claimNumber)
        {
            if (claimNumber == "236789")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10924", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                                new { value = "Work : 10923", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                                new { value = "Work : 10922", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                                new { value = "Work : 10921", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", claimNumber}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", claimNumber) },
                            }
                };
            }

            if (claimNumber == "549806")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10948", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                                new { value = "Work : 10942", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                                new { value = "Work : 10928", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", claimNumber}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", claimNumber) },
                            }
                };
            }

            if (claimNumber == "384729")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10902", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                                new { value = "Work : 10880", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", claimNumber}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", claimNumber) },
                            }
                };
            }


            if (claimNumber == "983247")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10916", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                                new { value = "Work : 10903", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", claimNumber}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", claimNumber) },
                            }
                };
            }


            if (claimNumber == "458903")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10904", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                                new { value = "Work : 10911", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                                new { value = "Work : 10917", url = Config.E5WorkUrlTemplate.Trim().Replace("$#work_id#$", "813ce73a-f975-11e2-93f8-00155d345f92") },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = string.Concat(new[]{"Dummy Claim : ", claimNumber}), url = Config.PureClaimUrlTemplate.Trim().Replace("$#claim_number#$", claimNumber) },
                            }
                };
            }

            return new List<object>();
        }
    }
}