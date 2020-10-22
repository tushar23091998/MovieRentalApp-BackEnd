using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Movies
{
    public class MoviesDetailPage : BasePage
    {
        public MoviesDetailPage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement addToCartButton => WebDriver.FindElement(By.Id("addToCart"));

        public void addtoCart()
        {
            addToCartButton.Click();
            Thread.Sleep(1000);
        }

    }
}
