using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using EAAutoFramework.Base;
using EAAutoFramework.ConfigElement;

namespace EAAutoFramework.Config
{
    public static class ConfigReader
    {
        public static string InitializeTest()
        {
            return ConfigurationManager.AppSettings["AUT"].ToString();
        }

        public static void SetFrameworkSettings()
        {
            Settings.AUT = EATestConfiguration.EASettings.TestSettings["staging"].AUT;
            Settings.TestType = EATestConfiguration.EASettings.TestSettings["staging"].TestType;
            Settings.IsLog = EATestConfiguration.EASettings.TestSettings["staging"].IsLog;
            Settings.LogPath = EATestConfiguration.EASettings.TestSettings["staging"].LogPath;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), EATestConfiguration.EASettings.TestSettings["staging"].Browser);
        }
    }
}
