﻿using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Interfaces;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<TblMovie> GetMovie(int id)
        {
            var movie = await _context.TblMovie.Include(actor => actor.TblMovieActorMapping).ThenInclude(actor => actor.AActor)
                .Include(director => director.TblMovieDirectorMapping).ThenInclude(director => director.ADirector)
                .FirstOrDefaultAsync(movie => movie.AMovieId == id);

            return movie;
        }

        public async Task<IEnumerable<TblMovie>> GetMovies()
        {
            var movies = await _context.TblMovie.ToListAsync();
            return movies;
        }


        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}