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
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://ravikumar424-trials719.orangehrmlive.com");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(d =>((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");
        }

        [SetUp]
        public void OnceBeforeEachTest()
        {
            // Optional: can be used for pre-test setup
        }

        [TearDown]
        public void OnceAfterEachTests()
        {
            // Optional: clean up cookies or session between tests
            //_driver.Manage().Cookies.DeleteAllCookies();
        }

        [OneTimeTearDown]
        public void OnceAfterAllTests()
        {
            _driver.Quit();
        }
    }
}
