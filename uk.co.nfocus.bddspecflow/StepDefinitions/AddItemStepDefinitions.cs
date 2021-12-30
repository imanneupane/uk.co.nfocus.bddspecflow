using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using uk.co.nfocus.bddspecflow.POM_pages;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class AddItemStepDefinitions: Support.Baseclass
    {
        IWebDriver driver = new ChromeDriver();

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            driver.Url = baseUrl;
            driver.Manage().Window.Maximize();
            Pages_POM accountPage = new Pages_POM(driver);
            accountPage.gotoAccountPage();
            Login_POM login = new Login_POM(driver);
            login.LoginExpected("imanneupane@yahoo.com", "Neupane@12345");
        }

        [Given(@"I am on the shop page")]
        public void GivenIAmOnTheShopPage()
        {
            Pages_POM shopPage = new Pages_POM(driver);
            shopPage.gotoShop();
        }

        [When(@"I select an item")]
        public void WhenISelectAnItem()
        {
            AddItem_POM selectItem = new AddItem_POM(driver);
            selectItem.SelectProduct();
        }

        [When(@"I add item to the cart")]
        public void WhenIAddItemToTheCart()
        {
            AddItem_POM addItem = new AddItem_POM(driver);
            addItem.AddItem();
        }

        [Then(@"Item is added to the cart")]
        public void ThenItemIsAddedToTheCart()
        {
            AddItem_POM viewCart = new AddItem_POM(driver);
            viewCart.ViewCart();
            driver.Quit();
        }
    }
}
