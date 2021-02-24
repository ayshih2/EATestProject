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

        //[FindsBy(How = How.LinkText, Using = "Log in")]
        //IWebElement lnkLogin { get; set; }
        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        IWebElement lnkEmployeeList { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Manage']")]
        IWebElement lnkLoggedInUser { get; set; }

        [FindsBy(How = How.LinkText, Using = "Log off")]
        IWebElement lnkLogoff { get; set; }

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

        public EmployeeListPage ClickEmployeeList()
        {
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Employee List")));
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            lnkEmployeeList.Click();
            return GetInstance<EmployeeListPage>();
        }
    }
}
