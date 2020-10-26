using MovieRentalApp.Automation.UI.Config;
using MovieRentalApp.Automation.UI.Hooks;
using MovieRentalApp.Automation.UI.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Xunit;

namespace MovieRentalApp.Automation.UI.Steps
{
    //[Binding]
    public class BaseSteps 
    {
        public IWebDriver webDriver;
        protected FeatureContext _featureContext { get; }
        //TestInitializeHook testInitializeHook = new TestInitializeHook();
        public BaseSteps(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }
        private NavBarPage _navBarPage;

        [Given(@"I have navigated to the web application")]
        public void GivenIHaveNavigatedToTheWebApplication()
        {
            //webDriver = getDriver();
            webDriver = _featureContext.Get<IWebDriver>("Driver");
            NavigateSite();
            _navBarPage = new NavBarPage(webDriver);
            
        }

        [Given(@"I see the application opened")]
        public void GivenISeeTheApplicationOpened()
        {
            Assert.True(_navBarPage.CheckIfLoginExist());
        }

        [Then(@"I should see the (.*) username with welcome")]
        public void ThenIShouldSeeTheUsernameWithWelcome(string name)
        {
            if(name == "login")
                Assert.Contains("John", _navBarPage.getLoggedInUser());
            else if(name == "register")
                Assert.Contains("Leonardo", _navBarPage.getLoggedInUser());
            //TestEnd();
        }
        public void NavigateSite()
        {
            //webDriver = new ChromeDriver();
            //webDriver.Navigate().GoToUrl("http://localhost:4200/home");
            Browser browser = new Browser(webDriver);
            browser.GoToUrl(Settings.AUT);
        }

    }
}
