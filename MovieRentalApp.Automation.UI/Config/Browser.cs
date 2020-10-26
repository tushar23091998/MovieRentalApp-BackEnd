using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRentalApp.Automation.UI.Config
{
    public class Browser
    {
        private IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

        public void GoToUrl(string url)
        {
            _driver.Url = url;
            //this.Type = BrowserType.Chrome;
        }

    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
