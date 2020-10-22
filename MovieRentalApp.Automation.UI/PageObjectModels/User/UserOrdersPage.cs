using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieRentalApp.Automation.UI.PageObjectModels.User
{
    public class UserOrdersPage : BasePage
    {
        public UserOrdersPage(IWebDriver webDriver) : base(webDriver) { }
        public ReadOnlyCollection<IWebElement> lnkRentalMovies => WebDriver.FindElements(By.ClassName("rent-list"));
        public ReadOnlyCollection<IWebElement> lnkPurchasedMovies => WebDriver.FindElements(By.ClassName("purchase-list"));
        public bool rentalMovieExists(string movieName)
        {
            MovieHelper.ReadMovies(lnkRentalMovies);
            return MovieHelper.ifMovieExists(movieName);
        }
        public bool purchasedMovieExists(string movieName)
        {
            MovieHelper.ReadMovies(lnkPurchasedMovies);
            return MovieHelper.ifMovieExists(movieName);
        }
    }
}
