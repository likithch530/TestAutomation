//write copyright section here
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class AutomationExcerciseDashboardPage
    {
        public IWebDriver Driver { get; set; }
        public AutomationExcerciseDashboardPage(IWebDriver _driver)
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
    }
}
