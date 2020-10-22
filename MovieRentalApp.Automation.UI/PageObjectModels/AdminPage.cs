//using MovieRentalApp.Automation.UI.PageObjectModels.Movies;
//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace MovieRentalApp.Automation.UI.PageObjectModels
//{
//    public class AdminPage : BasePage
//    {
//        public AdminPage(IWebDriver webDriver) : base(webDriver) { }
//        public IWebElement btnUserDetails => WebDriver.FindElement(By.Id("userdetail"));
//        public IWebElement btnAddmovie => WebDriver.FindElement(By.Id("addmoviebtn"));
//        public IWebElement btnDeleteMovie => WebDriver.FindElement(By.Id("deletemoviebtn"));
//        public MovieAddPage openAddMovie()
//        {
//            btnAddmovie.Click();
//            return new MovieAddPage(DriverContext.Driver);
//        }
//        public MoviesDeletePage openDeleteMovie()
//        {
//            btnDeleteMovie.Click();
//            return new MoviesDeletePage(DriverContext.Driver);
//        }
//    }
//}
