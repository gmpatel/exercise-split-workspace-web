using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Dataract.e5.RACTi.WSM.Worker
{
    internal sealed class WorkerConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("E5ContentDbConnectionString", DefaultValue = "", IsRequired = true)]
        [StringValidator]
        internal string E5ContentDbConnectionString
        {
            get
            {
                return ((string)this["E5ContentDbConnectionString"]).Trim();
            }
        }

        [ConfigurationProperty("E5FindPolicyPageUrlTemplate", DefaultValue = "", IsRequired = true)]
        [StringValidator]
        internal string E5FindPolicyPageUrlTemplate
        {
            get
            {
                return ((string)this["E5FindPolicyPageUrlTemplate"]).Trim();
            }
        }

        [ConfigurationProperty("E5WorkUrlTemplate", DefaultValue = "", IsRequired = true)]
        [StringValidator]
        internal string E5WorkUrlTemplate
        {
            get
            {
                return ((string)this["E5WorkUrlTemplate"]).Trim();
            }
        }

        [ConfigurationProperty("PurePolicyUrlTemplate", DefaultValue = "", IsRequired = true)]
        [StringValidator]
        internal string PurePolicyUrlTemplate
        {
            get
            {
                return ((string)this["PurePolicyUrlTemplate"]).Trim();
            }
        }

        [ConfigurationProperty("PureClaimUrlTemplate", DefaultValue = "", IsRequired = true)]
        [StringValidator]
        internal string PureClaimUrlTemplate
        {
            get
            {
                return ((string)this["PureClaimUrlTemplate"]).Trim();
            }
        }    
    }
}