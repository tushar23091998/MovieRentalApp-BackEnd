using MovieRentalApp.Automation.UI.PageObjectModels;
using MovieRentalApp.Automation.UI.PageObjectModels.Authentication;
using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading;
using Xunit;

namespace MovieRentalApp.Automation.UI
{   
    public class TestFile
    {

        //[Fact (Skip ="Testing other tests")]
        [Fact]
        public void LoginAndLogoutTest()
        {
            DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl("http://localhost:4200/home");
            LoginPage loginPage = new LoginPage(DriverContext.Driver);
            MoviesListPage moviesListPage = new MoviesListPage(DriverContext.Driver);
            NavBarPage navBarPage = new NavBarPage(DriverContext.Driver);
            loginPage.Login();
            moviesListPage.openMovie();
            navBarPage.Logout();
            DriverContext.Driver.Quit();
        }

        [Fact(Skip = "Testing other tests")]
        //[Fact]
        public void RegisterTest()
        {
            DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl("http://localhost:4200/home");
            RegisterPage registerPage = new RegisterPage(DriverContext.Driver);
            registerPage.Register();
            DriverContext.Driver.Quit();
        }

    }
    
}
