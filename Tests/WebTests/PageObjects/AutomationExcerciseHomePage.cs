//write copyright section here
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class AutomationExcerciseHomePage
    {
        public IWebDriver Driver { get; set; }
        public AutomationExcerciseHomePage(IWebDriver _driver)
        {
            Driver = _driver;

        }

        //properties
        public AutomationExcerciseHeaderComponent HeaderComponent
        {
            get
            {
                return new AutomationExcerciseHeaderComponent(Driver);
            }
        }

        public void LaunchHomePage()
        {
            Driver.Navigate().GoToUrl("https://www.automationexercise.com/");
        }
    }
}
