using System;
using System.Threading;
using EAAutoFramework.Base;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using EAAutoFramework.Config;
using EAAutoFramework.Extensions;
using OpenQA.Selenium;
using Sikuli4Net.sikuli_UTIL;
//using Sikuli4Net.sikuli_REST;
using SikuliSharp;
using OpenQA.Selenium.Support.UI;
using Sikuli4Net.sikuli_REST;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {
        // must have App.config in it's local directory for you not to get a null pointer exception
        // string url = ConfigReader.InitializeTest();

        public void LoadCredentials()
        {
            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
            ExcelHelpers.PopulateInCollection(fileName);
        }
        
        [TestMethod]
        public void GoToAboutPage()
        {

            //OpenBrowser(BrowserType.InternetExplorer);
            //DriverContext.Browser.GoToUrl(url); 

            //InternetExplorerOptions options = new InternetExplorerOptions();
            //options.EnableNativeEvents = false;
            //DriverContext.Driver = new InternetExplorerDriver(options);
            //LogHelpers.Write("Opened the browser :)");
            //DriverContext.Driver.Navigate().GoToUrl(Settings.AUT);
            //LogHelpers.Write("Navigated to the url!");

            LoadCredentials();

            CurrentPage = GetInstance<HomePage>();
            CurrentPage.As<HomePage>().ClickAboutTab();
            Thread.Sleep(3000);
            DriverContext.Driver.Quit();
        }

        [TestMethod]
        public void ClickUdemyLink()
        {
            LoadCredentials();

            CurrentPage = GetInstance<HomePage>();
            CurrentPage.As<HomePage>().ClickUdemyBtn();
            Thread.Sleep(10000);
            DriverContext.Driver.Quit();
        }

        [TestMethod]
        public void TestSikuli()
        {
            APILauncher launcher = new APILauncher(true);
            launcher.Start();
            Pattern visitNowBtn = new Pattern(@"C:\Patterns\RegisterButton.png");
            Screen src = new Screen();
            src.Click(visitNowBtn);
            
            Thread.Sleep(3000);
            launcher.Stop();
            //DriverContext.Driver.Quit();

            /*using (var session = Sikuli.CreateSession())
            {
                //Login
                var username = Patterns.FromFile(@"C:\Patterns\RegisterButton.png", 0.9f);
                session.Click(username);

            }*/
        }

        [TestMethod]
        public void DeleteEmployee()
        {
            LoadCredentials();

            CurrentPage = GetInstance<HomePage>();
            CurrentPage = CurrentPage.As<HomePage>().ClickLogin();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));
            CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
            CurrentPage = CurrentPage.As<EmployeeListPage>().DeleteEmployee(1);
            //CurrentPage = CurrentPage.As<DeletePage>().GoBackToList();
            CurrentPage.As<DeletePage>().ConfirmDelete();
            Thread.Sleep(3000);
            DriverContext.Driver.Quit();
        }

        [TestMethod]
        public void EditEmployee()
        {
            LoadCredentials();

            CurrentPage = GetInstance<HomePage>();
            CurrentPage = CurrentPage.As<HomePage>().ClickLogin();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));
            CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            DriverContext.Driver.Navigate().Refresh();
            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
            CurrentPage = CurrentPage.As<EmployeeListPage>().ClickEdit(0);
            CurrentPage.As<EditEmployeePage>().UpdateSalary("4000");
            CurrentPage.As<EditEmployeePage>().ClickSaveEditBtn();
            Thread.Sleep(3000);
            DriverContext.Driver.Quit();
        }

        [TestMethod]
        public void CreateEmployee()
        {
            LoadCredentials();

            CurrentPage = GetInstance<HomePage>();
            //CurrentPage.As<HomePage>().CheckIfLoginExist();
            CurrentPage = CurrentPage.As<HomePage>().ClickLogin();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));
            CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
            // https://stackoverflow.com/questions/5574802/selenium-2-0b3-ie-webdriver-click-not-firing 
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage = CurrentPage.As<EmployeeListPage>().ClickCreateNew();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage.As<CreateEmployeePage>().CreateEmployee("john appleseed", "10000", "0", "10", "ja@testemail.com");
            CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
            Thread.Sleep(3000);
            DriverContext.Driver.Quit();
        }

        [TestMethod]
        public void HandleTable()
        {
            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
            ExcelHelpers.PopulateInCollection(fileName);

            CurrentPage = GetInstance<HomePage>();
            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            var table = CurrentPage.As<EmployeeListPage>().GetEmployeeList();
                
            // ~ 17-30 mins to execute
            HtmlTableHelper.ReadTable(table);
            HtmlTableHelper.PerformActionOnCell("1", "Name", "Karthik", "Delete");
            Thread.Sleep(3000);
            DriverContext.Driver.Quit();
        }
    }
}
