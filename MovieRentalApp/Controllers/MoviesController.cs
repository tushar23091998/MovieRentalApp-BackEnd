using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Data;
using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Interfaces;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieRentalApp.Dtos;

namespace MovieRentalApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _repo;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _repo.GetMovies();
            var moviesToReturn = _mapper.Map<IEnumerable<MovieForListDto>>(movies);
            return Ok(moviesToReturn);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _repo.GetMovie(id);
            var movieToReturn = _mapper.Map<MovieForDetailedDto>(movie);
            return Ok(movieToReturn);
        }
    }
}
