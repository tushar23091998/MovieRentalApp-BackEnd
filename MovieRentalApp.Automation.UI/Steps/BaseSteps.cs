using MovieRentalApp.Automation.UI.Config;
using MovieRentalApp.Automation.UI.PageObjectModels;
using MovieRentalApp.Automation.UI.PageObjectModels.Authentication;
using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace MovieRentalApp.Automation.UI.Steps
{
    
    public class BaseSteps
    {
        private NavBarPage _navBarPage = new NavBarPage(DriverContext.Driver);

        [Given(@"I have navigated to the web application")]
        public void GivenIHaveNavigatedToTheWebApplication()
        {
            NavigateSite();
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
        }
        public void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
        }

    }
}
