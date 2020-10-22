//using MovieRentalApp.Automation.UI.PageObjectModels;
//using MovieRentalApp.Automation.UI.PageObjectModels.Authentication;
//using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.IE;
//using System.Threading;
//using Xunit;

//namespace MovieRentalApp.Automation.UI
//{   
//    public class TestFile
//    {

//        //[Fact (Skip ="Testing other tests")]
//        [Fact]
//        public void LoginAndLogoutTest()
//        {
//            DriverContext.Driver = new ChromeDriver();
//            DriverContext.Driver.Navigate().GoToUrl("http://localhost:4200/home");
//            LoginPage loginPage = new LoginPage(DriverContext.Driver);
//            MoviesListPage moviesListPage = new MoviesListPage(DriverContext.Driver);
//            MovieCarouselPage movieCarouselPage = new MovieCarouselPage(DriverContext.Driver);
//            CartPage cartPage = new CartPage(DriverContext.Driver);
//            NavBarPage navBarPage = new NavBarPage(DriverContext.Driver);
//            EditProfilePage editProfilePage = new EditProfilePage(DriverContext.Driver);
//            MovieAddPage movieAddPage = new MovieAddPage(DriverContext.Driver);

//            loginPage.Login();
//            //movieCarouselPage.openMovieFromCarousel();
//            //moviesDetailPage.addtoCart();
//            //navBarPage.lnkDropdown.Click();
//            //navBarPage.lnkEditProfile.Click();
//            //editProfilePage.btnAdmin.Click();
//            //movieAddPage.AddMovie();
//            moviesListPage.openMovieFromList("Big Hero 6");
//            moviesListPage.openMovieFromList("Gandhi");
//            movieCarouselPage.openMovieFromCarousel("Goodfellas");
//            cartPage.chooseTypeAndCheckout();
//            navBarPage.Logout();
//            DriverContext.Driver.Quit();
//        }

//        //[Fact]
//        public void RegisterTest()
//        {
//            DriverContext.Driver = new ChromeDriver();
//            DriverContext.Driver.Navigate().GoToUrl("http://localhost:4200/home");
//            RegisterPage registerPage = new RegisterPage(DriverContext.Driver);
//            registerPage.Register();
//            DriverContext.Driver.Quit();
//        }

//        //[Fact]
//        public void testmethod()
//        {
//            DriverContext.Driver = new ChromeDriver();
//            DriverContext.Driver.Navigate().GoToUrl("http://localhost:4200/home");
//            LoginPage loginPage = new LoginPage(DriverContext.Driver);
//            MoviesListPage moviesListPage = new MoviesListPage(DriverContext.Driver);
//            MovieCarouselPage movieCarouselPage = new MovieCarouselPage(DriverContext.Driver);
//            loginPage.Login();
//            //moviesListPage.openMovieFromList(18);
//            //moviesListPage.openMovieFromList(19);
//            Thread.Sleep(2000);
//        }

//    }
    
//}
