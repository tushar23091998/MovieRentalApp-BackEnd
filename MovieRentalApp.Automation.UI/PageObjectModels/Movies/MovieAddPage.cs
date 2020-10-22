using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Movies
{
    public class MovieAddPage : BasePage
    {
        public MovieAddPage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement btnUserDetails => WebDriver.FindElement(By.Id("userdetail"));
        public IWebElement btnAddmovie => WebDriver.FindElement(By.Id("addmoviebtn"));
        public IWebElement btnDeleteMovie => WebDriver.FindElement(By.Id("deletemoviebtn"));
        public IWebElement txtTitle => WebDriver.FindElement(By.Id("title"));
        public IWebElement txtDescription => WebDriver.FindElement(By.Id("description"));
        public IWebElement txtGenre => WebDriver.FindElement(By.Id("genre"));
        public IWebElement txtRentalPrice => WebDriver.FindElement(By.Id("price"));
        public IWebElement txtPurchasePrice => WebDriver.FindElement(By.Id("purchase"));
        public IWebElement txtDuration => WebDriver.FindElement(By.Id("duration"));
        public IWebElement txtRating => WebDriver.FindElement(By.Id("rating"));
        public IWebElement txtImageLink => WebDriver.FindElement(By.Id("image"));
        public IWebElement txtTrailer => WebDriver.FindElement(By.Id("trailer"));
        public IWebElement txtWideImage => WebDriver.FindElement(By.Id("wide"));
        public IWebElement btnAddMovie => WebDriver.FindElement(By.Id("addButton"));

        public MovieCarouselPage AddMovie(string MovieTitle, string MovieDescription, string MovieDuration, string MovieRentalRate, string MoviePurchaseRate, string MovieRating, string MovieImageLink, string MovieTrailerLink, string MovieGenre, string MovieWideImagelink)
        {
            txtTitle.SendKeys(MovieTitle);
            txtDescription.SendKeys(MovieDescription);
            txtDuration.SendKeys(MovieDuration);
            txtGenre.SendKeys(MovieGenre);
            txtRating.SendKeys(MovieRating);
            txtImageLink.SendKeys(MovieImageLink);
            txtPurchasePrice.SendKeys(MoviePurchaseRate);
            txtRentalPrice.SendKeys(MovieRentalRate);
            txtTrailer.SendKeys(MovieTrailerLink);
            txtWideImage.SendKeys(MovieWideImagelink);
            btnAddMovie.Click();
            return new MovieCarouselPage(DriverContext.Driver);
        }
        public MoviesDeletePage openDeleteMovie()
        {
            btnDeleteMovie.Click();
            return new MoviesDeletePage(DriverContext.Driver);
        }
    }
}
