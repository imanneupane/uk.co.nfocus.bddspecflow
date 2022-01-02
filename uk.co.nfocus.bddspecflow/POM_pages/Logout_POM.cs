using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.bddspecflow.POM_pages
{
    public class Logout_POM
    {
        IWebDriver driver;
        public Logout_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement account => driver.FindElement(By.LinkText("Dashboard"));
        IWebElement logout => driver.FindElement(By.LinkText("Log out"));
        public void MyAccount()
        {
            account.Click();
        }
        public void Logout()
        {
            logout.Click();
        }
    }
}
