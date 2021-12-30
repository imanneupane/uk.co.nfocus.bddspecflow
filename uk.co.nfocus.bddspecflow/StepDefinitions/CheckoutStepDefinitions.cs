using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using uk.co.nfocus.bddspecflow.POM_pages;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinitions: Support.Baseclass
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
        }

        [Given(@"I am on the checkout page")]
        public void GivenIAmOnTheCheckoutPage()
        {
            throw new PendingStepException();
        }

        [When(@"I enter the coupon code")]
        public void WhenIEnterTheCouponCode()
        {
            throw new PendingStepException();
        }

        [Then(@"Discount is applied to the total")]
        public void ThenDiscountIsAppliedToTheTotal()
        {
            throw new PendingStepException();
        }

        [Given(@"I applied the coupon code")]
        public void GivenIAppliedTheCouponCode()
        {
            throw new PendingStepException();
        }

        [When(@"discount is applied")]
        public void WhenDiscountIsApplied()
        {
            throw new PendingStepException();
        }

        [Then(@"coupon takes off (.*)% off")]
        public void ThenCouponTakesOffOff(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I am on the billing information page")]
        public void GivenIAmOnTheBillingInformationPage()
        {
            throw new PendingStepException();
        }

        [Given(@"I have placed an order")]
        public void GivenIHavePlacedAnOrder()
        {
            throw new PendingStepException();
        }

        [When(@"I am on my order page")]
        public void WhenIAmOnMyOrderPage()
        {
            throw new PendingStepException();
        }

        [Then(@"The order number is displayed")]
        public void ThenTheOrderNumberIsDisplayed()
        {
            throw new PendingStepException();
        }
    }
}
