using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using uk.co.nfocus.bddspecflow.POM_pages;
using static uk.co.nfocus.bddspecflow.Support.Helpers;
using static uk.co.nfocus.bddspecflow.Support.Baseclass;


namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class CheckoutdetailStepDefinitions
    {
        readonly string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/";
        [Given(@"I have proceeded to checkout")]
        public void GivenIHaveProceededToCheckout()
        {
            driver.Url = baseUrl; 
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
            
        }

        [Then(@"I can place my order")]
        public void ThenICanPlaceMyOrder()
        {
            Thread.Sleep(1000);
            CheckoutDetails_POM placeOrder = new CheckoutDetails_POM(driver);
            placeOrder.PlaceOrder();
            driver.Quit();
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
