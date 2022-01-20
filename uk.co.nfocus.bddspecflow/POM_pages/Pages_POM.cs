using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace uk.co.nfocus.bddspecflow.POM_pages
{
    public class Pages_POM
    {
        IWebDriver driver;
        public Pages_POM(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement dismiss => driver.FindElement(By.LinkText("Dismiss"));
        IWebElement account => driver.FindElement(By.LinkText("My account"));
        IWebElement shop => driver.FindElement(By.LinkText("Shop"));

        public void clear()
        {
            dismiss.Click();
        }
        public void gotoAccountPage()
        {
            account.Click();
        }
        public void gotoShop()
        {
            shop.Click();
        }
    }
}
