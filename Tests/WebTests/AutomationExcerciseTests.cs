#region Usings
using MyAutomationPractice.Tests.WebTests.PageObjects;
using MyAutomationPractice.Tests.WebTests.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
#endregion

namespace MyAutomationPractice.Tests.WebTests
{
    public class AutomationExcerciseTests:BaseWebTest
    {
        public string Driver { get; set; }
        public string? RegisteredUserName { get; set; }
        public string? RegisteredUserEmail { get; set; }
        public string? RegisteredUserPassword { get; set; }
        public string? RegisteredUserDob { get; set; }

        [Test]
        [Order(1)]
        public void TC1_TestRegisterUser()
        {
            AutomationExcerciseHomePage homePage = new AutomationExcerciseHomePage(_driver);
            var isLogoDisplayedOnHomePage = homePage.HeaderComponent.Logo.Displayed;
            Assert.That(isLogoDisplayedOnHomePage, Is.True, "Logo is not displayed on Home Page");

            var menuItemTexts = homePage.HeaderComponent.NavigationMenu.MenuItems.Select(x => x.Text).ToList();
            homePage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Signup / Login")).Click();
            DriverUtils.WaitForPageLoadComplete(_driver);
            AutomationExcerciseLoginPage loginPage = new AutomationExcerciseLoginPage(_driver);
            var signUpFormTitle = loginPage.SignUpForm.Title;
            Assert.That(signUpFormTitle.Text, Is.EqualTo("New User Signup!"), "Sign up to your account title is not displayed");

            Random rand = new Random();
            RegisteredUserName = TestDataUtil.GenerateRandomString(5);
            RegisteredUserEmail = TestDataUtil.GenerateRandomEmail();
            RegisteredUserPassword= TestDataUtil.GenerateRandomString(5);
            loginPage.SignUpForm.NameTextBox.SendKeys(RegisteredUserName);
            loginPage.SignUpForm.EmailAddressTextBox.SendKeys(RegisteredUserEmail);
            loginPage.SignUpForm.SignUpButton.Click();

            AutomationExcerciseSignUpPage signUpPage = new AutomationExcerciseSignUpPage(_driver);
            var isAccountInfoLabelPresent = signUpPage.EnterAccountInformationLabel.Displayed;
            Assert.That(isAccountInfoLabelPresent, Is.True, "Account info label is not displayed");

            signUpPage.MrRadioButton.Click();
            signUpPage.NameTextBox.Clear();
            signUpPage.NameTextBox.SendKeys(RegisteredUserName);
            signUpPage.PasswordTextBox.SendKeys(RegisteredUserPassword);
            var dob= TestDataUtil.GenerateRandomDOB(10, 70);
            signUpPage.DateOfBirthDayDropdown.SelectByValue(dob.Day);
            signUpPage.DateOfBirthMonthDropdown.SelectByText(dob.Month);
            signUpPage.DateOfBirthYearDropdown.SelectByText(dob.Year);
            signUpPage.SignUpForNewsLetterCheckBox.Click();
            signUpPage.SpecialOffersFromPartnersCheckBox.Click();

            signUpPage.FirstNameTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.LastNameTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.CompanyTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.AddressTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.Address2TextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.CountryDropdown.SelectByValue("Israel");
            signUpPage.StateTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.CityTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.ZipCodeTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.MobileTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));

            signUpPage.CreateAccButton.Click();
            AccountCreatedPage accCreatedPage = new AccountCreatedPage(_driver);
            var isAccountCreatedHeaderVisible = accCreatedPage.AccountCreatedHeader.Displayed;
            Assert.That(isAccountCreatedHeaderVisible, Is.True, "Account Created label is not displayed");
            accCreatedPage.ContinueButton.Click();

            AutomationExcerciseDashboardPage dashboardPage = new AutomationExcerciseDashboardPage(_driver);
            var isLOggedOptionAvailable = dashboardPage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Logged in")).Displayed;
            Assert.That(isLOggedOptionAvailable, Is.True, "Logged in as option is not displayed");

