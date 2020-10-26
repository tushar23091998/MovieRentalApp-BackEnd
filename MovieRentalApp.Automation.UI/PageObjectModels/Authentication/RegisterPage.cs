using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Authentication
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement txtRegUsername => WebDriver.FindElement(By.Id("aUsername"));
        public IWebElement txtRegPassword => WebDriver.FindElement(By.Id("password"));
        public IWebElement txtConfirmPassword => WebDriver.FindElement(By.Id("confirm"));
        public IWebElement txtName => WebDriver.FindElement(By.Id("aname"));
        public IWebElement txtEmail => WebDriver.FindElement(By.Id("aEmail"));
        public IWebElement txtDob => WebDriver.FindElement(By.Id("aDob"));
        public IWebElement btnLogin => WebDriver.FindElement(By.Id("button"));

        public MovieCarouselPage Register(string username, string password, string confirmpassword, string email, string name, string dob)
        {
            NavBarPage navBarPage = new NavBarPage(WebDriver);
            navBarPage.lnkRegister.Click();
            txtRegUsername.SendKeys(username);
            txtRegPassword.SendKeys(password);
            txtConfirmPassword.SendKeys(confirmpassword);
            txtName.SendKeys(name);
            txtEmail.SendKeys(email);
            txtDob.SendKeys(dob);
            Thread.Sleep(1000);
            btnLogin.Click();
            Thread.Sleep(1000);
            return new MovieCarouselPage(WebDriver);
        }
    }
}
