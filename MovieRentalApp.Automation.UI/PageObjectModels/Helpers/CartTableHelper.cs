using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace MovieRentalApp.Automation.UI.PageObjectModels.Helpers
{
    public class CartTableHelper 
    {

        public static void ReadTable(IWebElement table, string movieName, string rentOrPurchase, IWebDriver webDriver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(3));

            var columns = table.FindElements(By.TagName("th"));
            
            var rows = table.FindElements(By.TagName("tr"));
            
            foreach (var row in rows)
            {
                //var colDatas = row.FindElements(By.TagName("td"));
                var movieTitleList = row.FindElements(By.ClassName("title-list"));
                
                foreach (var item in movieTitleList)
                {
                    var movieTitle = item.FindElement(By.TagName("h6"));
                    if (movieTitle.Text == movieName)
                    {
                        var moviePriceList = row.FindElements(By.ClassName("price-list"));
                        foreach (var moviePrice in moviePriceList)
                        {
                            if (rentOrPurchase == "rent")
                            {
                                var rentalPriceBtn = moviePrice.FindElement(By.ClassName("rent"));
                                if (rentalPriceBtn.Text == "Rent")
                                {
                                    //Thread.Sleep(2000);

                                    wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("rent")));
                                    //Refreshed(ExpectedConditions.stalenessOf("table")));
                                    //wait.Until(ExpectedConditions.ElementExists(By.ClassName("rent")));
                                    js.ExecuteScript("arguments[0].click();", rentalPriceBtn);
                                    goto Finish;
                                    //rentalPriceBtn.Click();
                                }    
                            }
                            else if (rentOrPurchase == "purchase")
                            {
                                var purchasePriceBtn = moviePrice.FindElement(By.ClassName("purchase"));
                                if (purchasePriceBtn.Text == "Purchase")
                                {
                                    //Thread.Sleep(2000);
                                    wait.Until(ExpectedConditions.ElementExists(By.ClassName("purchase")));
                                    js.ExecuteScript("arguments[0].click();", purchasePriceBtn);
                                    goto Finish;
                                    //purchasePriceBtn.Click();
                                }
                                    
                            }

                        }
                        
                    }
                }
            }
        Finish:
            Console.WriteLine("Done");
        }
    }
}
