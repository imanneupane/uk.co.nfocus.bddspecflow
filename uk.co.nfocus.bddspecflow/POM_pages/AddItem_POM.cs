using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace uk.co.nfocus.bddspecflow.POM_pages
{
    public class AddItem_POM
    {
        IWebDriver driver;
        public AddItem_POM(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement Product => driver.FindElement(By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/polo/']/img"));
        IWebElement AddToCart => driver.FindElement(By.Name("add-to-cart"));
        IWebElement viewCart => driver.FindElement(By.LinkText("View cart"));

        public AddItem_POM SelectProduct()
        {
            Product.Click();
            return this;
        }
        public AddItem_POM AddItem()
        {
            AddToCart.Click();
            return this;
        }
        public void ViewCart()
        {
            viewCart.Click();
        }
    }
}
