using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace uk.co.nfocus.bddspecflow.POM_pages
{
    public class Login_POM
    {
        IWebDriver driver;
        public Login_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement UsernameField => driver.FindElement(By.Id("username"));
        IWebElement PasswordField => driver.FindElement(By.Id("password"));
        IWebElement LoginButton => driver.FindElement(By.Name("login"));
        IWebElement Logout => driver.FindElement(By.LinkText(""));

        //Service methods
        public void Username(string username)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
        }
        public void Password(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }
        public void LoginSubmit()
        {
            LoginButton.Click();
        }
    }
}
