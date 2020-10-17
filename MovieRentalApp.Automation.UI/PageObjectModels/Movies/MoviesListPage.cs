using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Movies
{
    public class MoviesListPage : BasePage
    {
        string movieElement = "body > app-root > app-tblmovie > div:nth-child(2) > div > div:nth-child(1) > div > a > img";
        public MoviesListPage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement txtSearchBar => WebDriver.FindElement(By.Name("search"));
        public IWebElement priceToggle => WebDriver.FindElement(By.Id("rentalprice"));
        public IWebElement ratingsToggle => WebDriver.FindElement(By.Id("ratings"));
        public IWebElement lnkMovie => WebDriver.FindElement(By.CssSelector(movieElement));

        public void openMovie()
        {
            NavBarPage navBarPage = new NavBarPage(DriverContext.Driver);
            navBarPage.lnkMovieList.Click();
            lnkMovie.Click();
            Thread.Sleep(2000);
        }
    }
}
