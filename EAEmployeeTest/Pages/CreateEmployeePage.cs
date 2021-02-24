using System;
using EAAutoFramework.Base;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages
{
    internal class CreateEmployeePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "Name")]
        IWebElement txtName { get; set; }

        [FindsBy(How = How.Id, Using = "Salary")]
        IWebElement txtSalary { get; set; }

        [FindsBy(How = How.Id, Using = "DurationWorked")]
        IWebElement txtDurationWorked { get; set; }

        [FindsBy(How = How.Id, Using = "Grade")]
        IWebElement txtGrade { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        IWebElement txtEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        IWebElement btnCreateEmployee { get; set; }

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
