using MovieRentalApp.Helpers;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Interfaces
{
    public interface IMovieRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<TblMovie>> GetMovies(MovieParams movieParams);
        Task<TblMovie> GetMovie(int id);
    }
}
