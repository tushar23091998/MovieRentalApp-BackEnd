using MovieRentalApp.Automation.UI.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace MovieRentalApp.Automation.UI.Hooks
{
    [Binding]
    public class TestInitializeHook
    {
        protected readonly FeatureContext _featureContext;
        public IWebDriver webDriver;
        public Browser browser;
        public BrowserType Browser;

        public TestInitializeHook(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }
        [BeforeScenario]
        public void TestStart()
        {
            setBrowser(BrowserType.Chrome);
            InitializeSettings();
            _featureContext.Add("Driver", webDriver);
        }

        [AfterScenario]
        public void TestEnd()
        {
            webDriver.Close();
            webDriver.Quit();
        }

        public void setBrowser(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeSettings()
        {
            //ConfigReader.SetFrameworkSettings();
            Settings.AUT = "http://localhost:4200/home";
            OpenBrowser(Browser);
        }

        public IWebDriver getDriver()
        {
             return webDriver;
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    webDriver = new InternetExplorerDriver();
                    browser = new Browser(webDriver);
                    break;
                case BrowserType.FireFox:
                    webDriver = new FirefoxDriver();
                    browser = new Browser(webDriver);
                    break;
                case BrowserType.Chrome:
                    webDriver = new ChromeDriver();
                    browser = new Browser(webDriver);
                    break;
            }

        }
        //public void NavigateSite()
        //{
        //    browser.GoToUrl(Settings.AUT);
        //}
    }
}
