using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Dataract.e5.WM.Container
{
    public static partial class Resolver
    {
        private static readonly Dictionary<Type, object> InstanceCatalog;

        public static void MapInstance<T>(object concreteType)
        {
            var instanceType = typeof(T);
            
            if (InstanceCatalog.ContainsKey(instanceType))
                InstanceCatalog.Remove(instanceType);
            
            InstanceCatalog.Add(instanceType, concreteType);
        }

        public static T Resolve<T>() where T : class
        {
            var instance = GetFromConfig<T>() ?? GetFromInstanceCatalog<T>();

            return instance;
        }

        private static T GetFromInstanceCatalog<T>() where T : class
        {
            object instance;
            InstanceCatalog.TryGetValue(typeof(T), out instance);
            return instance as T;
        }

        private static T GetFromConfig<T>() where T : class
        {
            var typeName = WebConfigurationManager.AppSettings[typeof(T).ToString()];
            
            if (string.IsNullOrEmpty(typeName))
                return null;

            var repoType = Type.GetType(typeName);
            var repoInstance = Activator.CreateInstance(repoType);
            var repo = repoInstance as T;

            return repo;
        }
    }
}