using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.bddspecflow.Support
{
    [Binding]
    public class Baseclass
    {
        public static IWebDriver driver;
        //public string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/";

        [BeforeScenario]
        public void SetUp()
        {
            driver = new ChromeDriver();
            //driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
