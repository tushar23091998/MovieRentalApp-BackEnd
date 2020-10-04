using MovieRentalApp.Helpers;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Interfaces
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<TblUser>> GetUsers(UserParams userParams);
        Task<TblUser> GetUser(int id);
    }
}
