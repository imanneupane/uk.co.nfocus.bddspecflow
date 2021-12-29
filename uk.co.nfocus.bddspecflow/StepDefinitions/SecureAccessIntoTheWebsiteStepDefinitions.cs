using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;

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
            driver.FindElement(By.Id("username")).SendKeys("");
            driver.FindElement(By.Id("password")).SendKeys("");
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            throw new PendingStepException();
        }
    }
}
