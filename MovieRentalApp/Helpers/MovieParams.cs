using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Helpers
{
    
    public class MovieParams
    {
        private const int MaxPageSize = 1000;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 100;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; } 
        }

        public string OrderBy { get; set; }

    }
}
