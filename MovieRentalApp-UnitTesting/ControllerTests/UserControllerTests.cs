﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRentalApp.Controllers;
using MovieRentalApp.Dtos;
using MovieRentalApp.Helpers;
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
    public class UserControllerTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IMapper> _mockUserMapper;
        private Mock<IUpdateUser> _mockUpdateUser;
        private UsersController _usersController;
        private UpdateUserController _updateUserController;

        [Test]
        public async Task CallGetRequest_WhenCalled_ReturnsAllUsers()
        {
            getUsersHelper getUsersHelper = new getUsersHelper();
            List<TblUser> userList = getUsersHelper.getUserFromList();
            List<UserForListDto> userForListDtos = new List<UserForListDto>(3);
            for (int i = 0; i < userList.Count; i++)
            {
                UserForListDto userForListDto = new UserForListDto();
                userForListDto.Aname = userList[i].Aname;
                userForListDto.ACustomerId = userList[i].ACustomerId;
                userForListDto.AUsername = userList[i].AUsername;
                userForListDto.AEmail = userList[i].AEmail;
                userForListDtos.Add(userForListDto);
            }
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUserMapper = new Mock<IMapper>();
            _mockUserMapper.Setup(mapper => mapper.Map<IEnumerable<UserForListDto>>(It.IsAny<TblUser[]>())).Returns(userForListDtos);
            _mockUserRepository.Setup(repo => repo.GetUsers(new UserParams { }))
            .ReturnsAsync(getUsersHelper.getUserFromList());
            _usersController = new UsersController(_mockUserRepository.Object, _mockUserMapper.Object);
            var users = await _usersController.Getusers(new UserParams { });
            var okResult = users as OkObjectResult;
            var result = ((OkObjectResult)users).Value;
            Assert.AreEqual(result, userForListDtos);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.NotNull(users);
            Assert.IsAssignableFrom<OkObjectResult>(users);
        }

        [Test]
        public async Task GetUser_WhenCalledWithNonExistentId_ReturnsBadRequest()
        {
            getUsersHelper getUsersHelper = new getUsersHelper();
            List<TblUser> userList = getUsersHelper.getUserFromList();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUserMapper = new Mock<IMapper>();
            _mockUserMapper.Setup(mapper => mapper.Map<UserForDetailedDto>(It.IsAny<TblUser>())).Returns(new UserForDetailedDto());
            _mockUserRepository.Setup(repo => repo.GetUser(15))
                    .ReturnsAsync(getUsersHelper.userById(15));
            _usersController = new UsersController(_mockUserRepository.Object, _mockUserMapper.Object);
            var tblUser = await _usersController.GetUser(15);
            Assert.IsInstanceOf<BadRequestObjectResult>(tblUser);
        }

        [Test]
        public async Task CallGetRequest_WhenCalledWithId_ReturnsTheUserWithTheSameId()
        {
            getUsersHelper getUsersHelper = new getUsersHelper();
            List<TblUser> userList = getUsersHelper.getUserFromList();
            var user = getUsersHelper.userById(3);
            UserForDetailedDto userForDetailedDto = new UserForDetailedDto();
            userForDetailedDto.Aname = user.Aname;
            userForDetailedDto.ACustomerId = user.ACustomerId;
            userForDetailedDto.AUsername = user.AUsername;
            userForDetailedDto.AEmail = user.AEmail;
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUserMapper = new Mock<IMapper>();
            //_mockUserMapper.Setup(mapper => mapper.Map<TblUser>(It.IsAny<UserForDetailedDto>()))
            //    .Returns(getUsersHelper.userById(3));
            _mockUserMapper.Setup(mapper => mapper.Map<UserForDetailedDto>(It.IsAny<TblUser>())).Returns(userForDetailedDto);
            _mockUserRepository.Setup(repo => repo.GetUser(It.IsAny<int>()))
                    .ReturnsAsync(getUsersHelper.userById(3));
            _usersController = new UsersController(_mockUserRepository.Object, _mockUserMapper.Object);
            var tblUser = await _usersController.GetUser(3);
            var okResult = tblUser as OkObjectResult;
            //Assert.AreEqual(200, okResult.StatusCode);
            Assert.NotNull(tblUser);
            Assert.IsAssignableFrom<OkObjectResult>(tblUser);
            var result = ((OkObjectResult)tblUser).Value;
            Assert.AreEqual(result, userForDetailedDto);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<UserForDetailedDto>(result);
        }


        [Test]
        public async Task CallUpdateUser_WhenCalledWithId_ReturnsNoContentwithsavedChanges()
        {
            getUsersHelper getUsersHelper = new getUsersHelper();
            List<TblUser> userList = getUsersHelper.getUserFromList();
            var user = getUsersHelper.userById(3);
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUserMapper = new Mock<IMapper>();
            _mockUpdateUser = new Mock<IUpdateUser>();
            UserForUpdateDto userForUpdateDto = new UserForUpdateDto
            {
                AAddress = "some street",
                Aname = "Johnny",
                APhone = "9876543211"
            };
            //_mockUserMapper.Setup(mapper => mapper.Map<TblUser>(It.IsAny<UserForDetailedDto>()))
            //    .Returns(getUsersHelper.userById(3));
            _mockUpdateUser.Setup(update => update.updateOrNot(It.IsAny<bool>())).Returns(false);
            _mockUserMapper.Setup(mapper => mapper.Map<UserForUpdateDto>(It.IsAny<TblUser>())).Returns(userForUpdateDto);
            _mockUserRepository.Setup(repo => repo.GetUser(It.IsAny<int>()))
                    .ReturnsAsync(getUsersHelper.userById(3));
            _mockUserRepository.Setup(repo => repo.SaveAll()).ReturnsAsync(true);
            _updateUserController = new UpdateUserController(_mockUserRepository.Object, _mockUserMapper.Object, _mockUpdateUser.Object);
            var tblUser = await _updateUserController.UpdateUser(3, userForUpdateDto);
            var okResult = tblUser as OkObjectResult;
            //Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsAssignableFrom<NoContentResult>(tblUser);
        }

        [Test]
        public async Task CallUpdateUser_WhenCalledWithUnauthorizedId_ReturnsUnauthorized()
        {
            getUsersHelper getUsersHelper = new getUsersHelper();
            List<TblUser> userList = getUsersHelper.getUserFromList();
            var user = getUsersHelper.userById(3);
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUserMapper = new Mock<IMapper>();
            _mockUpdateUser = new Mock<IUpdateUser>();
            UserForUpdateDto userForUpdateDto = new UserForUpdateDto
            {
                AAddress = "some street",
                Aname = "Johnny",
                APhone = "9876543211"
            };
            //_mockUserMapper.Setup(mapper => mapper.Map<TblUser>(It.IsAny<UserForDetailedDto>()))
            //    .Returns(getUsersHelper.userById(3));
            _mockUpdateUser.Setup(update => update.updateOrNot(It.IsAny<bool>())).Returns(true);
            _mockUserMapper.Setup(mapper => mapper.Map<UserForUpdateDto>(It.IsAny<TblUser>())).Returns(userForUpdateDto);
            _mockUserRepository.Setup(repo => repo.GetUser(It.IsAny<int>()))
                    .ReturnsAsync(getUsersHelper.userById(3));
            _mockUserRepository.Setup(repo => repo.SaveAll()).ReturnsAsync(true);
            _updateUserController = new UpdateUserController(_mockUserRepository.Object, _mockUserMapper.Object, _mockUpdateUser.Object);
            var tblUser =await _updateUserController.UpdateUser(3, userForUpdateDto);
            //Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsAssignableFrom<UnauthorizedResult>(tblUser);
        }
    }
}
