using MovieRentalApp.Data;
using MovieRentalApp.Dtos;
using MovieRentalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace MovieRentalApp_UnitTesting.ControllerTests
{
    public class getMoviesHelper
    {
        public  TblMovie movieById(int id)
        {
            var movies = getMovieFromList();
            foreach(TblMovie tblMovie in movies)
            {
                if(tblMovie.AMovieId == id)
                {
                    return tblMovie;
                }
            }
            return null;
        }
        public TblMovie movieByNameExists(TblMovie tMovie)
        {
            var movies = getMovieFromList();
            foreach (TblMovie tblMovie in movies)
            {
                if (tblMovie.ATitle == tMovie.ATitle)
                {
                    return null;
                }
            }
            return tMovie;
        }
        public List<TblMovie> getMovieFromList()
        {
            var movies = new List<TblMovie>();
            movies.Add(new TblMovie()
            {
                AMovieId = 2,
                ATitle = "Big Hero 6",
                AMovieDescription = "An action comedy adventure about brilliant robotics prodigy Hiro Hamada, who finds himself in the grips of a criminal plot that threatens to destroy the fast-paced, high-tech city of San Fransokyo. With the help of his closest companion-a robot named Baymax-Hiro joins forces with a reluctant team of first-time crime fighters on a mission to save their city.",
                ADuration = "105 min",
                APrice = "10",
                APurchasePrice = "25",
                ARating = 5,
                AImageLink = "http://upload.wikimedia.org/wikipedia/en/4/4b/Big_Hero_6_%28film%29_poster.jpg",
                ATrailerLink = "//www.youtube.com/embed/z3biFxZIJOQ",
                AGenre = "Comedy",
                AWideImage = "https://github.com/tushar23091998/MovieRentalApp-FrontEnd/blob/master/src/app/images/bighero6.jpg?raw=true"
            });
            movies.Add(new TblMovie()
            {
                AMovieId = 7,
                ATitle = "Indiana Jones and The Last Crusade",
                AMovieDescription = "When Dr. Henry Jones Sr. suddenly goes missing while pursuing the Holy Grail, eminent archaeologist Indiana Jones must follow in his father's footsteps and stop the Nazis.",
                ADuration = "127 min",
                APrice = "15",
                APurchasePrice = "33",
                ARating = 5,
                AImageLink = "https://upload.wikimedia.org/wikipedia/en/8/8c/Indiana_Jones_and_the_Last_Crusade.png",
                ATrailerLink = "//www.youtube.com/embed/A7TaY8HWYd8",
                AGenre = "Action",
                AWideImage = "https://github.com/tushar23091998/MovieRentalApp-FrontEnd/blob/master/src/app/images/indianajoneslc.jpg?raw=true"
            });
            movies.Add(new TblMovie()
            {
                AMovieId = 3,
                ATitle = "Raging Bull",
                AMovieDescription = "An emotionally self-destructive boxer's journey through life, as the violence and temper that leads him to the top in the ring, destroys his life outside it.",
                ADuration = "129 min",
                APrice = "10",
                APurchasePrice = "30",
                ARating = 4,
                AImageLink = "http://upload.wikimedia.org/wikipedia/en/5/5f/Raging_Bull_poster.jpg",
                ATrailerLink = "//www.youtube.com/embed/mHhzOM4gBIA",
                AGenre = "Drama",
                AWideImage = "https://github.com/tushar23091998/MovieRentalApp-FrontEnd/blob/master/src/app/images/ragingbull.jpg?raw=true"
            });
            return movies;
        }
    }
}
