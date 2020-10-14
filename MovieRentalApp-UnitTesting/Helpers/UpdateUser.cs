using MovieRentalApp.Data;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp_UnitTesting.Helpers
{
    public class UpdateUser : IUpdateUser
    {
        private readonly MovieRentalDBContext _context;

        public UpdateUser(MovieRentalDBContext context)
        {
            _context = context;
        }

        public bool updateOrNot(bool value)
        {
            if (value)
                return true;
            return false;
        }
    }
}
