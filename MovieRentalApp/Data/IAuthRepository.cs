using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Data
{
    public interface IAuthRepository
    {
        Task<TblUser> Register(TblUser user, string password);
        Task<TblUser> Login(string username, string password);
        Task<bool> UserExists(string username);
    }

}
