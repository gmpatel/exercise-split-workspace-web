using System.Collections.Generic;

namespace Dataract.e5.PS.Spike.RequestManager.Helper
{
    internal static class Demo
    {
        internal static object GetData_For_Message_OpenClaim(string workspaceId, string claimNumber)
        {
            if (claimNumber == "236789")
            {
                return new
                    {
                        processWorkSpace1 = 1,
                        dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10924", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=f3a05655-e81f-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424707771&options=3&ArchiveId=0" },
                                new { value = "Work : 10923", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=f3a05654-e81f-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424751139&options=3&ArchiveId=0" },
                                new { value = "Work : 10922", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=f3a05653-e81f-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424768676&options=3&ArchiveId=0" },
                                new { value = "Work : 10921", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=f3a05652-e81f-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424800440&options=3&ArchiveId=0" }
                            },
                        processWorkSpace2 = 1,
                        dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 236789", url = "http://localhost:89/DummyClaim/Index?claimnumber=236789" }
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
                                new { value = "Work : 10948", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=6b167f14-e8ee-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424859346&options=3&ArchiveId=0" },
                                new { value = "Work : 10942", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=64775192-e8ee-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424877667&options=3&ArchiveId=0" },
                                new { value = "Work : 10928", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=58229dc1-e8ee-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424893621&options=3&ArchiveId=0" }
                            },
                        processWorkSpace2 = 1,
                        dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 549806", url = "http://localhost:89/DummyClaim/Index?claimnumber=549806" },
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
                                new { value = "Work : 10902", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a07fde67-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424965427&options=3&ArchiveId=0" },
                                new { value = "Work : 10880", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=e77e8303-e753-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424985169&options=3&ArchiveId=0" },
                            },
                        processWorkSpace2 = 1,
                        dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 384729", url = "http://localhost:89/DummyClaim/Index?claimnumber=384729" },
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
                                new { value = "Work : 10916", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=adbbd712-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425016809&options=3&ArchiveId=0" },
                                new { value = "Work : 10903", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a07fde68-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425046046&options=3&ArchiveId=0" },
                            },
                        processWorkSpace2 = 1,
                        dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 983247", url = "http://localhost:89/DummyClaim/Index?claimnumber=983247" },
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
                                new { value = "Work : 10904", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a07fde69-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425084164&options=3&ArchiveId=0" },
                                new { value = "Work : 10911", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a71ca991-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425099293&options=3&ArchiveId=0" },
                                new { value = "Work : 10917", rul = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=adbbd713-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425113856&options=3&ArchiveId=0" }
                            },
                        processWorkSpace2 = 1,
                        dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 458903", url = "http://localhost:89/DummyClaim/Index?claimnumber=458903" },
                            }
                    };
            }

            return new List<object>();
        }

        internal static object GetData_For_Message_OpenWork(string workspaceId, string workReference)
        {
            if (workReference == "10924")
            {
                return new
                {
                    processWorkSpace1 = 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10924", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=f3a05655-e81f-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424707771&options=3&ArchiveId=0" }
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 236789", url = "http://localhost:89/DummyClaim/Index?claimnumber=236789" }
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
                                new { value = "Work : 10948", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=6b167f14-e8ee-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424859346&options=3&ArchiveId=0" }
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 549806", url = "http://localhost:89/DummyClaim/Index?claimnumber=549806" },
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
                                new { value = "Work : 10902", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a07fde67-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424965427&options=3&ArchiveId=0" }
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 384729", url = "http://localhost:89/DummyClaim/Index?claimnumber=384729" },
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
                                new { value = "Work : 10916", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=adbbd712-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425016809&options=3&ArchiveId=0" }
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 983247", url = "http://localhost:89/DummyClaim/Index?claimnumber=983247" },
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
                                new { value = "Work : 10904", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a07fde69-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425084164&options=3&ArchiveId=0" }
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Claim : 458903", url = "http://localhost:89/DummyClaim/Index?claimnumber=458903" },
                            }
                };
            }

            return new List<object>();
        }

        internal static object GetData_For_Message_OpenPolicy(string workspaceId, string policyNumber)
        {
            if (policyNumber == "88102")
            {
                return new
                {
                    processWorkSpace1 = (workspaceId == "1") ? 0 : 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10924", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=f3a05655-e81f-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424707771&options=3&ArchiveId=0" },
                                new { value = "Work : 10922", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=f3a05653-e81f-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424768676&options=3&ArchiveId=0" },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Policy : 88102", url = "http://localhost:89/DummyPolicy/Index?policynumber=88102" }
                            }
                };
            }

            if (policyNumber == "87990")
            {
                return new
                {
                    processWorkSpace1 = (workspaceId == "1") ? 0 : 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10948", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=6b167f14-e8ee-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424859346&options=3&ArchiveId=0" },
                                new { value = "Work : 10924", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=f3a05655-e81f-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424707771&options=3&ArchiveId=0" },
                                new { value = "Work : 10922", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=f3a05653-e81f-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424768676&options=3&ArchiveId=0" },
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Policy : 87990", url = "http://localhost:89/DummyPolicy/Index?policynumber=87990" }
                            }
                };
            }

            if (policyNumber == "89818")
            {
                return new
                {
                    processWorkSpace1 = (workspaceId == "1") ? 0 : 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10902", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a07fde67-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424965427&options=3&ArchiveId=0" },
                                new { value = "Work : 10911", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a71ca991-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425099293&options=3&ArchiveId=0" },
                                new { value = "Work : 10917", rul = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=adbbd713-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425113856&options=3&ArchiveId=0" }
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Policy : 89818", url = "http://localhost:89/DummyPolicy/Index?policynumber=89818" }
                            }
                };
            }


            if (policyNumber == "98181")
            {
                return new
                {
                    processWorkSpace1 = (workspaceId == "1") ? 0 : 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10916", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=adbbd712-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425016809&options=3&ArchiveId=0" },
                                new { value = "Work : 10917", rul = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=adbbd713-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425113856&options=3&ArchiveId=0" }
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Policy : 98181", url = "http://localhost:89/DummyPolicy/Index?policynumber=98181" }
                            }
                };
            }


            if (policyNumber == "99191")
            {
                return new
                {
                    processWorkSpace1 = (workspaceId == "1") ? 0 : 1,
                    dataWorkSpace1 = new List<object>()
                            {    
                                new { value = "Work : 10904", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a07fde69-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373425084164&options=3&ArchiveId=0" },
                                new { value = "Work : 10902", url = "http://v3demo.dataract.com.au/sites/pensions/_layouts/e5/WorkProcessFrame.aspx?source=FindWork&id=a07fde67-e81e-11e2-a38f-005056b8070b&Category1_Id=0&Category2_Id=0&Category3_Id=0&workTabOption=&preProcess=undefined&ts=1373424965427&options=3&ArchiveId=0" },                                
                            },
                    processWorkSpace2 = 1,
                    dataWorkSpace2 = new List<object>()
                            {
                                new { value = "Dummy Policy : 99191", url = "http://localhost:89/DummyPolicy/Index?policynumber=99191" }
                            }
                };
            }

            return new List<object>();
        }
    }
}
