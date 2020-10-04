using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Helpers;
using MovieRentalApp.Interfaces;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieRentalDBContext _context;

        public UserRepository(MovieRentalDBContext context)
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

        public async Task<TblUser> GetUser(int id)
        {
            var user = await _context.TblUser.Include(order => order.TblOrder).ThenInclude(order => order.AMovie)
                .FirstOrDefaultAsync(customer => customer.ACustomerId == id);

            return user;
        }

        public async Task<IEnumerable<TblUser>> GetUsers(UserParams userParams)
        {
            var users = _context.TblUser.OrderBy(user => user.ACustomerId);

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "acustomerid":
                        users = users.OrderBy(user => user.ACustomerId);
                        break;
                    default:
                        users = users.OrderBy(user => user.AUsername);
                        break;
                }
            }
            return await users.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
