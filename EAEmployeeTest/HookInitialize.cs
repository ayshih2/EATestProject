using EAAutoFramework.Base;
using Sikuli4Net.sikuli_UTIL;
using TechTalk.SpecFlow;

namespace EAEmployeeTest
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(BrowserType.InternetExplorer)
        {
            //APILauncher launch = new APILauncher(true);
            //launch.Start();
            InitializeSettings();
            NavigateSite();
        }

        [BeforeFeature]
        public static void TestStart()
        {
            HookInitialize init = new HookInitialize();
        }
    }
}
