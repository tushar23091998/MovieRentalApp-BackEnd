﻿using MovieRentalApp.Helpers;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Interfaces
{
    public interface IMovieRepository
    {
        Task<TblMovie> AddMovie(TblMovie tblMovie);
        void Delete(TblMovie tblMovie);
        Task<bool> MovieExists(string movieName);
        Task<IEnumerable<TblMovie>> GetMovies(MovieParams movieParams);
        Task<TblMovie> GetMovie(int id);
    }
}
