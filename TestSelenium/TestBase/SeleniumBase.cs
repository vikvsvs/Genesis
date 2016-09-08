﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

using System.Configuration;

namespace TestSelenium
{
    public class SeleniumBase
    {
        private IWebDriver _driver { get; set; }
        public BrowserEnum Browser { get; set; }

        public void InitializeDriver()
        {            
            var sBrowser = ConfigurationManager.AppSettings["Browser"];
            BrowserEnum eBrowser = (BrowserEnum)Enum.Parse(typeof(BrowserEnum), sBrowser.ToUpper());

            switch(eBrowser)
            {
                case(BrowserEnum.CHROME):
                    _driver = new ChromeDriver();
                    break;
                case (BrowserEnum.IE):
                    _driver = new InternetExplorerDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;
            }
            OpenBrowser();            
        }

        #region Open Browser
        private void OpenBrowser()
        {
            var sBaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            _driver.Navigate().GoToUrl(sBaseUrl);
        }
        #endregion Open Browser

        #region Close Browser
        public void CloseBrowser()
        {
            _driver.Quit();
        }
        #endregion Close Browser
    }
}
