using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Interfaces
{
    public interface IOrderRepository
    {
        Task<TblOrder> AddOrder(TblOrder tblOrder);
    }
}
