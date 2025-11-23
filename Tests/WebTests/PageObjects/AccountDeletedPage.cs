//write copyright section here
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class AccountDeleetdPage
    {
        public IWebDriver Driver { get; set; }
        public AccountDeleetdPage(IWebDriver _driver)
        {
            Driver = _driver;

        }

        public IWebElement AccountDeletedHeader => Driver.FindElement(By.XPath("//section[@id]/descendant::h2[@data-qa='account-deleted']"));

        public IWebElement ContinueButton => Driver.FindElement(By.XPath("//section[@id]/descendant::a[@data-qa='continue-button']"));
        public IWebElement Text1 => Driver.FindElement(By.XPath("//section[@id]/descendant::p[1]"));

        public IWebElement Text2 => Driver.FindElement(By.XPath("//section[@id]/descendant::p[2]"));

    }
}
