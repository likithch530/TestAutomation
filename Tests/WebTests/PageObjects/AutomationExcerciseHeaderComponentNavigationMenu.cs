using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class AutomationExcerciseHeaderComponentNavigationMenu
    {
        public IWebDriver Driver { get; set; }
        public string _menuIdentifier { get; set; }
        public AutomationExcerciseHeaderComponentNavigationMenu(IWebDriver _driver,string identifier)
        {
            Driver = _driver;
            _menuIdentifier = identifier;
        }

        private IWebElement Menu=>Driver.FindElement(By.XPath(_menuIdentifier));

        //properties
        public ReadOnlyCollection<IWebElement> MenuItems
        {
            get
            {
                return Menu.FindElements(By.XPath("./li/a"));
            }
        }
    }
}
