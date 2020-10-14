using MovieRentalApp.Dtos;
using MovieRentalApp.Models;
using MovieRentalApp_UnitTesting.ControllerTests;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRentalApp_UnitTesting.Helpers
{
    public class getAuthHelper
    {
        public TblUser userExits(string username, string password)
        {
            getUsersHelper getUsersHelper = new getUsersHelper();
            var users = getUserFromList();
            foreach (UserForLoginDto loginUser in users)
            {
                if (loginUser.AUsername == username)
                {
                    if(loginUser.Password == password)
                    {
                        return getUsersHelper.userByUserNameExistsThroughusername(username);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }
        public List<UserForLoginDto> getUserFromList()
        {
            var users = new List<UserForLoginDto>();
            users.Add(new UserForLoginDto()
            {
                AUsername = "john",
                Password = "password"
            });
            users.Add(new UserForLoginDto()
            {
                AUsername = "karen",
                Password = "password"
            });
            users.Add(new UserForLoginDto()
            {
                AUsername = "brian",
                Password = "password"
            });

            return users;
        }
    }
}
