using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class AdditemStepDefinitions
    {
        IWebDriver driver = new ChromeDriver();
        [Given(@"I am on Shop page")]
        public void GivenIAmOnShopPage()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            driver.FindElement(By.LinkText("Shop")).Click();
        }

        [When(@"I select an item")]
        public void WhenISelectAnItem()
        {
            throw new PendingStepException(); 
        }

        [When(@"I add an item to the cart")]
        public void WhenIAddAnItemToTheCart()
        {
            throw new PendingStepException();
        }

        [Then(@"Item is in the cart")]
        public void ThenItemIsInTheCart()
        {
            throw new PendingStepException();
        }
    }
}
