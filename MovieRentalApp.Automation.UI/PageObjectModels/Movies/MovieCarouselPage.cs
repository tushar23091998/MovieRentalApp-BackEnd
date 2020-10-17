using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Movies
{
    public class MovieCarouselPage: BasePage
    {
        string pageButtonNumber = "body > app-root > app-home > div > div > app-moviecarousel > div > owl-carousel-o > div > div.owl-dots.ng-star-inserted > div:nth-child(3) > span";
        string movieElement = "body > app-root > app-home > div > div > app-moviecarousel > div > owl-carousel-o > div > div.owl-stage-outer.ng-star-inserted > owl-stage > div > div > div:nth-child(31) > div > a > img";
        public MovieCarouselPage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement nextMovieButton => WebDriver.FindElement(By.CssSelector("body > app-root > app-home > div > div > app-moviecarousel > div > owl-carousel-o > div > div.owl-nav.ng-star-inserted > div.owl-next"));
        public IWebElement previousMovieButton => WebDriver.FindElement(By.CssSelector("body > app-root > app-home > div > div > app-moviecarousel > div > owl-carousel-o > div > div.owl-nav.ng-star-inserted > div.owl-prev"));
        public IWebElement pageButton => WebDriver.FindElement(By.CssSelector(pageButtonNumber));
        public IWebElement lnkCarouselMovie => WebDriver.FindElement(By.CssSelector(movieElement));

        public void addMovieFromCarousel()
        {
            NavBarPage navBarPage = new NavBarPage(DriverContext.Driver);
            navBarPage.lnkHome.Click();
            nextMovieButton.Click();
            nextMovieButton.Click();
            pageButton.Click();
            lnkCarouselMovie.Click();
            Thread.Sleep(2000);
        }
    }
}
