using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRentalApp.Automation.UI.PageObjectModels
{
    public  class NavBarPage : BasePage
    {
        public NavBarPage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement lnkSignIn => WebDriver.FindElement(By.LinkText("Sign In"));
        public IWebElement lnkRegister => WebDriver.FindElement(By.LinkText("Register"));
        public IWebElement lnkHome => WebDriver.FindElement(By.LinkText("CHEAPFLIX"));
        public IWebElement lnkMovieList => WebDriver.FindElement(By.LinkText("Movie List"));
        public IWebElement lnkCart => WebDriver.FindElement(By.LinkText("Cart"));
        public IWebElement lnkLogOut => WebDriver.FindElement(By.LinkText("Log Out"));
        public IWebElement lnkDropdown => WebDriver.FindElement(By.Id("dropdownMenuLink"));
        public IWebElement lnkOrder => WebDriver.FindElement(By.Id("order"));
        public IWebElement lnkEditProfile => WebDriver.FindElement(By.Id("edit"));
        public void Logout()
        {
            lnkLogOut.Click();
        }

    }
}
