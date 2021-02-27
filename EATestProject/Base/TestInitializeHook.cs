using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using OpenQA.Selenium.IE;

namespace EAAutoFramework.Base
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserType Browser;

        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeSettings()
        {
            ConfigReader.SetFrameworkSettings();
            // set logs
            LogHelpers.CreateLogFile();
            OpenBrowser(BrowserType.InternetExplorer);
        }

        // (41) not currently in use bc it's buggy with internet explorer
        private void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    // need to set options or else click won't work -- IEDriver bug (?)
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.EnableNativeEvents = false;
                    DriverContext.Driver = new InternetExplorerDriver(options);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    break;
                case BrowserType.Chrome:
                    break;
                default:
                    break;
            }
        }
        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
        }
    }
}
