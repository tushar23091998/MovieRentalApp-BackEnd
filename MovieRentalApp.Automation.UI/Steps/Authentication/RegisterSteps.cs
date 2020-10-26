using MovieRentalApp.Automation.UI.PageObjectModels;
using MovieRentalApp.Automation.UI.PageObjectModels.Authentication;
using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MovieRentalApp.Automation.UI.Steps.Authentication
{
    [Binding]
    [Scope(Feature = "Register")]
    public class RegisterSteps : BaseSteps
    {
        public RegisterSteps(FeatureContext featureContext) : base(featureContext) { }

        private NavBarPage _navBarPage;
        private RegisterPage _registerPage;
        private MovieCarouselPage _movieCarouselPage;

        [Then(@"I click Register link")]
        public void ThenIClickRegisterLink()
        {
            _navBarPage = new NavBarPage(webDriver);
            _registerPage = _navBarPage.openRegister();
        }

        [When(@"I enter the valid details and click Register button")]
        public void WhenIEnterTheValidDetailsAndClickRegisterButton(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _movieCarouselPage = _registerPage.Register(data.UserName, data.Password, data.ConfirmPassword, data.Email, data.Name, data.DOB);
        }

    }
}
