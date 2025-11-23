//write copyright section here
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class AutomationExcerciseHeaderComponent
    {
        public IWebDriver Driver { get; set; }
        public AutomationExcerciseHeaderComponent(IWebDriver _driver)
        {
            Driver = _driver;

        }

        //properties
        public IWebElement Logo
        {
            get
            {
                return Driver.FindElement(By.XPath("//header/descendant::img[@alt='Website for automation practice']"));
            }
        }

        public AutomationExcerciseHeaderComponentNavigationMenu NavigationMenu
        {
            get
            {
                return new AutomationExcerciseHeaderComponentNavigationMenu(Driver,"//header/descendant::div[@class=contains(@class,'shop-menu')]/ul");
            }
        }
    }
}
