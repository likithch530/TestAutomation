using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.Utilities
{
    public static class DriverUtils
    {
        public static void WaitForPageLoadComplete(this OpenQA.Selenium.IWebDriver driver, int timeoutInSeconds = 30)
        {
            if (driver == null)
                throw new ArgumentNullException(nameof(driver));
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => ((OpenQA.Selenium.IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
