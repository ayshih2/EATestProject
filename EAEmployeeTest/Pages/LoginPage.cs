using System;
using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {
        public IWebElement txtUserName => DriverContext.Driver.FindElement(By.Id("UserName"));
        public IWebElement txtPassword => DriverContext.Driver.FindElement(By.Id("Password"));
        public IWebElement btnLogin => DriverContext.Driver.FindElement(By.CssSelector("input.btn"));

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
    }
}