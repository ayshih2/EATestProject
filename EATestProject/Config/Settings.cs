using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAAutoFramework.Base;

namespace EAAutoFramework.Config
{
    public static class Settings
    {
        public static string TestType { get; set; }

        public static string AUT { get; set; }

        public static string BuildName { get; set; }

        public static BrowserType BrowserType { get; set; }

        public static string IsLog { get; set; }

        public static string IsReporting { get; set; }

        public static string LogPath { get; set; }

        public static SqlConnection ApplicationCon { get; set; }

        public static string AppConnectionString { get; set; }
    }
}
