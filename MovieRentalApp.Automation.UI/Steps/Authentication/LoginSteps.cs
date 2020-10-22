using MovieRentalApp.Automation.UI.PageObjectModels;
using MovieRentalApp.Automation.UI.PageObjectModels.Authentication;
using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace MovieRentalApp.Automation.UI.Steps.Authentication
{
    [Binding]
    [Scope(Feature = "Login")]
    public  class LoginSteps : BaseSteps
    {
        private NavBarPage _navBarPage = new NavBarPage(DriverContext.Driver);
        private LoginPage _loginPage;
        private MovieCarouselPage _movieCarouselPage;

        [Then(@"I click Sign In link")]
        public void ThenIClickSignInLink()
        {
            _loginPage = _navBarPage.openLogin();
        }

        [When(@"I enter UserName and Password and click login button")]
        public void WhenIEnterUserNameAndPasswordAndClickLoginButton(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _movieCarouselPage =_loginPage.Login(data.UserName, data.Password);
        }
    }
}
