using System.Collections.Generic;

namespace Dataract.e5.Fake.WM.RequestManager
{
    internal static class Helper
    {
        private static readonly WorkerConfigurationSectionManager Config;

        static Helper()
        {
            Config = new WorkerConfigurationSectionManager();
        }

        internal static object ProcessUnlockWork(string workId)
        {
            return new { value = workId, url = string.Concat(new string[] { "about:blank" }) };
        }

        internal static object ProcessClaimNumber(string msgCode, string wsId, string claimNumber)
        {
            object dataWs1 = new List<object>()
                        {
                            new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Claim&findNumber=", claimNumber}), pane = 1 },
                            new { value = string.Concat(new string[]{"Work : ", claimNumber}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", claimNumber}), pane = 0 },
                        };

            object dataWs2 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Dummy Claim : ", claimNumber}), url = string.Concat(new string[]{ Config.AnotherSiteRootUrlFake, "/DummyClaim/Index?claimnumber=", claimNumber}), pane = 0 }
                        };

            if (claimNumber == "236789")
            {
                dataWs1 = new List<object>()
                        {
                            new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Claim&findNumber=", claimNumber}), pane = 1 },
                            new { value = string.Concat(new string[]{"Work : ", "10924"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10924"}), pane = 0 },
                            new { value = string.Concat(new string[]{"Work : ", "10923"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10923"}), pane = 0 },
                            new { value = string.Concat(new string[]{"Work : ", "10922"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10922"}), pane = 0 },
                            new { value = string.Concat(new string[]{"Work : ", "10921"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10921"}), pane = 0 },
                        };
            }

            if (claimNumber == "549806")
            {
                dataWs1 = new List<object>()
                            {    
                                new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Claim&findNumber=", claimNumber}), pane = 1 },
                                new { value = string.Concat(new string[]{"Work : ", "10948"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10948"}), pane = 0 },
                                new { value = string.Concat(new string[]{"Work : ", "10942"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10942"}), pane = 0 },
                                new { value = string.Concat(new string[]{"Work : ", "10928"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10928"}), pane = 0 },
                            };
            }

            if (claimNumber == "384729")
            {
                dataWs1 = new List<object>()
                            {    
                                new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Claim&findNumber=", claimNumber}), pane = 1 },
                                new { value = string.Concat(new string[]{"Work : ", "10902"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10902"}), pane = 0 },
                                new { value = string.Concat(new string[]{"Work : ", "10880"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10880"}), pane = 0 },
                            };
            }


            if (claimNumber == "983247")
            {
                dataWs1 = new List<object>()
                            {    
                                new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Claim&findNumber=", claimNumber}), pane = 1 },
                                new { value = string.Concat(new string[]{"Work : ", "10916"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10916"}), pane = 0 },
                                new { value = string.Concat(new string[]{"Work : ", "10903"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10903"}), pane = 0 },
                            };
            }


            if (claimNumber == "458903")
            {
                dataWs1 = new List<object>()
                            {    
                                new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Claim&findNumber=", claimNumber}), pane = 1 },
                                new { value = string.Concat(new string[]{"Work : ", "10904"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10904"}), pane = 0 },
                                new { value = string.Concat(new string[]{"Work : ", "10911"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10911"}), pane = 0 },
                                new { value = string.Concat(new string[]{"Work : ", "10917"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10917"}), pane = 0 },
                            };
            }

            return new
            {
                messageCode = msgCode,
                messageFromWorkspace = wsId,
                referenceNumber = claimNumber,
                processWorkSpace1 = 1,
                clearWorkSpace1HomeTabs = 1,
                dataWorkSpace1 = dataWs1,
                processWorkSpace2 = 1,
                clearWorkSpace2HomeTabs = 0,
                dataWorkSpace2 = dataWs2,
            };
        }

        internal static object ProcessWorkReference(string msgCode, string wsId, string workReference)
        {
            object dataWs1 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Work : ", workReference}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", workReference}), pane = 0 },
                        };

            object dataWs2 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Dummy Claim : ", workReference}), url = string.Concat(new string[]{ Config.AnotherSiteRootUrlFake, "/DummyClaim/Index?claimnumber=", workReference}), pane = 0 }
                        };

            if (workReference == "10924")
            {
                dataWs2 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Dummy Claim : ", "236789"}), url = string.Concat(new string[]{ Config.AnotherSiteRootUrlFake, "/DummyClaim/Index?claimnumber=", "236789"}), pane = 0 }
                        };
            }

            if (workReference == "10948")
            {
                dataWs2 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Dummy Claim : ", "549806"}), url = string.Concat(new string[]{ Config.AnotherSiteRootUrlFake, "/DummyClaim/Index?claimnumber=", "549806"}), pane = 0 }
                        };
            }

            if (workReference == "10902")
            {
                dataWs2 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Dummy Claim : ", "384729"}), url = string.Concat(new string[]{ Config.AnotherSiteRootUrlFake, "/DummyClaim/Index?claimnumber=", "384729"}), pane = 0 }
                        };
            }

            if (workReference == "10916")
            {
                dataWs2 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Dummy Claim : ", "983247"}), url = string.Concat(new string[]{ Config.AnotherSiteRootUrlFake, "/DummyClaim/Index?claimnumber=", "983247"}), pane = 0 }
                        };
            }

            if (workReference == "10904")
            {
                dataWs2 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Dummy Claim : ", "458903"}), url = string.Concat(new string[]{ Config.AnotherSiteRootUrlFake, "/DummyClaim/Index?claimnumber=", "458903"}), pane = 0 }
                        };
            }

            return new
            {
                messageCode = msgCode,
                messageFromWorkspace = wsId,
                referenceNumber = workReference,
                processWorkSpace1 = 1,
                clearWorkSpace1HomeTabs = 1,
                dataWorkSpace1 = dataWs1,
                processWorkSpace2 = 1,
                clearWorkSpace2HomeTabs = 0,
                dataWorkSpace2 = dataWs2,
            };
        }

        internal static object ProcessPolicyNumber(string msgCode, string wsId, string policyNumber)
        {
            object dataWs1 = new List<object>()
                        {
                            new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Policy&findNumber=", policyNumber}), pane = 1, key = string.Concat(new string[]{"e5-work-find-", policyNumber}) },
                            new { value = string.Concat(new string[]{"Work : ", policyNumber}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", policyNumber}), pane = 0 },
                        };

            object dataWs2 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Dummy Policy : ", policyNumber}), url = string.Concat(new string[]{ Config.AnotherSiteRootUrlFake, "/DummyPolicy/Index?claimnumber=", policyNumber}), pane = 0 }
                        };

            if (policyNumber == "88102")
            {
                dataWs1 = new List<object>()
                            {    
                                new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Policy&findNumber=", policyNumber}), pane = 1, key = string.Concat(new string[]{"e5-work-find-", policyNumber}) },
                                new { value = string.Concat(new string[]{"Work : ", "10924"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10924"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10924"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                                new { value = string.Concat(new string[]{"Work : ", "10922"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10922"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10922"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                            };
            }

            if (policyNumber == "87990")
            {
                dataWs1 = new List<object>()
                            {    
                                new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Policy&findNumber=", policyNumber}), pane = 1, key = string.Concat(new string[]{"e5-work-find-", policyNumber}) },
                                new { value = string.Concat(new string[]{"Work : ", "10948"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10948"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10948"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                                new { value = string.Concat(new string[]{"Work : ", "10924"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10924"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10924"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                                new { value = string.Concat(new string[]{"Work : ", "10922"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10922"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10922"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                            };
            }

            if (policyNumber == "89818")
            {
                dataWs1 = new List<object>()
                            {    
                                new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Policy&findNumber=", policyNumber}), pane = 1, key = string.Concat(new string[]{"e5-work-find-", policyNumber}) },
                                new { value = string.Concat(new string[]{"Work : ", "10902"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10902"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10902"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                                new { value = string.Concat(new string[]{"Work : ", "10911"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10911"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10911"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                                new { value = string.Concat(new string[]{"Work : ", "10917"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10917"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10917"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                            };
            }


            if (policyNumber == "98181")
            {
                dataWs1 = new List<object>()
                            {    
                                new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Policy&findNumber=", policyNumber}), pane = 1, key = string.Concat(new string[]{"e5-work-find-", policyNumber}) },
                                new { value = string.Concat(new string[]{"Work : ", "10916"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10916"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10916"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                                new { value = string.Concat(new string[]{"Work : ", "10917"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10917"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10917"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                            };
            }


            if (policyNumber == "99191")
            {
                dataWs1 = new List<object>()
                            {    
                                new { value = "Find", url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyFind/Index?findType=Policy&findNumber=", policyNumber}), pane = 1, key = string.Concat(new string[]{"e5-work-find-", policyNumber}) },
                                new { value = string.Concat(new string[]{"Work : ", "10904"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10904"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10904"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                                new { value = string.Concat(new string[]{"Work : ", "10902"}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", "10902"}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", "10902"}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                            };
            }

            return new
            {
                messageCode = msgCode,
                messageFromWorkspace = wsId,
                referenceNumber = policyNumber,
                processWorkSpace1 = (wsId == "1") ? 0 : 1,
                clearWorkSpace1HomeTabs = 1,
                dataWorkSpace1 = dataWs1,
                processWorkSpace2 = 1,
                clearWorkSpace2HomeTabs = 0,
                dataWorkSpace2 = dataWs2,
            };
        }

        internal static object ProcessOpenSingleWork(string msgCode, string wsId, string workReference)
        {
            object dataWs1 = new List<object>()
                        {
                            new { value = string.Concat(new string[]{"Work : ", workReference}), url = string.Concat(new string[]{ Config.E5SiteRootUrlFake, "/DummyWork/Index?workreference=", workReference}), pane = 0, key = string.Concat(new string[]{"e5-work-item-", workReference}), info = "d2260332-841e-49a8-bef5-e614f34aede6" },
                        };

            object dataWs2 = new List<object>();

            return new
            {
                messageCode = msgCode,
                messageFromWorkspace = wsId,
                referenceNumber = workReference,
                processWorkSpace1 = 1,
                clearWorkSpace1HomeTabs = 0,
                dataWorkSpace1 = dataWs1,
                processWorkSpace2 = 0,
                clearWorkSpace2HomeTabs = 0,
                dataWorkSpace2 = dataWs2,
            };
        }
    }
}