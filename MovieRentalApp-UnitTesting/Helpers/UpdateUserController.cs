using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Dtos;
using MovieRentalApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp_UnitTesting.Helpers
{
    public class UpdateUserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUpdateUser _updateUser;

        public UpdateUserController(IUserRepository repo, IMapper mapper, IUpdateUser updateUser)
        {
            _repo = repo;
            _mapper = mapper;
            _updateUser = updateUser;
        }

        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
            if (_updateUser.updateOrNot(false))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id);

            _mapper.Map(userForUpdateDto, userFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }
    }
}
