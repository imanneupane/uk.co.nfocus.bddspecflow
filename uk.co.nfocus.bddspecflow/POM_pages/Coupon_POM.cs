using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.bddspecflow.POM_pages
{
    public class Coupon_POM
    {
        IWebDriver driver;
        decimal priceBeforeDiscount;
        decimal discount;
        decimal priceAfterDiscount;
        decimal shipCost;
        decimal totalAmt;

        public Coupon_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement Cart => driver.FindElement(By.LinkText("Cart"));
        IWebElement Coupon => driver.FindElement(By.Id("coupon_code"));
        IWebElement ApplyButton => driver.FindElement(By.Name("apply_coupon"));
        IWebElement SubtotalAmt => driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span"));
        IWebElement CartDiscount => driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
        IWebElement ShippingFee => driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//tr[@class='shipping']/td/span"));
        IWebElement Total => driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//strong/span"));

        public void ViewCart()
        {
            Cart.Click();
        }
        public void CouponCode(String couponC)
        {
            Coupon.SendKeys(couponC);
        }
        public void ApplyCouponButton()
        {
            ApplyButton.Click();
        }
        public String ActualDiscount()
        {
            string couponDiscount = CartDiscount.Text;
            return couponDiscount.Remove(0, 1);
            
        }
        public String TotalAmount()
        {
            string totalAmount = Total.Text;
            return totalAmount.Remove(0, 1);
        }
        public String CheckCoupon(decimal off)
        {
            string subtotal = SubtotalAmt.Text;
            priceBeforeDiscount = Convert.ToDecimal(subtotal.Remove(0, 1));
            discount = (off / 100m) * priceBeforeDiscount;
            return discount.ToString("0.00");
        }

        public String CheckTotal(decimal off)
        {
            string shipping = ShippingFee.Text;
            string subtotal = SubtotalAmt.Text;
            priceBeforeDiscount = Convert.ToDecimal(subtotal.Remove(0, 1));
            discount = (off / 100m) * priceBeforeDiscount;
            priceAfterDiscount = priceBeforeDiscount - discount;
            shipCost = Convert.ToDecimal(shipping.Remove(0, 1));
            totalAmt = priceAfterDiscount + shipCost;
            return totalAmt.ToString("0.00");
        }
    }
}
