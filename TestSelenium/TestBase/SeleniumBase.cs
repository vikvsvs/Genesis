using System;
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

        public IWebDriver InitializeDriver()
        {            
            var sBrowser = ConfigurationManager.AppSettings["Browser"];
            BrowserEnum eBrowser = (BrowserEnum)Enum.Parse(typeof(BrowserEnum), sBrowser.ToUpper());
            var sDevice = ConfigurationManager.AppSettings["TargetDevice"];
            ChromeOptions opt = new ChromeOptions();
            switch (sDevice)
            {
                case "PC":                    
                    break;
                case "Tablet":
                    opt.EnableMobileEmulation("Google Nexus 7");
                    break;
                case "Mobile":
                    opt.EnableMobileEmulation("Google Nexus 5");
                    break;
                default:
                    break;
            }

            switch (eBrowser)
            {
                case BrowserEnum.CHROME:                    
                    _driver = new ChromeDriver(opt);
                    break;
                case BrowserEnum.IE:
                    _driver = new InternetExplorerDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;
            }
            OpenBrowser();

            return _driver;         
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

        #region ButtonClick
        public void ButtonClick(string sControlId)
        {
            _driver.FindElement(By.Id(sControlId)).Click();
        }
        #endregion ButtonClick

        #region FindElement
        public IWebElement FindElementById(string sId)
        {
            return _driver.FindElement(By.Id(sId));
        }
        #endregion FindElement
    }
}
