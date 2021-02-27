using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EAEmployeeTest.Pages
{
    class DeletePage : BasePage
    {
        public IWebElement deleteBtn => DriverContext.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > form > div > input"));
        public IWebElement backToListBtn => DriverContext.Driver.FindElement(By.LinkText("Back to List"));

        public void ConfirmDelete()
        {
            //var deleteBtns = DriverContext.Driver.FindElements(By.LinkText("Delete"));
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.container.body-content > div > form > div > input")));
            deleteBtn.Click();
        }

        public EmployeeListPage GoBackToList()
        {
            var wait = new WebDriverWait(DriverContext.Driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Back to List")));
            backToListBtn.Click();
            return GetInstance<EmployeeListPage>();
        }
    }
}
