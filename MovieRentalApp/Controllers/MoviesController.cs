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
using MovieRentalApp.Helpers;
using MovieRentalApp.Models;

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
        public async Task<IActionResult> GetMovies([FromQuery]MovieParams movieParams)
        {
            var movies = await _repo.GetMovies(movieParams);
            var moviesToReturn = _mapper.Map<IEnumerable<MovieForListDto>>(movies);
            Response.AddPagination(movies.CurrentPage, movies.PageSize, movies.TotalCount, movies.TotalPages);
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

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> AddMovie(MovieForDetailedDto movieForDetailedDto)
        { 
            if (await _repo.MovieExists(movieForDetailedDto.ATitle))
                return BadRequest("movie already exists");

            var movieToCreate = _mapper.Map<TblMovie>(movieForDetailedDto);

            var createdMovie = await _repo.AddMovie(movieToCreate);

            return Ok(createdMovie);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
                var tblMovie = await _repo.GetMovie(id);
                _repo.Delete(tblMovie);
                return Ok("object deleted");
        }
    }
}
