using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Dataract.e5.RACTi.WSM.Worker
{
    internal sealed class WorkerConfigurationSectionManager
    {
        private const string ConfigSectionName = @"WSMWorkerConfiguration";
        private readonly WorkerConfigurationSection section;

        private string e5ContentDbConnectionString;
        private string e5FindPolicyPageUrlTemplate;
        private string e5WorkUrlTemplate;
        private string purePolicyUrlTemplate;
        private string pureClaimUrlTemplate;
        
        internal WorkerConfigurationSectionManager()
        {
            section = ConfigurationManager.GetSection(ConfigSectionName) as WorkerConfigurationSection;

            if (section == null)
            {
                throw new ConfigurationErrorsException(string.Format("Missing configuration, section {0} is not defined", ConfigSectionName));
            }

            GetE5ContentDbConnectionString();
            GetE5FindPolicyPageUrlTemplate(); 
            GetE5WorkUrlTemplate();
            GetPurePolicyUrlTemplate();
            GetPureClaimUrlTemplate();
        }

        private void GetE5ContentDbConnectionString()
        {
            e5ContentDbConnectionString = section.E5ContentDbConnectionString;
        }

        private void GetE5FindPolicyPageUrlTemplate()
        {
            e5FindPolicyPageUrlTemplate = section.E5FindPolicyPageUrlTemplate;
        }

        private void GetE5WorkUrlTemplate()
        {
            e5WorkUrlTemplate = section.E5WorkUrlTemplate;
        }

        private void GetPurePolicyUrlTemplate()
        {
            purePolicyUrlTemplate = section.PurePolicyUrlTemplate;
        }

        private void GetPureClaimUrlTemplate()
        {
            pureClaimUrlTemplate = section.PureClaimUrlTemplate;
        }

        
        internal string E5ContentDbConnectionString
        {
            get { return e5ContentDbConnectionString; }
        }

        internal string E5FindPolicyPageUrlTemplate
        {
            get { return e5FindPolicyPageUrlTemplate; }
        }

        internal string E5WorkUrlTemplate
        {
            get { return e5WorkUrlTemplate; }
        }

        internal string PurePolicyUrlTemplate
        {
            get { return purePolicyUrlTemplate; }
        }

        internal string PureClaimUrlTemplate
        {
            get { return pureClaimUrlTemplate; }
        }
    }
}