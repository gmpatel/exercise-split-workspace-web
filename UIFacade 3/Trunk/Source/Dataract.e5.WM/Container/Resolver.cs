using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Dataract.e5.Fake.WM.RequestManager;
using Dataract.e5.WM.Interface;

namespace Dataract.e5.WM.Container
{
    public static partial class Resolver
    {
        static Resolver()
        {
            InstanceCatalog = new Dictionary<Type, object>();

            MapInstance<IRequestManager>(new Worker());
        }
    }
}