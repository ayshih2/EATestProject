using System;
using System.Diagnostics;
using EAAutoFramework.Base;
using OpenQA.Selenium;

namespace EAAutoFramework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(drvr => {
                string state = drvr.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, 10); // ten seconds timeout
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute = (arg) =>
            {
                try
                {
                    return condition(arg);
                } catch (Exception e)
                {
                    return false;
                }
            };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        internal static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }
    }
}
