using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Movies
{
    public class MoviesDeletePage : BasePage
    {
        public MoviesDeletePage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement btnUserDetails => WebDriver.FindElement(By.Id("userdetail"));
        public IWebElement btnAddmovie => WebDriver.FindElement(By.Id("addmoviebtn"));
        public IWebElement btnDeleteMovie => WebDriver.FindElement(By.Id("deletemoviebtn"));
        public IWebElement searchMovie => WebDriver.FindElement(By.Name("search"));
        public IWebElement linkDelete => WebDriver.FindElement(By.Id("delete-link"));
        public MovieAddPage openAddMovie()
        {
            btnAddmovie.Click();
            return new MovieAddPage(DriverContext.Driver);
        }
        public MovieCarouselPage deleteMovie(string movieName)
        {
            searchMovie.SendKeys(movieName);
            linkDelete.Click();
            return new MovieCarouselPage(DriverContext.Driver);
        }


    }
}
