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
    public class Baseclass
    {
        //public IWebDriver driver;
        public string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/";

        [SetUp]
        public void Setup()
        {
            //driver = new ChromeDriver();
            //driver = new EdgeDriver();
            //driver.Manage().Window.Maximize();
        }
    }
}
