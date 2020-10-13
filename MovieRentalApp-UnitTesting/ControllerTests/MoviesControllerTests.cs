using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MovieRentalApp.Controllers;
using MovieRentalApp.Data;
using MovieRentalApp.Dtos;
using MovieRentalApp.Helpers;
using MovieRentalApp.Interfaces;
using MovieRentalApp.Models;
using MovieRentalApp_UnitTesting.ControllerTests;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace MovieRentalApp_UnitTesting.ControllerTests
{
    [TestFixture]
    public class MoviesControllerTests
    {
        private Mock<IMovieRepository> _mockMovieRepository;
        private Mock<IMapper> _mockMovieMapper;
        private MoviesController _moviesController;

        [SetUp]
        public void Setup()
        {
            //_mockMovieRepository = new Mock<IMovieRepository>();
            //_mockMovieMapper = new Mock<IMapper>();

        }

        [Test]
        public async Task CallGetRequest_WhenCalled_ReturnsAllMovies()
        {
            getMoviesHelper getMoviesHelper = new getMoviesHelper();
            List<TblMovie> movieList = getMoviesHelper.getMovieFromList();
            List<MovieForListDto> movieForListDtos = new List<MovieForListDto>(3);
            for (int i = 0; i < movieList.Count; i++)
            {
                MovieForListDto movieForListDto = new MovieForListDto();
                movieForListDto.ATitle = movieList[i].ATitle;
                movieForListDto.AMovieId = movieList[i].AMovieId;
                movieForListDto.AMovieDescription = movieList[i].AMovieDescription;
                movieForListDto.ADuration = movieList[i].ADuration;
                movieForListDto.AGenre = movieList[i].AGenre;
                movieForListDto.AImageLink = movieList[i].AImageLink;
                movieForListDto.APrice = movieList[i].APrice;
                movieForListDto.ATrailerLink = movieList[i].ATrailerLink;
                movieForListDto.ARating = movieList[i].ARating;
                movieForListDto.APurchasePrice = movieList[i].APurchasePrice;

                movieForListDtos.Add(movieForListDto);
            }
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockMovieMapper = new Mock<IMapper>();
            _mockMovieMapper.Setup(mapper => mapper.Map<IEnumerable<MovieForListDto>>(It.IsAny<TblMovie[]>())).Returns(movieForListDtos);
            _mockMovieRepository.Setup(repo => repo.GetMovies(new MovieParams{}))
            .ReturnsAsync(getMoviesHelper.getMovieFromList());
            _moviesController = new MoviesController(_mockMovieRepository.Object, _mockMovieMapper.Object);
            var movies = await _moviesController.GetMovies(new MovieParams{});
            var okResult = movies as OkObjectResult;
            var result = ((OkObjectResult)movies).Value;
            Assert.AreEqual(result, movieForListDtos);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.NotNull(movies);
            Assert.IsAssignableFrom<OkObjectResult>(movies);
        }

        [Test]
        public async Task DeleteMovie_WhenCalled_DeleteTheMovieFromDb()
        {
            getMoviesHelper getMoviesHelper = new getMoviesHelper();
            List<TblMovie> movieList = getMoviesHelper.getMovieFromList();
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockMovieMapper = new Mock<IMapper>();
            _mockMovieRepository.Setup(repo => repo.Delete(It.IsAny<TblMovie>()));
            _mockMovieRepository.Setup(repo => repo.GetMovie(It.IsAny<int>())).ReturnsAsync(getMoviesHelper.movieById(3));
            _moviesController = new MoviesController(_mockMovieRepository.Object,_mockMovieMapper.Object);
            var tblMovie = await _moviesController.Delete(3);
            var okResult = tblMovie as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.NotNull(tblMovie);
            Assert.AreEqual("object deleted", okResult.Value);       
        }

        [Test]
        public async Task DeleteMovie_WhenCalledWithInvalidId_ReturnsBadRequest()
        {
            getMoviesHelper getMoviesHelper = new getMoviesHelper();
            List<TblMovie> movieList = getMoviesHelper.getMovieFromList();
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockMovieMapper = new Mock<IMapper>();
            _mockMovieRepository.Setup(repo => repo.Delete(It.IsAny<TblMovie>()));
            _mockMovieRepository.Setup(repo => repo.GetMovie(It.IsAny<int>())).ReturnsAsync(getMoviesHelper.movieById(15));
            _moviesController = new MoviesController(_mockMovieRepository.Object, _mockMovieMapper.Object);
            var tblMovie = await _moviesController.Delete(3);
            var okResult = tblMovie as OkObjectResult;
            Assert.IsInstanceOf<BadRequestObjectResult>(tblMovie);
        }

        [Test]
        public async Task GetMovie_WhenCalledWithNonExistentId_ReturnsBadRequest()
        {
            getMoviesHelper getMoviesHelper = new getMoviesHelper();
            List<TblMovie> movieList = getMoviesHelper.getMovieFromList();
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockMovieMapper = new Mock<IMapper>();
            _mockMovieMapper.Setup(mapper => mapper.Map<MovieForDetailedDto>(It.IsAny<TblMovie>())).Returns(new MovieForDetailedDto());
            _mockMovieRepository.Setup(repo => repo.GetMovie(15))
                    .ReturnsAsync(getMoviesHelper.movieById(15));
            _moviesController = new MoviesController(_mockMovieRepository.Object, _mockMovieMapper.Object);
            var tblMovie = await _moviesController.GetMovie(15);
            Assert.IsInstanceOf<BadRequestObjectResult>(tblMovie);
        }

        [Test]
        public async Task CallGetRequest_WhenCalledWithId_ReturnsTheMovieWithTheSameId()
        {
            getMoviesHelper getMoviesHelper = new getMoviesHelper();
            List<TblMovie> movieList = getMoviesHelper.getMovieFromList();
            var movie = getMoviesHelper.movieById(3);
            MovieForDetailedDto movieForDetailedDto = new MovieForDetailedDto();
            movieForDetailedDto.ATitle = movie.ATitle;
            movieForDetailedDto.AMovieId = movie.AMovieId;
            movieForDetailedDto.AMovieDescription = movie.AMovieDescription;
            movieForDetailedDto.ADuration = movie.ADuration;
            movieForDetailedDto.AGenre = movie.AGenre;
            movieForDetailedDto.AImageLink = movie.AImageLink;
            movieForDetailedDto.APrice = movie.APrice;
            movieForDetailedDto.ATrailerLink = movie.ATrailerLink;
            movieForDetailedDto.ARating = movie.ARating;
            movieForDetailedDto.APurchasePrice = movie.APurchasePrice;
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockMovieMapper = new Mock<IMapper>();
            //_mockMovieMapper.Setup(mapper => mapper.Map<TblMovie>(It.IsAny<MovieForDetailedDto>()))
            //    .Returns(getMoviesHelper.movieById(3));
            _mockMovieMapper.Setup(mapper => mapper.Map<MovieForDetailedDto>(It.IsAny<TblMovie>())).Returns(movieForDetailedDto);
            _mockMovieRepository.Setup(repo => repo.GetMovie(It.IsAny<int>()))
                    .ReturnsAsync(getMoviesHelper.movieById(3));
            _moviesController = new MoviesController(_mockMovieRepository.Object, _mockMovieMapper.Object);
            var tblMovie = await _moviesController.GetMovie(3);
            var okResult = tblMovie as OkObjectResult;
            //Assert.AreEqual(200, okResult.StatusCode);
            Assert.NotNull(tblMovie);
            Assert.IsAssignableFrom<OkObjectResult>(tblMovie);
            var result = ((OkObjectResult)tblMovie).Value;
            Assert.AreEqual(result, movieForDetailedDto);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<MovieForDetailedDto>(result);
        }

        [Test]
        public async Task GivenAValidMovie_WhenIPostANewMovie_ThenItReturnsOkWithResponse()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockMovieMapper = new Mock<IMapper>();
            TblMovie expectedMovie = new TblMovie
            {
                AMovieId = 55,
                ATitle = "redemption",
                AMovieDescription = "An action comedy adventure about brilliant robotics prodigy Hiro Hamada, who finds himself in the grips of a criminal plot that threatens to destroy the fast-paced, high-tech city of San Fransokyo. With the help of his closest companion-a robot named Baymax-Hiro joins forces with a reluctant team of first-time crime fighters on a mission to save their city.",
                ADuration = "105 min",
                APrice = "10",
                APurchasePrice = "25",
                ARating = 5,
                AImageLink = "http://upload.wikimedia.org/wikipedia/en/4/4b/Big_Hero_6_%28film%29_poster.jpg",
                ATrailerLink = "//www.youtube.com/embed/z3biFxZIJOQ",
                AGenre = "Comedy",
                AWideImage = "https://github.com/tushar23091998/MovieRentalApp-FrontEnd/blob/master/src/app/images/bighero6.jpg?raw=true"
            };
            _mockMovieMapper.Setup(mapper => mapper.Map<TblMovie>(It.IsAny<MovieForDetailedDto>()))
                .Returns(expectedMovie);
            _mockMovieRepository.Setup(repo => repo.AddMovie(It.IsAny<TblMovie>()))
                .ReturnsAsync((TblMovie movie) => movie);

            _moviesController = new MoviesController(_mockMovieRepository.Object, _mockMovieMapper.Object);
            var tblMovie = await _moviesController.AddMovie(new MovieForDetailedDto
            {
                AMovieId = 55,
                ATitle = "redemption",
                AMovieDescription = "An action comedy adventure about brilliant robotics prodigy Hiro Hamada, who finds himself in the grips of a criminal plot that threatens to destroy the fast-paced, high-tech city of San Fransokyo. With the help of his closest companion-a robot named Baymax-Hiro joins forces with a reluctant team of first-time crime fighters on a mission to save their city.",
                ADuration = "105 min",
                APrice = "10",
                APurchasePrice = "25",
                ARating = 5,
                AImageLink = "http://upload.wikimedia.org/wikipedia/en/4/4b/Big_Hero_6_%28film%29_poster.jpg",
                ATrailerLink = "//www.youtube.com/embed/z3biFxZIJOQ",
                AGenre = "Comedy",
                AWideImage = "https://github.com/tushar23091998/MovieRentalApp-FrontEnd/blob/master/src/app/images/bighero6.jpg?raw=true"
            });
            var okResult = tblMovie as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.NotNull(okResult);
            Assert.IsAssignableFrom<OkObjectResult>(tblMovie);
            var result = ((OkObjectResult)tblMovie).Value;
            Assert.NotNull(result);
            Assert.AreEqual(expectedMovie,result);
            Assert.IsAssignableFrom<TblMovie>(result);


        }


        [Test]
        public async Task GivenAValidMovie_WhenIPostANewMovieWithExistingName_ThenItReturnsbadRequest()
        {
            getMoviesHelper getMoviesHelper = new getMoviesHelper();
            List<TblMovie> movieList = getMoviesHelper.getMovieFromList();
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockMovieMapper = new Mock<IMapper>();
            _mockMovieMapper.Setup(mapper => mapper.Map<TblMovie>(It.IsAny<MovieForDetailedDto>()))
                    .Returns(new TblMovie());
            _mockMovieRepository.Setup(r => r.MovieExists(It.IsAny<string>())).ReturnsAsync(true);
            _moviesController = new MoviesController(_mockMovieRepository.Object, _mockMovieMapper.Object);
            var tblMovie = await _moviesController.AddMovie(new MovieForDetailedDto
            {
                AMovieId = 3,
                ATitle = "Big Hero 6",
                AMovieDescription = "An action comedy adventure about brilliant robotics prodigy Hiro Hamada, who finds himself in the grips of a criminal plot that threatens to destroy the fast-paced, high-tech city of San Fransokyo. With the help of his closest companion-a robot named Baymax-Hiro joins forces with a reluctant team of first-time crime fighters on a mission to save their city.",
                ADuration = "105 min",
                APrice = "10",
                APurchasePrice = "25",
                ARating = 5,
                AImageLink = "http://upload.wikimedia.org/wikipedia/en/4/4b/Big_Hero_6_%28film%29_poster.jpg",
                ATrailerLink = "//www.youtube.com/embed/z3biFxZIJOQ",
                AGenre = "Comedy",
                AWideImage = "https://github.com/tushar23091998/MovieRentalApp-FrontEnd/blob/master/src/app/images/bighero6.jpg?raw=true"
            });
            Assert.IsInstanceOf<BadRequestObjectResult>(tblMovie);

        }


        [Test]
        public async Task GivenAValidMovie_WhenIPostAnInvalidMovie_ThenItReturnsbadRequest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockMovieMapper = new Mock<IMapper>();
            _mockMovieMapper.Setup(mapper => mapper.Map<TblMovie>(It.IsAny<MovieForDetailedDto>()))
                    .Returns(new TblMovie());
            _mockMovieRepository.Setup(repo => repo.AddMovie(It.IsAny<TblMovie>()))
                    .ReturnsAsync((TblMovie movie) => movie);
            _moviesController = new MoviesController(_mockMovieRepository.Object, _mockMovieMapper.Object);
            var tblMovie = await _moviesController.AddMovie(new MovieForDetailedDto
            {
                //AMovieId = 3,
                //ATitle = "Big Hero 6",
                AMovieDescription = "An action comedy adventure about brilliant robotics prodigy Hiro Hamada, who finds himself in the grips of a criminal plot that threatens to destroy the fast-paced, high-tech city of San Fransokyo. With the help of his closest companion-a robot named Baymax-Hiro joins forces with a reluctant team of first-time crime fighters on a mission to save their city.",
                ADuration = "105 min",
                APrice = "10",
                APurchasePrice = "25",
                ARating = 5,
                AImageLink = "http://upload.wikimedia.org/wikipedia/en/4/4b/Big_Hero_6_%28film%29_poster.jpg",
                ATrailerLink = "//www.youtube.com/embed/z3biFxZIJOQ",
                AGenre = "Comedy",
                AWideImage = "https://github.com/tushar23091998/MovieRentalApp-FrontEnd/blob/master/src/app/images/bighero6.jpg?raw=true"
            });
            Assert.IsInstanceOf<BadRequestObjectResult>(tblMovie);

        }

    }
}