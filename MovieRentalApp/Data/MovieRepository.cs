using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Helpers;
using MovieRentalApp.Interfaces;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MovieRentalApp.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieRentalDBContext _context;

        public MovieRepository(MovieRentalDBContext context)
        {
            _context = context;
        }
        public async Task<TblMovie> AddMovie(TblMovie tblMovie)
        {
            await _context.TblMovie.AddAsync(tblMovie);
            await _context.SaveChangesAsync();
            return tblMovie;
        }

        public void Delete(TblMovie tblMovie)
        {
             _context.TblMovie.Remove(tblMovie);
             _context.SaveChangesAsync();
        }

        public async Task<TblMovie> GetMovie(int id)
        {
            var movie = await _context.TblMovie.Include(actor => actor.TblMovieActorMapping).ThenInclude(actor => actor.AActor)
                .Include(director => director.TblMovieDirectorMapping).ThenInclude(director => director.ADirector)
                .FirstOrDefaultAsync(movie => movie.AMovieId == id);

            return movie;
        }

        public async Task<PagedList<TblMovie>> GetMovies(MovieParams movieParams)
        {
            var movies =  _context.TblMovie.OrderByDescending(movie => movie.ARating);

            if (!string.IsNullOrEmpty(movieParams.OrderBy))
            {
                switch (movieParams.OrderBy)
                {
                    case "rating":
                        movies = movies.OrderByDescending(movie => movie.ARating);
                        break;
                    default:
                        movies = movies.OrderBy(movie => movie.APrice);
                        break;
                }
            }

            return await PagedList<TblMovie>.CreateAsync(movies, movieParams.PageNumber, movieParams.PageSize);
        }


        public async Task<bool> MovieExists(string movieName)
        {
            if (await _context.TblMovie.AnyAsync(x => x.ATitle.ToLower() == movieName.ToLower()))
                return true;
            return false;
        }
    }
}
