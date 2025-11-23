//write copyright section here
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomationPractice.Tests.WebTests.PageObjects
{
    public class AutomationExcerciseSignUpPage
    {
        public IWebDriver Driver { get; set; }
        public AutomationExcerciseSignUpPage(IWebDriver _driver)
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

        public IWebElement EnterAccountInformationLabel
        {
            get
            {
                return Driver.FindElement(By.XPath("//section[@id='form']/descendant::h2/b"));
            }
        }

        public IWebElement MrRadioButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='radio' and contains(@id,'gender1')]"));
            }
        }

        public IWebElement MrsRadioButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class='radio' and contains(@id,'gender2')]"));
            }
        }

        public IWebElement NameTextBox
        {
            get
            {
                return Driver.FindElement(By.XPath("//input[@id='name']"));
            }
        }

        public IWebElement EmailTextBox=>Driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement PasswordTextBox => Driver.FindElement(By.XPath("//input[@id='password']"));
        public SelectElement DateOfBirthDayDropdown => new SelectElement(Driver.FindElement(By.XPath("//*[@id='days']")));
        public SelectElement DateOfBirthMonthDropdown => new SelectElement(Driver.FindElement(By.XPath("//*[@id='months']")));
        public SelectElement DateOfBirthYearDropdown => new SelectElement(Driver.FindElement(By.XPath("//*[@id='years']")));
        public IWebElement SignUpForNewsLetterCheckBox => Driver.FindElement(By.XPath("//input[@id='newsletter']"));
        public IWebElement SpecialOffersFromPartnersCheckBox => Driver.FindElement(By.XPath("//input[@id='optin']"));

        public IWebElement FirstNameTextBox => Driver.FindElement(By.XPath("//input[@id='first_name']"));

        public IWebElement LastNameTextBox => Driver.FindElement(By.XPath("//input[@id='last_name']"));

        public IWebElement CompanyTextBox => Driver.FindElement(By.XPath("//input[@id='company']"));

        public IWebElement AddressTextBox => Driver.FindElement(By.XPath("//input[@id='address1']"));

        public IWebElement Address2TextBox => Driver.FindElement(By.XPath("//input[@id='address2']"));
        public IWebElement StateTextBox => Driver.FindElement(By.XPath("//input[@id='state']"));
        public IWebElement CityTextBox => Driver.FindElement(By.XPath("//input[@id='city']"));
        public IWebElement ZipCodeTextBox => Driver.FindElement(By.XPath("//input[@id='zipcode']"));
        public IWebElement MobileTextBox => Driver.FindElement(By.XPath("//input[@id='mobile_number']"));
        public SelectElement CountryDropdown => new SelectElement(Driver.FindElement(By.XPath("//*[@id='country']")));

        public IWebElement CreateAccButton => Driver.FindElement(By.XPath("//button[@data-qa='create-account']"));
    }
}
