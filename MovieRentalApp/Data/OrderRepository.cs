using MovieRentalApp.Interfaces;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MovieRentalDBContext _context;

        public OrderRepository(MovieRentalDBContext context)
        {
            _context = context;
        }
        public async Task<TblOrder> AddOrder(TblOrder tblOrder)
        {
            await _context.TblOrder.AddAsync(tblOrder);
            await _context.SaveChangesAsync();
            return tblOrder;
        }
    }
}
