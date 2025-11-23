//write copyright section here
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class AutomationExcerciseLoginPage
    {
        public IWebDriver Driver { get; set; }
        public AutomationExcerciseLoginPage(IWebDriver _driver)
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

        public AutomationExcerciseLoginPageLoginForm LoginForm
        {
            get
            {
                return new AutomationExcerciseLoginPageLoginForm(Driver);
            }
        }

        public AutomationExcerciseLoginPageSignUpForm SignUpForm
        {
            get
            {
                return new AutomationExcerciseLoginPageSignUpForm(Driver);
            }
        }
    }
}
