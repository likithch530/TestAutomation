//write copyright section here
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class AutomationExcerciseLoginPageLoginForm
    {
        public IWebDriver Driver { get; set; }
        public AutomationExcerciseLoginPageLoginForm(IWebDriver _driver)
        {
            Driver = _driver;

        }

        private IWebElement LoginForm => Driver.FindElement(By.XPath("//div[@class='login-form']"));

        //properties
        public IWebElement Title
        {
            get
            {
                return LoginForm.FindElement(By.XPath("./descendant::h2"));
            }
        }

        public IWebElement EmailAddressTextBox
        {
            get
            {
                return LoginForm.FindElement(By.XPath("./descendant::input[@data-qa='login-email']"));
            }
        }

        public IWebElement PasswordTextBox
        {
            get
            {
                return LoginForm.FindElement(By.XPath("./descendant::input[@data-qa='login-password']"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return LoginForm.FindElement(By.XPath("./descendant::button[@data-qa='login-button']"));
            }
        }

        public IWebElement ErrorMessage
        {
            get
            {
                return LoginForm.FindElement(By.XPath("./descendant::p[@style='color: red;']"));
            }
        }
    }
}
