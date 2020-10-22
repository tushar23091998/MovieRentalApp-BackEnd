using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieRentalApp.Automation.UI.PageObjectModels
{
    public class MovieHelper
    {
        private static List<string> _movieNameCollection;

        public static void ReadMovies(ReadOnlyCollection<IWebElement> moviesDiv)
        {

            _movieNameCollection = new List<string>();
            foreach (var movieDiv in moviesDiv)
            {
                var movieName = movieDiv.FindElement(By.TagName("h6"));
                _movieNameCollection.Add(movieName.Text);

            }  
        }
        public static int findMovieIndex(string movieTitle)
        {
           return _movieNameCollection.IndexOf(movieTitle);
        }
        public  static bool ifMovieExists(string movieTitle)
        {
            return _movieNameCollection.Contains(movieTitle);
        }
    }
}
