//write copyright section here
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class AutomationExcerciseLoginPageSignUpForm
    {
        public IWebDriver Driver { get; set; }
        public AutomationExcerciseLoginPageSignUpForm(IWebDriver _driver)
        {
            Driver = _driver;

        }

        private IWebElement SignUpForm=> Driver.FindElement(By.XPath("//div[@class='signup-form']"));

        //properties
        public IWebElement Title
        {
            get
            {
                return SignUpForm.FindElement(By.XPath("./descendant::h2"));
            }
        }

        public IWebElement EmailAddressTextBox
        {
            get
            {
                return SignUpForm.FindElement(By.XPath("./descendant::input[@data-qa='signup-email']"));
            }
        }

        public IWebElement NameTextBox
        {
            get
            {
                return SignUpForm.FindElement(By.XPath("./descendant::input[@data-qa='signup-name']"));
            }
        }

        public IWebElement SignUpButton
        {
            get
            {
                return SignUpForm.FindElement(By.XPath("./descendant::button[@data-qa='signup-button']"));
            }
        }
    }
}
