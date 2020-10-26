using MovieRentalApp.Automation.UI.PageObjectModels.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver webDriver) : base(webDriver) { }

        
        public IWebElement tblMoviesInCart => WebDriver.FindElement(By.TagName("table"));
        public IWebElement deleteMovieButton => WebDriver.FindElement(By.Id("delete"));
        public IWebElement clearCartButton => WebDriver.FindElement(By.Id("clear"));
        public IWebElement checkOutButton => WebDriver.FindElement(By.Id("checkout"));


        public void chooseTypeAndCheckout()
        {
           
            NavBarPage navBarPage = new NavBarPage(WebDriver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            navBarPage.lnkCart.Click();
            CartTableHelper.ReadTable(tblMoviesInCart, "Big Hero 6", "rent", WebDriver);
            Thread.Sleep(1000);
            CartTableHelper.ReadTable(tblMoviesInCart, "Gandhi", "rent", WebDriver);
            Thread.Sleep(1000);
            CartTableHelper.ReadTable(tblMoviesInCart, "Goodfellas", "purchase", WebDriver);
            Thread.Sleep(1000);
            js.ExecuteScript("arguments[0].click();", checkOutButton);
            //checkOutButton.Click();
            Thread.Sleep(1000);
        }
    }
}
