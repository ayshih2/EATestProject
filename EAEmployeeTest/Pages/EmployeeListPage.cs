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

        public CreateEmployeePage ClickCreateNew()
        {
            //DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Create New")));
            lnkCreateNew.Click();
            return new CreateEmployeePage();
        }

        public IWebElement GetEmployeeList()
        {
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("table")));
            return tblEmployeeList;
        }

        public DeletePage DeleteEmployee(int idx)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 60));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.LinkText("Delete")));
            var deleteBtn = DriverContext.Driver.FindElements(By.LinkText("Delete"));
            deleteBtn[idx].Click();

            return GetInstance<DeletePage>();
        }

        public EditEmployeePage ClickEdit(int idx)
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 60));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.LinkText("Edit")));
            var editBtns = DriverContext.Driver.FindElements(By.LinkText("Edit"));
            editBtns[idx].Click();
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            return GetInstance<EditEmployeePage>();
        }
    }
}
