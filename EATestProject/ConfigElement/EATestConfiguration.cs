using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.ConfigElement
{
    class EATestConfiguration : ConfigurationSection
    {
        private static EATestConfiguration _testConfig = (EATestConfiguration)ConfigurationManager.GetSection("EATestConfiguration");
       
        public static EATestConfiguration EASettings { get { return _testConfig; } }

        [ConfigurationProperty("testSettings")]
        public EAFrameworkElementCollection TestSettings { get { return (EAFrameworkElementCollection)base["testSettings"]; } }
    }
}
