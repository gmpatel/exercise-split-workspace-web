using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Dataract.e5.Fake.WM.RequestManager
{
    internal sealed class WorkerConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("E5SiteRootUrlFake", DefaultValue = "", IsRequired = true)]
        [StringValidator]
        internal string E5SiteRootUrlFake
        {
            get
            {
                return ((string)this["E5SiteRootUrlFake"]).Trim();
            }
        }

        [ConfigurationProperty("AnotherSiteRootUrlFake", DefaultValue = "", IsRequired = true)]
        [StringValidator]
        internal string AnotherSiteRootUrlFake
        {
            get
            {
                return ((string)this["AnotherSiteRootUrlFake"]).Trim();
            }
        }
    }
}