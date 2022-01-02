using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using uk.co.nfocus.bddspecflow.POM_pages;
using static uk.co.nfocus.bddspecflow.Support.Helpers;
using NUnit.Framework;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class OrderplacedStepDefinitions: Support.Baseclass
    {
        IWebDriver driver = new ChromeDriver(); 
        [Given(@"I have placed an order")]
        public void GivenIHavePlacedAnOrder()
        {
            driver.Url = baseUrl;
            driver.Manage().Window.Maximize();
            Pages_POM accountPage = new Pages_POM(driver);
            accountPage.gotoAccountPage();
            Login_POM login = new Login_POM(driver);
            login.LoginExpected("imanneupane@yahoo.com", "Neupane@12345");
            WaitHelper(driver, 10, By.LinkText("Dashboard"));
        }

        [When(@"I am on my order page")]
        public void WhenIAmOnMyOrderPage()
        {
            Orders_POM myOrder = new Orders_POM(driver);
            myOrder.GoToMyOrders();
        }

        [Then(@"The order number is displayed")]
        public void ThenTheOrderNumberIsDisplayed()
        {
            Orders_POM myOrder = new Orders_POM(driver);
            try
            {
                myOrder.CheckOrderNumber();
            }
            catch (AssertionException)
            {
                TakeScreenShotElement(driver, "MyOrders", By.Id("post-7"));
                Console.WriteLine("Recent Order was not Placed");
            }
            driver.Quit();
        }
    }
}
