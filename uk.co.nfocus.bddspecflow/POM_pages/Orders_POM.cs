using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium; 

namespace uk.co.nfocus.bddspecflow.POM_pages
{
    public class Orders_POM
    {
        IWebDriver driver;
        public Orders_POM(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement orders => driver.FindElement(By.LinkText("Orders"));
        IWebElement recentOrder => driver.FindElement(By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number"));

        public void GoToMyOrders()
        {
            orders.Click();
        }
        public void CheckOrderNumber()
        {
            string orderNumber = recentOrder.Text;
            Assert.That(string.IsNullOrEmpty(orderNumber), Is.False, "Order number is Displayed!");
        }
    }
}
