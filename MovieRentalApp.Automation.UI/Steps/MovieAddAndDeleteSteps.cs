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
    [Scope(Feature = "MovieAddAndDelete")]
    public  class MovieAddAndDeleteSteps : BaseSteps
    {
        private NavBarPage _navBarPage = new NavBarPage(DriverContext.Driver);
        private EditProfilePage _editProfilePage;
        private MovieCarouselPage _movieCarouselPage;
        private LoginPage _loginPage;
        private MoviesListPage _moviesListPage;
        private MovieAddPage _movieAddPage;
        private MoviesDeletePage _movieDeletePage;

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
        [Then(@"I open Edit Profile Page from dropdown button on Navbar")]
        public void ThenIOpenEditProfilePageFromDropdownButtonOnNavbar()
        {
            _editProfilePage = _navBarPage.openEditProfile();
        }

        [When(@"I click admin button")]
        public void WhenIClickAdminButton()
        {
            _movieAddPage = _editProfilePage.goToAdmin();
        }

        [When(@"I add a movie")]
        public void WhenIAddAMovie(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _movieCarouselPage = _movieAddPage.AddMovie(data.MovieTitle.ToString(), data.MovieDescription.ToString(), data.MovieDuration.ToString(), data.MovieRentalRate.ToString(), data.MoviePurchaseRate.ToString(), data.MovieRating.ToString(), data.MovieImageLink.ToString(), data.MovieTrailerLink.ToString(), data.MovieGenre.ToString(), data.MovieWideImageLink.ToString());
        }

        [Then(@"I check the newly added movie on Movie List Page")]
        public void ThenICheckTheNewlyAddedMovieOnMovieListPage()
        {
            _moviesListPage = _navBarPage.goToMovies();
            Assert.True(_moviesListPage.movieExists("The Shawshank Redemption"));
        }

        [When(@"I delete the movie")]
        public void WhenIDeleteTheMovie()
        {
            _movieDeletePage = _movieAddPage.openDeleteMovie();
            _movieCarouselPage = _movieDeletePage.deleteMovie("The Shawshank Redemption");
        }

        [Then(@"I should not see the deleted movie in Movie List Page")]
        public void ThenIShouldNotSeeTheDeletedMovieInMovieListPage()
        {
            _moviesListPage = _navBarPage.goToMovies();
            Assert.False(_moviesListPage.movieExists("The Shawshank Redemption"));
        }

    }
}
