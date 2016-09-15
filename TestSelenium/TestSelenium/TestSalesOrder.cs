using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;

using System.Configuration;

namespace TestSelenium
{
    [TestClass]
    public class TestSalesOrder : SeleniumBase
    {
        public IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            driver = InitializeDriver();
            
        }

        [TestMethod]
        public void TestMethod1()
        {
            var eUserID = FindElementById("textLogin");
            var ePassword = FindElementById("Password");
            
            eUserID.SendKeys("admin");
            ePassword.SendKeys("varsun");

            ButtonClick("btnLogin");
        }

        [TestCleanup]
        public void EndTest()
        {
            //CloseBrowser();            
        }
    }
}
