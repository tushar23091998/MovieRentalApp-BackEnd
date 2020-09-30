using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<TblUser>> GetUsers()
        {
            var users = await _context.TblUser.ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
