using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAAutoFramework.Base;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages
{
    class EditEmployeePage : BasePage
    {
        public IWebElement txtName => DriverContext.Driver.FindElement(By.Id("Name"));
        public IWebElement txtSalary => DriverContext.Driver.FindElement(By.Id("Salary"));
        public IWebElement txtDurationWorked => DriverContext.Driver.FindElement(By.Id("DurationWorked"));
        public IWebElement txtGrade => DriverContext.Driver.FindElement(By.Id("Grade"));
        public IWebElement saveEditBtn => DriverContext.Driver.FindElement(By.CssSelector("body > div.container.body-content > form > div > div:nth-child(9) > div > input"));
        public IWebElement txtEmail => DriverContext.Driver.FindElement(By.Id("Email"));

        internal EmployeeListPage ClickSaveEditBtn()
        {
            saveEditBtn.Submit();
            return GetInstance<EmployeeListPage>();
        }

        internal void UpdateName(string name)
        {
            txtName.Clear();
            txtName.SendKeys(name);
        }

        internal void UpdateSalary(string salary)
        {
            txtSalary.Clear();
            txtSalary.SendKeys(salary);
        }

        internal void UpdateDurationWorked(string durationWorked)
        {
            txtDurationWorked.Clear();
            txtDurationWorked.SendKeys(durationWorked);
        }

        internal void UpdateGrade(string grade)
        {
            txtGrade.Clear();
            txtGrade.SendKeys(grade);
        }

        internal void UpdateEmail(string email)
        {
            txtEmail.Clear();
            txtEmail.SendKeys(email);
        }
    }
}
