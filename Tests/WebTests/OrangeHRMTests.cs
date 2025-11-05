#region Usings
using MyAutomationPractice.Tests.WebTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
#endregion

namespace MyAutomationPractice.Tests.WebTests
{
    public class OrangeHRMTests:BaseWebTest
    {
        [Test]
        public void TC1_TestAdminLoginUnSuccessfullWithWrongPassword()
        {
            OrangeHrmLoginPage loginPage = new OrangeHrmLoginPage(_driver);
            loginPage.UserNameTextBox.SendKeys("admin");
            loginPage.PasswordTextBox.SendKeys("L2bZBK@g6p");
            loginPage.RememberMeCheckBoxx.Click();
            loginPage.SubmitButton.Click();
            var currentUrl = _driver.Url;
            Assert.That(currentUrl, Does.EndWith("retryLogin"), "Login has not failed with wrong creds");
        }

        [Test]
        public void TC2_TestAdminLoginSuccessfullWithCorrectPassword()
        {
            OrangeHrmLoginPage loginPage = new OrangeHrmLoginPage(_driver);
            loginPage.UserNameTextBox.SendKeys("admin");
            loginPage.PasswordTextBox.SendKeys("ravi424@RAVI424!");
            loginPage.RememberMeCheckBoxx.Click();
            loginPage.SubmitButton.Click();
            var currentUrl = _driver.Url;
            Assert.That(currentUrl, Does.EndWith("retryLogin"), "Login has not failed with wrong creds");
        }
    }
}