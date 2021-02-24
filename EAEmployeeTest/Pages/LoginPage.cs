using System;
using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {
        /*
        // objects for login page
        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        public IWebElement lnkEmployeeList { get; set; }*/

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        public IWebElement btnLogin { get; set; }
    
        public void Login(string userName, string password)
        {
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("UserName")));
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
            //btnLogin.Submit();
        }

        public HomePage ClickLoginButton()
        {
            btnLogin.Submit();
            return GetInstance<HomePage>();
        }

        /*
        public void ClickLoginLink()
        {
            lnkLogin.Click();
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("UserName")));
        }
    
        public EmployeeListPage ClickEmployeeList()
        {
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Employee List")));
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            lnkEmployeeList.Click();
            return GetInstance<EmployeeListPage>();
        }*/
    }
}