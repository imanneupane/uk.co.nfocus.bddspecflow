using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using uk.co.nfocus.bddspecflow.POM_pages;
using static uk.co.nfocus.bddspecflow.Support.Baseclass;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class SecureAccessIntoTheWebsiteStepDefinitions
    {
        readonly string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/";
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Url = baseUrl;
            Pages_POM accountPage = new Pages_POM(driver);
            accountPage.gotoAccountPage();
        }

        [When(@"I use a valid (.*) and (.*)")]
        public void WhenIUseAValidImanneupaneYahoo_ComAndNeupane(string Username, string Password)
        {
            Login_POM login = new Login_POM(driver);
            login.Username(Username);
            login.Password(Password);
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            Login_POM login = new Login_POM(driver);
            login.LoginSubmit();
            driver.Quit();
        }
    }
}
