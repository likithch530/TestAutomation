using MyAutomationPractice.Tests.WebTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests
{
    public class BaseWebTest
    {
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void OnceBeforeAllTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(d =>((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");
        }

        [SetUp]
        public void OnceBeforeEachTest()
        {
            
        }

        [TearDown]
        public void OnceAfterEachTests()
        {
           
        }

        [OneTimeTearDown]
        public void OnceAfterAllTests()
        {
            _driver.Dispose();
            _driver.Quit();
        }
    }
}
