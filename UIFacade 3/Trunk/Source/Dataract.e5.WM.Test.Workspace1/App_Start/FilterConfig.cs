﻿using System.Web.Mvc;

namespace Dataract.e5.WM.Test.Workspace1.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}