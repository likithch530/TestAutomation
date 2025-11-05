using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class OrangeHrmLoginPage
    {
        public  IWebDriver Driver { get; set; }
        public OrangeHrmLoginPage(IWebDriver _driver)
        {
            Driver = _driver;
                
        }
        //properties
        public IWebElement UserNameTextBox
        {
            get
            {
                return Driver.FindElement(By.Id("txtUsername"));
            }
        }

        public IWebElement PasswordTextBox
        {
            get
            {
                return Driver.FindElement(By.Id("txtPassword"));
            }
        }

        public IWebElement RememberMeCheckBoxx
        {
            get
            {
                return Driver.FindElement(By.Id("rememberMe"));
            }
        }

        public IWebElement SubmitButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//button[@type='submit']"));
            }
        }

        //Methods
    }
}
