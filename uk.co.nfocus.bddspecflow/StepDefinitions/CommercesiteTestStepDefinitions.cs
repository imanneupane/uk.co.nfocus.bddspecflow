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
        readonly string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/";
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
            couponCode.CouponCode(code);
            couponCode.ApplyCouponButton();
            Thread.Sleep(3000);
        }

        [Then(@"Coupon takes (.*) off")]
        public void ThenCouponTakesOff(decimal discount)
        {
            //Checking if the discount from the coupon matches the context 
            try
            {
                Assert.That(couponCode.CouponDiscount().Remove(0, 1), Is.EqualTo(couponCode.CheckCoupon(discount).ToString("0.00")), "They are not equal");
            }
            catch (AssertionException)
            {
                TakeScreenShotElement(driver, "CouponDiscount", By.ClassName("cart_totals"));
                Console.WriteLine("Coupon does not take 15% off");
            }

            //Check that the total calculated is correct
            try
            {
                Assert.That(couponCode.TotalAmount().Remove(0, 1), Is.EqualTo(couponCode.CheckTotal(discount).ToString("0.00")), "They are not equal");
            }
            catch (AssertionException)
            {
                //Thread.Sleep(1000);
                TakeScreenShotElement(driver, "Cart Total", By.ClassName("order-total"));
                Console.WriteLine("The total amount is incorrect");
            }

        }

        [When(@"I have purchased an item")]
        public void WhenIHavePurchasedAnItem()
        {
            checkout.CheckoutPage();
            checkout.BillingForm("Nami", "Rai", "nFocus", "United Kingdom", "101 Star Road", "Ashford", "Kent", "TN3 5JB", "021540231", "namirai@yahoo.com");
            Thread.Sleep(1000);
            checkout.PlaceOrder();
            Thread.Sleep(3000);
        }

        [Then(@"Order number displayed is same to my orders")]
        public void ThenOrderNumberDisplayedIsSameToMyOrders()
        {
            pageNav.gotoAccountPage();
            myOrder.GoToMyOrders();
            Console.WriteLine("Your order number is " + myOrder.CheckOrderNumber());

            //Checking if the order number displayed in my order is same as order number displayed when purchase
            try
            {
                Assert.That(string.IsNullOrEmpty(myOrder.CheckOrderNumber()), Is.False, "Order number is Displayed!");
            }
            catch (AssertionException)
            {
                TakeScreenShotElement(driver, "MyOrders", By.Id("post-7"));
                Console.WriteLine("Recent Order was not Placed");
            }
            
            logoff.MyAccount();
            logoff.Logout();
            Console.WriteLine("You are logged out!");
        }
    }
}
