using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using uk.co.nfocus.bddspecflow.POM_pages;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class SecureAccessIntoTheWebsiteStepDefinitions: Support.Baseclass
    {
        IWebDriver driver = new ChromeDriver();
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Url = baseUrl;
            driver.Manage().Window.Maximize();
            Pages_POM accountPage = new Pages_POM(driver);
            accountPage.gotoAccountPage();
        }

        [When(@"I use a valid username and password")]
        public void WhenIUseAValidUsernameAndPassword()
        {
            Login_POM login = new Login_POM(driver);
            login.Username("imanneupane@yahoo.com");
            login.Password("Neupane@12345");
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
