using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using uk.co.nfocus.bddspecflow.POM_pages;
using static uk.co.nfocus.bddspecflow.Support.Helpers;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class CheckoutdetailStepDefinitions: Support.Baseclass
    {
        IWebDriver driver = new ChromeDriver();
        [Given(@"I have proceeded to checkout")]
        public void GivenIHaveProceededToCheckout()
        {
            driver.Url = baseUrl; 
            driver.Manage().Window.Maximize();
            Pages_POM accountPage = new Pages_POM(driver);
            accountPage.gotoAccountPage();
            Login_POM login = new Login_POM(driver);
            login.LoginExpected("imanneupane@yahoo.com", "Neupane@12345");
            WaitHelper(driver, 10, By.LinkText("Dashboard")); 
        }

        [Given(@"I am on the billing information page")]
        public void GivenIAmOnTheBillingInformationPage()
        {
            CheckoutDetails_POM checkout = new CheckoutDetails_POM(driver);
            checkout.CheckoutPage();
        }

        [When(@"I enter my shipping details")]
        public void WhenIEnterMyShippingDetails()
        {
            CheckoutDetails_POM billingDetail = new CheckoutDetails_POM(driver);
            billingDetail.BillingForm("Nami", "Rai", "nFocus", "United Kingdom", "101 Star Road", "Ashford", "Kent", "TN3 5JB", "021540231", "namirai@yahoo.com");
            Thread.Sleep(1000);
        }

        [Then(@"I can place my order")]
        public void ThenICanPlaceMyOrder()
        {
            CheckoutDetails_POM placeOrder = new CheckoutDetails_POM(driver);
            placeOrder.PlaceOrder();
            /*
            try
            {
                WaitHelper(driver, 20, By.XPath("//*[text()='Order received']"));
            }
            catch (StaleElementReferenceException)
            {
                Console.WriteLine("Not in the right page");
            }
            */
        }
    }
}
