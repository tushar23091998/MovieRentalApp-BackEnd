using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using MovieRentalApp.Controllers;
using MovieRentalApp.Dtos;
using MovieRentalApp.Interfaces;
using MovieRentalApp.Models;
using MovieRentalApp_UnitTesting.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp_UnitTesting.ControllerTests
{
    [TestFixture]
    public class AuthControllerTests
    {
        private Mock<IAuthRepository> _mockAuthRepository;
        private Mock<IMapper> _mockAuthMapper;
        private Mock<IConfiguration> _mockConfig;
        private AuthController _authController;

        [Test]
        public async Task GivenAValidUser_WhenIRegisterANewUser_ThenItReturnsOkWithResponse()
        {
            _mockAuthRepository = new Mock<IAuthRepository>();
            _mockAuthMapper = new Mock<IMapper>();
            _mockConfig = new Mock<IConfiguration>();
            UserForRegisterDto expectedUser = new UserForRegisterDto
            {
                Aname = "Luffy",
                AUsername = "luffy",
                AEmail = "luffy@gmail.com",
                Password = "password",
                ADob = new DateTime(2000, 12, 12)
            };
            TblUser user = new TblUser
            {
                Aname = "Luffy",
                AUsername = "luffy",
                AEmail = "luffy@gmail.com",
                ACustomerId = 4,
                ADob = new DateTime(2000, 12, 12)
            };
            UserForDetailedDto userForDetailedDto = new UserForDetailedDto
            {
                Aname="Luffy",
                AUsername = "luffy",
                AEmail = "luffy@gmail.com",
                ACustomerId = 4
            };
            _mockAuthMapper.Setup(mapper => mapper.Map<TblUser>(It.IsAny<UserForRegisterDto>()))
                .Returns(user);
            _mockAuthMapper.Setup(mapper => mapper.Map<UserForDetailedDto>(user))
            .Returns(userForDetailedDto);
            _mockAuthRepository.Setup(repo => repo.Register(It.IsAny<TblUser>(), It.IsAny<string>()))
            .ReturnsAsync((TblUser user, string password) => user);

            _authController = new AuthController(_mockAuthRepository.Object, _mockConfig.Object, _mockAuthMapper.Object);
            var tblUser = await _authController.Register(expectedUser);
            Assert.NotNull(tblUser);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(tblUser);
            var result = ((CreatedAtRouteResult)tblUser).Value;
            Assert.NotNull(result);
            Assert.IsAssignableFrom<UserForDetailedDto>(result);
        }

        [Test]
        public async Task GivenAValidUser_WhenIRegisterANewUserWithExistingName_ThenItReturnsbadRequest()
        {
            _mockAuthRepository = new Mock<IAuthRepository>();
            _mockAuthMapper = new Mock<IMapper>();
            _mockConfig = new Mock<IConfiguration>();
            _mockAuthMapper.Setup(mapper => mapper.Map<TblUser>(It.IsAny<UserForRegisterDto>()))
                    .Returns(new TblUser());
            _mockAuthMapper.Setup(mapper => mapper.Map<UserForDetailedDto>(It.IsAny<TblUser>()))
            .Returns(new UserForDetailedDto());
            _mockAuthRepository.Setup(r => r.UserExists(It.IsAny<string>())).ReturnsAsync(true);
            _authController = new AuthController(_mockAuthRepository.Object, _mockConfig.Object, _mockAuthMapper.Object);
            var tblUser = await _authController.Register(new UserForRegisterDto
            {
                Aname = "John",
                AUsername = "john",
                AEmail = "john@gmail.com",
                Password = "password",
                ADob = new DateTime(2000, 12, 12)
            });
            Assert.IsInstanceOf<BadRequestObjectResult>(tblUser);
        }

        [Test]
        public async Task GivenAValidUser_WhenIRegisterAnInvalidUser_ThenItReturnsbadRequest()
        {
            _mockAuthRepository = new Mock<IAuthRepository>();
            _mockAuthMapper = new Mock<IMapper>();
            _mockConfig = new Mock<IConfiguration>();
            _mockAuthMapper.Setup(mapper => mapper.Map<TblUser>(It.IsAny<UserForRegisterDto>()))
                                .Returns(new TblUser());
            _mockAuthMapper.Setup(mapper => mapper.Map<UserForDetailedDto>(It.IsAny<TblUser>()))
            .Returns(new UserForDetailedDto());
            _mockAuthRepository.Setup(repo => repo.Register(It.IsAny<TblUser>(), It.IsAny<string>()))
                    .ReturnsAsync((TblUser user, string password) => user);
            _authController = new AuthController(_mockAuthRepository.Object, _mockConfig.Object, _mockAuthMapper.Object);
            var tblUser = await _authController.Register(new UserForRegisterDto
            {
                //Aname = "John",
                AUsername = "john",
                //AEmail = "john@gmail.com",
                Password = "password",
                ADob = new DateTime(2000, 12, 12)
            });
            Assert.IsInstanceOf<BadRequestObjectResult>(tblUser);

        }

        [Test]
        public async Task GivenAValidUser_WhenILoginANewUserWithWrongpassword_ThenItReturnsUnauthorized()
        {
            getAuthHelper authHelper = new getAuthHelper();
            _mockAuthRepository = new Mock<IAuthRepository>();
            _mockAuthMapper = new Mock<IMapper>();
            _mockConfig = new Mock<IConfiguration>();
            _mockAuthRepository.Setup(repo => repo.Login(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(authHelper.userExits("john","nopassword"));
            _authController = new AuthController(_mockAuthRepository.Object, _mockConfig.Object, _mockAuthMapper.Object);
            var token = await _authController.Login(new UserForLoginDto
            {
                AUsername= "john",
                Password = "password",
            });
            Assert.IsInstanceOf<UnauthorizedResult>(token);
        }

        [Test]
        public async Task GivenAValidUser_WhenILoginANewUserWithTheRightPassword_ThenItReturnsokResponse()
        {
            getAuthHelper authHelper = new getAuthHelper();
            _mockAuthRepository = new Mock<IAuthRepository>();
            _mockAuthMapper = new Mock<IMapper>();
            _mockConfig = new Mock<IConfiguration>();
            _mockAuthRepository.Setup(repo => repo.Login(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(authHelper.userExits("john", "password"));
            _mockConfig.Setup(config => config.GetSection(It.IsAny<string>()).Value).Returns("super secret key");
            _authController = new AuthController(_mockAuthRepository.Object, _mockConfig.Object, _mockAuthMapper.Object);
            var token = await _authController.Login(new UserForLoginDto
            {
                AUsername = "john",
                Password = "password",
            });
            Assert.IsInstanceOf<OkObjectResult>(token);
        }
    }
}
