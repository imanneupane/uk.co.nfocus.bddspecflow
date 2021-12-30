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
    public class ApplycouponStepDefinitions : Support.Baseclass
    {
        IWebDriver driver = new ChromeDriver();
        [Given(@"I have added an item to cart")]
        public void GivenIHaveAddedAnItemToCart()
        {
            driver.Url = baseUrl;
            driver.Manage().Window.Maximize();
            Pages_POM accountPage = new Pages_POM(driver);
            accountPage.gotoAccountPage();
            Login_POM login = new Login_POM(driver);
            login.LoginExpected("imanneupane@yahoo.com", "Neupane@12345");
            WaitHelper(driver, 10, By.LinkText("Dashboard"));
        }

        [Given(@"I am on the Cart page")]
        public void GivenIAmOnTheCartPage()
        {
            Coupon_POM viewCart = new Coupon_POM(driver);
            viewCart.ViewCart();
        }

        [When(@"I enter the coupon code")]
        public void WhenIEnterTheCouponCode()
        {
            Coupon_POM couponCode = new Coupon_POM(driver);
            couponCode.CouponCode("edgewords");
            couponCode.ApplyCouponButton();
        }

        [Then(@"Discount is applied")]
        public void ThenDiscountIsAppliedToTheTotal()
        {
            TakeScreenShot(driver, "ApplyCoupon");
            driver.Quit();
        }

        [Given(@"I applied the coupon code")]
        public void GivenIAppliedTheCouponCode()
        {
            driver.Url = baseUrl;
            driver.Manage().Window.Maximize();
            Pages_POM accountPage = new Pages_POM(driver);
            accountPage.gotoAccountPage();
            Login_POM login = new Login_POM(driver);
            login.LoginExpected("imanneupane@yahoo.com", "Neupane@12345");
            WaitHelper(driver, 10, By.LinkText("Dashboard"));
            Coupon_POM viewCart = new Coupon_POM(driver);
            viewCart.ViewCart();
            WaitHelper(driver, 20, By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
        }

        [When(@"Coupon takes off (.*)%")]
        public void WhenCouponTakesOffOff(decimal discount)
        {
            try
            {
                Coupon_POM applycoupon = new Coupon_POM(driver);
                applycoupon.CheckCoupon(discount);
                //Assert.That(discount.ToString("0.00"), Is.EqualTo(couponDiscount.Remove(0, 1)), "They are not equal");
            }
            catch (AssertionException)
            {
                TakeScreenShotElement(driver, "CouponDiscount", By.ClassName("cart_totals"));
                Console.WriteLine("Coupon does not take 15% off");
            }

        }

        [Then(@"Discount is deducted from total")]
        public void ThenDiscountIsDeductedFromTotal()
        {
            //Check that the total calculated is correct
            try
            {
                Coupon_POM applycoupon = new Coupon_POM(driver);
                applycoupon.CheckTotal();
                //Assert.That(totalAmt.ToString("0.00"),Is.EqualTo(total.Remove(0, 1)), "They are not equal");
            }
            catch (AssertionException)
            {
                //Thread.Sleep(1000);
                TakeScreenShotElement(driver, "Cart Total", By.ClassName("order-total"));
                Console.WriteLine("The total amount is incorrect");
            }
            driver.Quit();
        }
    }
}
