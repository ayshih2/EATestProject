using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1
    {
        string url = "http://eaapp.somee.com/";
        private IWebDriver _driver;

        [TestMethod]
        public void TestMethod1()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.EnableNativeEvents = false;
            _driver = new InternetExplorerDriver(options);
            _driver.Navigate().GoToUrl(url);
            Login();
            _driver.Quit();
        }

        public void Login()
        {
            _driver.FindElement(By.Id("loginLink")).Click();
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            // must wait, otherwise webdriver won't be able to find the username/password input boxes
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("UserName")));
            _driver.FindElement(By.Id("UserName")).SendKeys("admin");
            _driver.FindElement(By.Id("Password")).SendKeys("password");
            _driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[4]/div/input")).Submit();
        }
    }
}
