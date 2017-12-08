using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Dataract.e5.Fake.WM.RequestManager
{
    internal sealed class WorkerConfigurationSectionManager
    {
        private const string ConfigSectionName = @"WorkerConfigurationFake";
        private readonly WorkerConfigurationSection section;

        private string e5SiteRootUrlFake;
        private string anotherSiteRootUrlFake;
        
        internal WorkerConfigurationSectionManager()
        {
            section = ConfigurationManager.GetSection(ConfigSectionName) as WorkerConfigurationSection;

            if (section == null)
            {
                throw new ConfigurationErrorsException(string.Format("Missing configuration, section {0} is not defined", ConfigSectionName));
            }

            GetE5SiteRootUrlFake();
            GetAnotherSiteRootUrlFake();
        }

        private void GetE5SiteRootUrlFake()
        {
            e5SiteRootUrlFake = section.E5SiteRootUrlFake;
        }

        private void GetAnotherSiteRootUrlFake()
        {
            anotherSiteRootUrlFake = section.AnotherSiteRootUrlFake;
        }



        internal string E5SiteRootUrlFake
        {
            get { return e5SiteRootUrlFake; }
        }

        internal string AnotherSiteRootUrlFake
        {
            get { return anotherSiteRootUrlFake; }
        }
    }
}
