using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using uk.co.nfocus.bddspecflow.POM_pages;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class SecureAccessIntoTheWebsiteStepDefinitions
    {
        IWebDriver driver = new ChromeDriver();
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.FindElement(By.LinkText("Dismiss")).Click();
            driver.FindElement(By.LinkText("My account")).Click();
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
