using System;
using EAAutoFramework.Base;
using EAAutoFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace EAEmployeeTest.Pages
{
    internal class HomePage : BasePage
    {
        public IWebElement lnkLogin => DriverContext.Driver.FindElement(By.Id("loginLink"));
        public IWebElement lnkEmployeeList => DriverContext.Driver.FindElement(By.LinkText("Employee List"));
        public IWebElement aboutBtn => DriverContext.Driver.FindElement(By.LinkText("About"));
        public IWebElement udemyBtn => DriverContext.Driver.FindElement(By.CssSelector("body > div.container.body-content > div.row > div:nth-child(2) > p:nth-child(3) > a:nth-child(1)"));
        public IWebElement lnkLoggedInUser => DriverContext.Driver.FindElement(By.XPath("//a[@title='Manage']"));
        public IWebElement lnkLogoff => DriverContext.Driver.FindElement(By.LinkText("Log off"));

        internal void CheckIfLoginExist()
        {
            lnkLogin.AssertElementPresent();
        }

        internal LoginPage ClickLogin()
        {
            lnkLogin.Click();
            return GetInstance<LoginPage>();
        }

        internal string GetLoggedInUser()
        {
            return lnkLoggedInUser.GetLinkText();
        }

        public void ClickAboutTab()
        {
            aboutBtn.Click();
        }

        public void ClickUdemyBtn()
        {
            udemyBtn.Click();
        }

        public EmployeeListPage ClickEmployeeList()
        {
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Employee List")));
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            element.Click();
            return GetInstance<EmployeeListPage>();
        }
    }
}
