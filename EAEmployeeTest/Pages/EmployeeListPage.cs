using System;
using System.Collections.Generic;
using System.Linq;
using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace EAEmployeeTest.Pages
{
    internal class EmployeeListPage : BasePage
    {
        public IWebElement txtSearch => DriverContext.Driver.FindElement(By.Name("searchTerm"));
        public IWebElement lnkCreateNew => DriverContext.Driver.FindElement(By.LinkText("Create New"));
        public IWebElement tblEmployeeList => DriverContext.Driver.FindElement(By.ClassName("table"));
        //public IReadOnlyCollection<IWebElement> deleteBtns => DriverContext.Driver.FindElements(By.LinkText("Delete"));


        public CreateEmployeePage ClickCreateNew()
        {
            //DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Create New")));
            lnkCreateNew.Click();
            return new CreateEmployeePage();
        }

        public IWebElement GetEmployeeList()
        {
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("table")));
            return tblEmployeeList;
        }

        public DeletePage DeleteEmployee(int idx)
        {
            //var deleteBtns = DriverContext.Driver.FindElements(By.LinkText("Delete"));
            var deleteBtns = DriverContext.Driver.FindElements(By.LinkText("Delete"));
            deleteBtns[idx].Click();
            return GetInstance<DeletePage>();
        }
    }
}
