using System;
using EAAutoFramework.Base;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages
{
    internal class CreateEmployeePage : BasePage
    {
        /*[FindsBy(How = How.Id, Using = "Name")]
        IWebElement txtName { get; set; } */

        public IWebElement txtName => DriverContext.Driver.FindElement(By.Id("Name"));
        public IWebElement txtSalary => DriverContext.Driver.FindElement(By.Id("Salary"));
        public IWebElement txtDurationWorked => DriverContext.Driver.FindElement(By.Id("DurationWorked"));
        public IWebElement txtGrade => DriverContext.Driver.FindElement(By.Id("Grade"));
        public IWebElement btnCreateEmployee => DriverContext.Driver.FindElement(By.XPath("//input[@value='Create']"));
        public IWebElement txtEmail => DriverContext.Driver.FindElement(By.Id("Email"));

        internal void ClickCreateButton()
        {
            btnCreateEmployee.Submit();
        }

        internal void CreateEmployee(string name, string salary, string durationworked, string grade, string email)
        {
            txtName.SendKeys(name);
            txtSalary.SendKeys(salary);
            txtDurationWorked.SendKeys(durationworked);
            txtGrade.SendKeys(grade);
            txtEmail.SendKeys(email);
        }
    }
}
