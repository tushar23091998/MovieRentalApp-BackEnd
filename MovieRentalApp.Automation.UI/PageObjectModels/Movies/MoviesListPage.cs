using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Movies
{
    public class MoviesListPage : BasePage
    {

        public MoviesListPage(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement txtSearchBar => WebDriver.FindElement(By.Name("search"));
        public IWebElement priceToggle => WebDriver.FindElement(By.Id("rentalprice"));
        public IWebElement ratingsToggle => WebDriver.FindElement(By.Id("ratings"));
        public ReadOnlyCollection<IWebElement> lnkMovies => WebDriver.FindElements(By.ClassName("movie-list"));
        public IWebElement movieLink => WebDriver.FindElement(By.Id("movieImg"));

        public void openMovieFromList(string movieName)
        {
            MoviesDetailPage moviesDetailPage = new MoviesDetailPage(WebDriver);
            MovieHelper.ReadMovies(lnkMovies, WebDriver);
            var index = MovieHelper.findMovieIndex(movieName);
            lnkMovies.ElementAt(index).Click();
            //txtSearchBar.SendKeys(movieName);
            //movieLink.Click();
            moviesDetailPage.addtoCart();
            //txtSearchBar.Clear();
            Thread.Sleep(1000);
        }
        public bool movieExists(string movieName)
        {
            MovieHelper.ReadMovies(lnkMovies, WebDriver);
            return MovieHelper.ifMovieExists(movieName);
        }
    }
}
