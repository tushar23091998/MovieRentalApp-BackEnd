using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRentalApp.Controllers;
using MovieRentalApp.Dtos;
using MovieRentalApp.Interfaces;
using MovieRentalApp.Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MovieRentalApp_UnitTesting.ControllerTests
{
    [TestFixture]
    public class OrderControllerTests
    {
        private Mock<IMapper> _mockOrderMapper;
        private Mock<IOrderRepository> _mockOrderRepository;

        [SetUp]
        public void Setup()
        {
            _mockOrderMapper = new Mock<IMapper>();
            _mockOrderRepository = new Mock<IOrderRepository>();
        }

        [Test]
        public async Task GivenAValidOrder_WhenIPostANewOrder_ThenItReturnsOkWithResponse()
        {
            TblOrder expectedorder = new TblOrder
            {
                ACustomerId = 3,
                AMovieId = 18,
                ARentalOrNot = false,
                AOrderedDate = DateTime.Now
            };
            //Arrange

            _mockOrderMapper.Setup(mapper => mapper.Map<TblOrder>(It.IsAny<OrderForMappingDto>()))
                .Returns(expectedorder);


            _mockOrderRepository.Setup(repo => repo.AddOrder(It.IsAny<TblOrder>()))
                .ReturnsAsync((TblOrder order) => order);

            var SUT = new OrdersController(_mockOrderRepository.Object, _mockOrderMapper.Object);

            //Act
            var contentResult = await SUT.AddOrder(new OrderForMappingDto
            {
                ACustomerId = 3,
                AMovieId = 18,
                ARentalOrNot = false,
                AOrderedDate = DateTime.Now
            });

            var okResult = contentResult as OkObjectResult;

            //Assert
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.NotNull(contentResult);
            Assert.IsAssignableFrom<OkObjectResult>(contentResult);

            var result = ((OkObjectResult)contentResult).Value;
            Assert.NotNull(result);
            Assert.IsAssignableFrom<TblOrder>(result);
            Assert.AreEqual(result, expectedorder);
        }

        [Test]
        public async Task GivenAValidOrder_WhenIPostANewInvalidOrder_ThenItReturnsBadRequest()
        {
            //Arrange

            _mockOrderMapper.Setup(mapper => mapper.Map<TblOrder>(It.IsAny<OrderForMappingDto>()))
                .Returns(new TblOrder());


            _mockOrderRepository.Setup(repo => repo.AddOrder(It.IsAny<TblOrder>()))
                .ReturnsAsync((TblOrder order) => order);

            var SUT = new OrdersController(_mockOrderRepository.Object, _mockOrderMapper.Object);

            //Act
            var contentResult = await SUT.AddOrder(new OrderForMappingDto
            {
                ACustomerId = 3,
                AMovieId = 18,
                ARentalOrNot = false,
                //AOrderedDate = DateTime.Now
            });

            //Assert
            //Assert.AreEqual(400, contentResult.StatusCode);
            Assert.IsInstanceOf<BadRequestObjectResult>(contentResult);
        }
    }

}
