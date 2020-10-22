using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Movies
{
    public class MovieCarouselPage: BasePage
    {
        public MovieCarouselPage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement nextMovieButton => WebDriver.FindElement(By.CssSelector("body > app-root > app-home > div > div > app-moviecarousel > div > owl-carousel-o > div > div.owl-nav.ng-star-inserted > div.owl-next"));
        public IWebElement previousMovieButton => WebDriver.FindElement(By.CssSelector("body > app-root > app-home > div > div > app-moviecarousel > div > owl-carousel-o > div > div.owl-nav.ng-star-inserted > div.owl-prev"));
        //public IWebElement pageButton => WebDriver.FindElement(By.CssSelector(pageButtonNumber));
        public ReadOnlyCollection<IWebElement> lnkMovies => WebDriver.FindElements(By.ClassName("movie-list"));
        public void openMovieFromCarousel(string movieName)
        {
            MoviesDetailPage moviesDetailPage = new MoviesDetailPage(DriverContext.Driver);
            NavBarPage navBarPage = new NavBarPage(DriverContext.Driver);
            navBarPage.lnkHome.Click();
            MovieHelper.ReadMovies(lnkMovies);
            var index = MovieHelper.findMovieIndex(movieName);
            lnkMovies.ElementAt(index).Click();
            moviesDetailPage.addtoCart();
            Thread.Sleep(1000);
        }
    }
}
