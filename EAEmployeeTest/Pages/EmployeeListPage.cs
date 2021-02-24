using System;
using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace EAEmployeeTest.Pages
{
    internal class EmployeeListPage : BasePage
    {

        [FindsBy(How = How.Name, Using = "searchTerm")]
        IWebElement txtSearch { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        IWebElement lnkCreateNew { get; set; }

        [FindsBy(How = How.ClassName, Using = "table")]
        IWebElement tblEmployeeList { get; set; }

        public CreateEmployeePage ClickCreateNew()
        {
            //DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            lnkCreateNew.Click();
            return new CreateEmployeePage();
        }

        public IWebElement GetEmployeeList()
        {
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("table")));
            return tblEmployeeList;
        }
    }
}
