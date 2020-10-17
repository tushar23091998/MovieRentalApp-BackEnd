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

        public void Register()
        {
            NavBarPage navBarPage = new NavBarPage(DriverContext.Driver);
            navBarPage.lnkRegister.Click();
            txtRegUsername.SendKeys("graham");
            txtRegPassword.SendKeys("password");
            txtConfirmPassword.SendKeys("password");
            txtName.SendKeys("Graham");
            txtEmail.SendKeys("graham@gmail.com");
            txtDob.SendKeys("10/20/1998");
            Thread.Sleep(1000);
            btnLogin.Click();
            Thread.Sleep(1000);
        }
    }
}
