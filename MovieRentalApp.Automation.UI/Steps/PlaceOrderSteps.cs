using MovieRentalApp.Automation.UI.PageObjectModels;
using MovieRentalApp.Automation.UI.PageObjectModels.Authentication;
using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using MovieRentalApp.Automation.UI.PageObjectModels.User;
using OpenQA.Selenium;
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
    [Scope(Feature = "PlaceOrder")]
    public class PlaceOrderSteps : BaseSteps
    {
        public PlaceOrderSteps(FeatureContext featureContext) : base(featureContext) { }

        private NavBarPage _navBarPage;
        private MovieCarouselPage _movieCarouselPage;
        private LoginPage _loginPage;
        private MoviesListPage _moviesListPage;
        private CartPage _cartPage;
        private UserOrdersPage _userOrdersPage;

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
            _movieCarouselPage = _loginPage.Login(data.UserName, data.Password);
        }

        [When(@"I open Movie List page and add movies")]
        public void WhenIOpenMovieListPageAndAddMovies()
        {
            _moviesListPage = _navBarPage.goToMovies();
            _moviesListPage.openMovieFromList("Big Hero 6");
            _moviesListPage = _navBarPage.goToMovies();
            _moviesListPage.openMovieFromList("Gandhi");     
        }

        [When(@"I open Movie Carousel page and add movies")]
        public void WhenIOpenMovieCarouselPageAndAddMovies()
        {
            _movieCarouselPage = _navBarPage.goToHome();
            _movieCarouselPage.openMovieFromCarousel("Goodfellas");
        }

        [Then(@"I open the cart")]
        public void ThenIOpenTheCart()
        {
            _cartPage = _navBarPage.openCart();
        }

        [When(@"I select the purchase type and I pay and checkout")]
        public void WhenISelectThePurchaseTypeAndIPayAndCheckout()
        {
            _cartPage.chooseTypeAndCheckout();
        }

        [Then(@"I should see the movies in user orders")]
        public void ThenIShouldSeeTheMoviesInUserOrders()
        {
            _userOrdersPage = _navBarPage.openUserOrder();
            Assert.True(_userOrdersPage.rentalMovieExists("Big Hero 6"));
            Assert.True(_userOrdersPage.rentalMovieExists("Gandhi"));
            Assert.True(_userOrdersPage.purchasedMovieExists("Goodfellas"));
            //TestEnd();
        }


    }
}
