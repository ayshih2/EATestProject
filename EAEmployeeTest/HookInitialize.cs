using EAAutoFramework.Base;
using TechTalk.SpecFlow;

namespace EAEmployeeTest
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(BrowserType.InternetExplorer)
        {
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