            dashboardPage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Delete Account")).Click();
            AccountDeleetdPage deletePage = new AccountDeleetdPage(_driver);
            var accDeletedTextVisible = deletePage.AccountDeletedHeader.Displayed;
            Assert.That(accDeletedTextVisible, Is.True, "Account deleted text not visible");
            deletePage.ContinueButton.Click();
        }

        [Test]
        [Order(2)]
        public void TC2_TestLoginWithCorrectEmailPassword_VerifyLoginSuccess()
        {
            RegisterUserWithoutDeletion();
            AutomationExcerciseHomePage homePage = new AutomationExcerciseHomePage(_driver);
            var isLogoDisplayedOnHomePage = homePage.HeaderComponent.Logo.Displayed;
            Assert.That(isLogoDisplayedOnHomePage, Is.True, "Logo is not displayed on Home Page");

            homePage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Logout")).Click();
            var menuItemTexts = homePage.HeaderComponent.NavigationMenu.MenuItems.Select(x => x.Text).ToList();
            homePage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Signup / Login")).Click();
            AutomationExcerciseLoginPage loginPage = new AutomationExcerciseLoginPage(_driver);
            var loginToAccountTitle = loginPage.LoginForm.Title;
            Assert.That(loginToAccountTitle.Text, Is.EqualTo("Login to your account"), "Login to your account title is not displayed");
            loginPage.LoginForm.EmailAddressTextBox.SendKeys(RegisteredUserEmail);
            loginPage.LoginForm.PasswordTextBox.SendKeys(RegisteredUserPassword);
            loginPage.LoginForm.LoginButton.Click();
            AutomationExcerciseDashboardPage dashboardPage = new AutomationExcerciseDashboardPage(_driver);
            var loggedInAsMessage = dashboardPage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Logged in as")).Displayed;
            Assert.That(loggedInAsMessage, Is.True, "Logged in as message is not displayed on login with correct creds");
        
            dashboardPage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Delete Account")).Click();
            AccountDeleetdPage deletePage = new AccountDeleetdPage(_driver);
            var accDeletedTextVisible=deletePage.AccountDeletedHeader.Displayed;
            Assert.That(accDeletedTextVisible, Is.True, "Account deleted text not visible");
            deletePage.ContinueButton.Click();
        }

        [Test]
        [Order(3)]
        [TestCase("dummy@gmail.com","dummyaccount")]
        public void TC3_TestLoginWithInCorrectEmailPassword_VerifyLoginFail(string incorrectEmail,string incorrectPassword)
        {
            AutomationExcerciseHomePage homePage = new AutomationExcerciseHomePage(_driver);
            var isLogoDisplayedOnHomePage=homePage.HeaderComponent.Logo.Displayed;
            Assert.That(isLogoDisplayedOnHomePage, Is.True, "Logo is not displayed on Home Page");

            var menuItemTexts = homePage.HeaderComponent.NavigationMenu.MenuItems.Select(x => x.Text).ToList();
            homePage.HeaderComponent.NavigationMenu.MenuItems.First(x=>x.Text.Contains("Signup / Login")).Click();
            DriverUtils.WaitForPageLoadComplete(_driver);
            AutomationExcerciseLoginPage loginPage = new AutomationExcerciseLoginPage(_driver);
            var loginToAccountTitle = loginPage.LoginForm.Title;
            Assert.That(loginToAccountTitle.Text, Is.EqualTo("Login to your account"), "Login to your account title is not displayed");
            loginPage.LoginForm.EmailAddressTextBox.SendKeys(incorrectEmail);
            loginPage.LoginForm.PasswordTextBox.SendKeys(incorrectPassword);
            loginPage.LoginForm.LoginButton.Click();
            var loginErrorMessage = loginPage.LoginForm.ErrorMessage;
            Assert.That(loginErrorMessage.Text, Is.EqualTo("Your email or password is incorrect!"), "Email/password incorrect message is not displayed on login with incorrect creds");
            Assert.That(loginErrorMessage.Displayed, Is.True, "Email/password incorrect message is not displayed on login with incorrect creds");
            Assert.That(loginErrorMessage.GetAttribute("style"),Does.Contain("red") , "Email/password incorrect message is not displayed on login with incorrect creds not in red color");
        }

        [Test]
        [Order(4)]
        public void TC4_TestLogOutUser()
        {
            RegisterUserWithoutDeletion();
            AutomationExcerciseHomePage homePage = new AutomationExcerciseHomePage(_driver);
            var isLogoDisplayedOnHomePage = homePage.HeaderComponent.Logo.Displayed;
            Assert.That(isLogoDisplayedOnHomePage, Is.True, "Logo is not displayed on Home Page");

            AutomationExcerciseDashboardPage dashboardPage = new AutomationExcerciseDashboardPage(_driver);
            var loggedInAsMessage = dashboardPage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Logged in as")).Displayed;
            Assert.That(loggedInAsMessage, Is.True, "Logged in as message is not displayed on login with correct creds");

            AutomationExcerciseLoginPage loginPage = new AutomationExcerciseLoginPage(_driver);
            homePage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Logout")).Click();
            var isUserOnSignInPage= loginPage.LoginForm.Title.Displayed;
            Assert.That(isUserOnSignInPage, Is.True, "User is not navigated to login page on logout");
        }

        [Test]
        [Order(5)]
        public void TC5_TestFifthTestCase()
        {

        }

        private void RegisterUserWithoutDeletion()
        {
            AutomationExcerciseHomePage homePage = new AutomationExcerciseHomePage(_driver);
            var isLogoDisplayedOnHomePage = homePage.HeaderComponent.Logo.Displayed;
            Assert.That(isLogoDisplayedOnHomePage, Is.True, "Logo is not displayed on Home Page");

            var menuItemTexts = homePage.HeaderComponent.NavigationMenu.MenuItems.Select(x => x.Text).ToList();
            homePage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Signup / Login")).Click();
            DriverUtils.WaitForPageLoadComplete(_driver);
            AutomationExcerciseLoginPage loginPage = new AutomationExcerciseLoginPage(_driver);
            var signUpFormTitle = loginPage.SignUpForm.Title;
            Assert.That(signUpFormTitle.Text, Is.EqualTo("New User Signup!"), "Sign up to your account title is not displayed");

            Random rand = new Random();
            RegisteredUserName = TestDataUtil.GenerateRandomString(5);
            RegisteredUserEmail = TestDataUtil.GenerateRandomEmail();
            RegisteredUserPassword = TestDataUtil.GenerateRandomString(5);
            loginPage.SignUpForm.NameTextBox.SendKeys(RegisteredUserName);
            loginPage.SignUpForm.EmailAddressTextBox.SendKeys(RegisteredUserEmail);
            loginPage.SignUpForm.SignUpButton.Click();

            AutomationExcerciseSignUpPage signUpPage = new AutomationExcerciseSignUpPage(_driver);
            var isAccountInfoLabelPresent = signUpPage.EnterAccountInformationLabel.Displayed;
            Assert.That(isAccountInfoLabelPresent, Is.True, "Account info label is not displayed");

            signUpPage.MrRadioButton.Click();
            signUpPage.NameTextBox.Clear();
            signUpPage.NameTextBox.SendKeys(RegisteredUserName);
            signUpPage.PasswordTextBox.SendKeys(RegisteredUserPassword);
            var dob = TestDataUtil.GenerateRandomDOB(10, 70);
            signUpPage.DateOfBirthDayDropdown.SelectByValue(dob.Day);
            signUpPage.DateOfBirthMonthDropdown.SelectByText(dob.Month);
            signUpPage.DateOfBirthYearDropdown.SelectByText(dob.Year);
            signUpPage.SignUpForNewsLetterCheckBox.Click();
            signUpPage.SpecialOffersFromPartnersCheckBox.Click();

            signUpPage.FirstNameTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.LastNameTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.CompanyTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.AddressTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.Address2TextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.CountryDropdown.SelectByValue("Israel");
            signUpPage.StateTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.CityTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.ZipCodeTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));
            signUpPage.MobileTextBox.SendKeys(TestDataUtil.GenerateRandomString(5));

            signUpPage.CreateAccButton.Click();
            AccountCreatedPage accCreatedPage = new AccountCreatedPage(_driver);
            var isAccountCreatedHeaderVisible = accCreatedPage.AccountCreatedHeader.Displayed;
            Assert.That(isAccountCreatedHeaderVisible, Is.True, "Account Created label is not displayed");
            accCreatedPage.ContinueButton.Click();

            AutomationExcerciseDashboardPage dashboardPage = new AutomationExcerciseDashboardPage(_driver);
            var isLOggedOptionAvailable = dashboardPage.HeaderComponent.NavigationMenu.MenuItems.First(x => x.Text.Contains("Logged in")).Displayed;
            Assert.That(isLOggedOptionAvailable, Is.True, "Logged in as option is not displayed");

        }
    }
}