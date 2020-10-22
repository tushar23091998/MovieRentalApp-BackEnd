using MovieRentalApp.Automation.UI.Features;
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

namespace MovieRentalApp.Automation.UI.Steps
{
    [Binding]
    [Scope(Feature = "UserEdit")]
    public class UserEditSteps : BaseSteps
    {
        private NavBarPage _navBarPage = new NavBarPage(DriverContext.Driver);
        private EditProfilePage _editProfilePage;
        private MovieCarouselPage _movieCarouselPage;
        private LoginPage _loginPage;

        [Then(@"I click Sign In link")]
        public void ThenIClickSignInLink()
        {
            _loginPage = _navBarPage.openLogin();
        }

        [When(@"I enter UserName and Password and click login button")]
        public void WhenIEnterUserNameAndPasswordAndClickLoginButton(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _movieCarouselPage = _loginPage.Login(data.UserName, data.Password);
        }

        [When(@"I open Edit Profile Page from dropdown button on Navbar")]
        public void WhenIOpenEditProfilePageFromDropdownButtonOnNavbar()
        {
            _editProfilePage = _navBarPage.openEditProfile();
        }

        [When(@"I update the user details")]
        public void WhenIUpdateTheUserDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _editProfilePage.changeDetails(data.Name.ToString(), data.Address.ToString(), data.Number.ToString());
        }

        [Then(@"the name change (.*) should be reflected on the user details page")]
        public void ThenTheChangeShouldBeReflectedOnTheUserDetailsPage(string name)
        {
            Assert.True(_editProfilePage.changeReflected(name)); ;
        }

    }
}
