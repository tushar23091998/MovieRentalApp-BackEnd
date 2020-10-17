using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MovieRentalApp.Automation.UI.PageObjectModels
{
    public class BasePage : IPage
    {
        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        protected IWebDriver WebDriver { get; }
        public Actions GetActionsInstance()
        {
            return new Actions(WebDriver);
        }
    }
}
