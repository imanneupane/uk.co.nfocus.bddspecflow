using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using uk.co.nfocus.bddspecflow.POM_pages;
using static uk.co.nfocus.bddspecflow.Support.Helpers;
using NUnit.Framework;
using static uk.co.nfocus.bddspecflow.Support.Baseclass;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class LogoutStepDefinitions
    {
        readonly string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/";
        [Given(@"I am logged in to an account")]
        public void GivenIAmLoggedInToAnAccount()
        {
            driver.Url = baseUrl;
            Pages_POM accountPage = new Pages_POM(driver);
            accountPage.gotoAccountPage();
            Login_POM login = new Login_POM(driver);
            login.LoginExpected("imanneupane@yahoo.com", "Neupane@12345");
            WaitHelper(driver, 10, By.LinkText("Dashboard"));
        }

        [When(@"I am in my account page")]
        public void WhenIAmInMyAccountPage()
        {
            Logout_POM check = new Logout_POM(driver);
            check.MyAccount();
        }

        [Then(@"I can log out")]
        public void ThenICanLogOut()
        {
            Logout_POM logoff = new Logout_POM(driver);
            logoff.Logout();
            driver.Quit();
        }
    }
}
