﻿using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Authentication
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement txtUsername => WebDriver.FindElement(By.Id("username"));
        public IWebElement txtPassword => WebDriver.FindElement(By.Id("password"));
        public IWebElement btnLogin => WebDriver.FindElement(By.Id("button"));

        public MovieCarouselPage Login(string username, string password)
        {
            NavBarPage navBarPage = new NavBarPage(WebDriver);
            navBarPage.lnkSignIn.Click();
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            Thread.Sleep(1000);
            btnLogin.Click();
            Thread.Sleep(1000);
            return new MovieCarouselPage(WebDriver);
        }
    }
}
