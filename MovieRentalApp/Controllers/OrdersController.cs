using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Dtos;
using MovieRentalApp.Interfaces;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        public OrdersController(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> AddOrder(OrderForMappingDto orderForMappingDto)
        {
            if (!ModelState.IsValid || orderForMappingDto.AMovieId == null || orderForMappingDto.ACustomerId == null || orderForMappingDto.AOrderedDate == null
                || (orderForMappingDto.ARentalOrNot == true && orderForMappingDto.ADueDate == null) )
            {
                return BadRequest("Should not be null and model state should be valid");
            }
            var orderToCreate = _mapper.Map<TblOrder>(orderForMappingDto);
            var createdOrder = await _repo.AddOrder(orderToCreate);

            return Ok(createdOrder);
        }

    }
}
