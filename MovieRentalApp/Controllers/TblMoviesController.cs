using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using LinqToDB;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Data;
using MovieRentalApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace MovieRentalApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TblMoviesController : ControllerBase
    {
        private readonly MovieRentalDBContext _context;

        public TblMoviesController(MovieRentalDBContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.TblMovie.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.TblMovie.FirstOrDefaultAsync(x => x.AMovieId == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
