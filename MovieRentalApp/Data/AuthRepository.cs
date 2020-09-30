using MovieRentalApp.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using MovieRentalApp.Interfaces;

namespace MovieRentalApp.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MovieRentalDBContext _context;

        public AuthRepository(MovieRentalDBContext context)
        {
            _context = context;
        }
        public async Task<TblUser> Login(string username, string password)
        {
            var user = await _context.TblUser.FirstOrDefaultAsync(x => x.AUsername == username);
            if(user==null)
                return null;

            if (!VerifyPasswordHash(password, user.APasswordHash, user.APasswordSalt))
            {
                return null;
            }
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i =0;i < computedHash.Length;i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<TblUser> Register(TblUser user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.APasswordHash = passwordHash;
            user.APasswordSalt = passwordSalt;
            await _context.TblUser.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
                
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.TblUser.AnyAsync(x => x.AUsername == username))
                return true;
            return false;
        }
    }
}
