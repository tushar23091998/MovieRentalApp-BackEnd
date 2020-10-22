using MovieRentalApp.Automation.UI.PageObjectModels.Authentication;
using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using MovieRentalApp.Automation.UI.PageObjectModels.User;
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
        public IWebElement lnkCart => WebDriver.FindElement(By.Id("cart"));
        public IWebElement lnkLogOut => WebDriver.FindElement(By.LinkText("Log Out"));
        public IWebElement lnkDropdown => WebDriver.FindElement(By.Id("dropdownMenuLink"));
        public IWebElement lnkOrder => WebDriver.FindElement(By.Id("order"));
        public IWebElement lnkEditProfile => WebDriver.FindElement(By.Id("edit"));
        public MovieCarouselPage Logout()
        {
            lnkLogOut.Click();
            return new MovieCarouselPage(DriverContext.Driver);
        }
        public LoginPage openLogin()
        {
            lnkSignIn.Click();
            return new LoginPage(DriverContext.Driver);
        }
        public RegisterPage openRegister()
        {
            lnkRegister.Click();
            return new RegisterPage(DriverContext.Driver);
        }
        public MoviesListPage goToMovies()
        {
            lnkMovieList.Click();
            return new MoviesListPage(DriverContext.Driver);
        }
        public MovieCarouselPage goToHome()
        {
            lnkHome.Click();
            return new MovieCarouselPage(DriverContext.Driver);
        }
        public CartPage openCart()
        {
            lnkCart.Click();
            return new CartPage(DriverContext.Driver);
        }
        public UserOrdersPage openUserOrder()
        {
            lnkDropdown.Click();
            lnkOrder.Click();
            return new UserOrdersPage(DriverContext.Driver);
        }
        public EditProfilePage openEditProfile()
        {
            lnkDropdown.Click();
            lnkEditProfile.Click();
            return new EditProfilePage(DriverContext.Driver);
        }
        public string getLoggedInUser()
        {
            return lnkDropdown.Text;
        }
        public bool CheckIfLoginExist()
        {
            return lnkSignIn.Displayed;
        }

    }
}
