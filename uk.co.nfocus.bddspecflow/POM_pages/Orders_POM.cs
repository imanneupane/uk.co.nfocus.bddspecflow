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
        IWebElement OrderN => driver.FindElement(By.XPath("/html//article[@id='post-6']//ul/li[1]"));
        IWebElement orders => driver.FindElement(By.LinkText("Orders"));
        IWebElement recentOrder => driver.FindElement(By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number"));

        public String OrderPlaced()
        {
            string orderText = OrderN.Text;
            int n = 1;
            string[] lines = orderText
                .Split(Environment.NewLine.ToString())
                .Skip(n)
                .ToArray();

            string orderNumber = string.Join(Environment.NewLine, lines);
            return orderNumber;
        }
        public void GoToMyOrders()
        {
            orders.Click();
        }
        public String CheckOrderNumber()
        {
            string orderNumber = recentOrder.Text;
            return orderNumber.Remove(0,1);
        }
    }
}
