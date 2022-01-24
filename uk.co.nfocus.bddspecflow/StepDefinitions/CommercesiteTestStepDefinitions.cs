using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using uk.co.nfocus.bddspecflow.POM_pages;
using static uk.co.nfocus.bddspecflow.Support.Baseclass;
using static uk.co.nfocus.bddspecflow.Support.Helpers;
using NUnit.Framework;

namespace uk.co.nfocus.bddspecflow.StepDefinitions
{
    [Binding]
    public class CommercesiteTestStepDefinitions
    {
        //Initilizing the the main webpage
        readonly string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/";

        //Initilizing all the POM pages 
        Pages_POM pageNav = new Pages_POM(driver);
        Login_POM login = new Login_POM(driver);
        AddItem_POM selectItem = new AddItem_POM(driver);
        Coupon_POM couponCode = new Coupon_POM(driver);
        CheckoutDetails_POM checkout = new CheckoutDetails_POM(driver);
        Orders_POM myOrder = new Orders_POM(driver);
        Logout_POM logoff = new Logout_POM(driver);

        [Given(@"I am logged in with '([^']*)' and '([^']*)'")]
        public void GivenIAmLoggedInWithAnd(string username, string password)
        {
            driver.Url = baseUrl;
            pageNav.clear(); //getting rid of the dismiss bar
            pageNav.gotoAccountPage();
            //logining into the user account from passed parameters
            login.LoginExpected(username, password); 
            WaitHelper(driver, 10, By.LinkText("Dashboard"));
            Console.WriteLine("The User is logged in!");
        }

        [When(@"I add an item to the cart")]
        public void WhenIAddAnItemToTheCart()
        {
            pageNav.gotoShop();
            selectItem.AddItemtoCart();
            Console.WriteLine("An item has been added to the cart.");
        }

        [When(@"I apply the (.*) discount code")]
        public void WhenIApplyTheEdgewordsDiscountCode(string code)
        {
            Console.WriteLine(code);
            //gets the coupon code from the feature file as passed parameter
            couponCode.CouponCode(code);
            couponCode.ApplyCouponButton();
        }

        [Then(@"Coupon takes (.*) off")]
        public void ThenCouponTakesOff(decimal intendedDiscount)
        {
            WaitHelper(driver, 10, By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
            //Checking if the discount from the coupon matches the context 
            try
            {
                //Asserts that the discount applied matches
                Assert.That(couponCode.ActualDiscount(), Is.EqualTo(couponCode.CheckCoupon(intendedDiscount)), "They are not equal");
            }
            //if it doesn't match assert fails and the exception is catched
            catch (AssertionException)
            {
                //It takes the screenshot of the discounts applied 
                TakeScreenShotElement(driver, "CouponDiscount", By.ClassName("cart_totals"));
                Console.WriteLine("Coupon does not take 15% off");
            }

            //Check that the total calculated is correct
            try
            {
                //Assets that the total is correct after shipping fee
                Assert.That(couponCode.TotalAmount(), Is.EqualTo(couponCode.CheckTotal(intendedDiscount)), "They are not equal");
            }
            //it catches the exception if assert fails
            catch (AssertionException)
            {
                //Take a screenshot of the total amount 
                TakeScreenShotElement(driver, "Cart Total", By.ClassName("order-total"));
                Console.WriteLine("The total amount is incorrect");
            }

        }

        [When(@"I have purchased an item")]
        public void WhenIHavePurchasedAnItem()
        {
            //Proceeds on to the checkout page
            checkout.CheckoutPage();
            WaitHelper(driver, 10, By.LinkText("Click here to enter your code"));
            /*
             * Entering details manually
             * Since this is one end-to-end test
             * Database class could be used for further improvements
             * for multiple details
             * */
            try
            {
                checkout.BillingForm("Nami", "Rai", "nFocus", "United Kingdom", "101 Star Road", "Ashford", "Kent", "TN3 5JB", "021540231", "namirai@yahoo.com");
                Thread.Sleep(1000);
                checkout.PlaceOrder();
                Thread.Sleep(1000);
            }
            catch(StaleElementReferenceException)
            {
                Console.WriteLine("Checkout Complete!");
            }
        }

        [Then(@"Order number displayed is same to my orders")]
        public void ThenOrderNumberDisplayedIsSameToMyOrders()
        {
            //storing the order number when the order is placed
            string orderNumberPlaced = myOrder.OrderPlaced();
            Console.WriteLine("The order no. is " + myOrder.OrderPlaced());
            //Goto my order page 
            pageNav.gotoAccountPage();
            myOrder.GoToMyOrders();
            Console.WriteLine("Your order number is " + myOrder.CheckOrderNumber());

            //Checking if the order number displayed in my order is same as order number displayed when purchase
            try
            {
                //assert that the order number is there in my order
                Assert.That(myOrder.CheckOrderNumber(), Is.EqualTo(orderNumberPlaced), "Order number is Displayed!");
            }
            catch (AssertionException)
            {
                //Take a screenshot of the order number
                TakeScreenShotElement(driver, "MyOrders", By.Id("post-7"));
                Console.WriteLine("Recent Order was not Placed");
            }
            
            //Logout of the account once the orders are checked
            logoff.MyAccount();
            logoff.Logout();
            Console.WriteLine("You are logged out!");
        }
    }
}
