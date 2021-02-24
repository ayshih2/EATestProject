using System;
using System.Threading;
using EAAutoFramework.Base;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using EAAutoFramework.Config;
using EAAutoFramework.Extensions;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {
        // must have App.config in it's local directory for you not to get a null pointer exception
        // string url = ConfigReader.InitializeTest();
        
        [TestMethod]
        public void TestMethod1()
        {
            
            //OpenBrowser(BrowserType.InternetExplorer);
            //DriverContext.Browser.GoToUrl(url); 

            //InternetExplorerOptions options = new InternetExplorerOptions();
            //options.EnableNativeEvents = false;
            //DriverContext.Driver = new InternetExplorerDriver(options);
            //LogHelpers.Write("Opened the browser :)");
            //DriverContext.Driver.Navigate().GoToUrl(Settings.AUT);
            //LogHelpers.Write("Navigated to the url!");

            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
            ExcelHelpers.PopulateInCollection(fileName);

            CurrentPage = GetInstance<HomePage>();
            //CurrentPage.As<HomePage>().CheckIfLoginExist();
            CurrentPage = CurrentPage.As<HomePage>().ClickLogin();
            System.Console.WriteLine(ExcelHelpers.ReadData(1, "UserName"));
            System.Console.WriteLine(ExcelHelpers.ReadData(1, "Password"));
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));
            CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
            // https://stackoverflow.com/questions/5574802/selenium-2-0b3-ie-webdriver-click-not-firing
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage.As<EmployeeListPage>().ClickCreateNew();
            Thread.Sleep(3000);
            DriverContext.Driver.Quit();
        }

        [TestMethod]
        public void CreateEmployee()
        {
            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
            ExcelHelpers.PopulateInCollection(fileName);

            CurrentPage = GetInstance<HomePage>();
            //CurrentPage.As<HomePage>().CheckIfLoginExist();
            CurrentPage = CurrentPage.As<HomePage>().ClickLogin();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));
            CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
         
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage = CurrentPage.As<EmployeeListPage>().ClickCreateNew();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage.As<CreateEmployeePage>().CreateEmployee("name", "10000", "0", "10", "name@email.com");
            CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
            Thread.Sleep(3000);
            DriverContext.Driver.Quit();
        }

        /*
        [TestMethod]
        public void TableOperation()
        {
            
            LogHelpers.CreateLogFile();
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.EnableNativeEvents = false;
            DriverContext.Driver = new InternetExplorerDriver(options);
            DriverContext.Driver.Navigate().GoToUrl(Settings.AUT);

            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
            ExcelHelpers.PopulateInCollection(fileName);

            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));
            // https://stackoverflow.com/questions/5574802/selenium-2-0b3-ie-webdriver-click-not-firing
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.CurrentWindowHandle);
            DriverContext.Driver.WaitForPageLoaded();
            var table = CurrentPage.As<EmployeeListPage>().GetEmployeeList();
            HtmlTableHelper.ReadTable(table);
            DriverContext.Driver.Quit();
            //HtmlTableHelper.PerformActionOnCell("5", "Name", "Ramesh", "Edit");
        }*/
    }
}
