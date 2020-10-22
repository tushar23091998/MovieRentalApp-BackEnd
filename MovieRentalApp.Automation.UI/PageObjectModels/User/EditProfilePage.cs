using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels
{
    public class EditProfilePage: BasePage
    {
        public EditProfilePage(IWebDriver webDriver) : base(webDriver) { }
        public IWebElement txtName => WebDriver.FindElement(By.Name("aname"));
        public IWebElement txtAddress => WebDriver.FindElement(By.Name("aAddress"));
        public IWebElement txtPhone=> WebDriver.FindElement(By.Name("aPhone"));
        public IWebElement userName => WebDriver.FindElement(By.TagName("h1"));
        public IWebElement btnAdmin => WebDriver.FindElement(By.Id("btnadmin"));
        public IWebElement btnSaveChanges => WebDriver.FindElement(By.Id("save"));

        public void changeDetails(string name, string address, string number)
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtName.SendKeys(name);
            txtAddress.SendKeys(address);
            txtPhone.SendKeys(number);
            Thread.Sleep(2000);
            btnSaveChanges.Click();
            Thread.Sleep(1000);
        }
        public MovieAddPage goToAdmin()
        {
            btnAdmin.Click();
            return new MovieAddPage(DriverContext.Driver);
        }
        public bool changeReflected(string name)
        {
            Thread.Sleep(1000);
            return userName.Text.Contains(name);
        }

    }
}
