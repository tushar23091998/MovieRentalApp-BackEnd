using MovieRentalApp.Automation.UI.PageObjectModels;
using MovieRentalApp.Automation.UI.PageObjectModels.Authentication;
using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using OpenQA.Selenium;
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
        public LoginSteps(FeatureContext featureContext) : base(featureContext) { }

        private NavBarPage _navBarPage;
        private LoginPage _loginPage;
        private MovieCarouselPage _movieCarouselPage;

        [Then(@"I click Sign In link")]
        public void ThenIClickSignInLink()
        {
            _navBarPage = new NavBarPage(webDriver);
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
