using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRentalApp_UnitTesting.ControllerTests
{
    public class getUsersHelper
    {
        public TblUser userById(int id)
        {
            var users = getUserFromList();
            foreach (TblUser tblUser in users)
            {
                if (tblUser.ACustomerId == id)
                {
                    return tblUser;
                }
            }
            return null;
        }
        public TblUser userByUserNameExists(TblUser tUser)
        {
            var users = getUserFromList();
            foreach (TblUser tblUser in users)
            {
                if (tblUser.AUsername == tUser.AUsername)
                {
                    return null;
                }
            }
            return tUser;
        }
        public List<TblUser> getUserFromList()
        {
            var users = new List<TblUser>();
            users.Add(new TblUser()
            {
                ACustomerId = 2,
                Aname = "John",
                AUsername = "john",
                AEmail = "john@gmail.com",
            });
            users.Add(new TblUser()
            {
                ACustomerId = 1,
                Aname = "Karen",
                AUsername = "karen",
                AEmail = "karen@gmail.com",
            });
            users.Add(new TblUser()
            {
                ACustomerId = 3,
                Aname = "Brian",
                AUsername = "brian",
                AEmail = "brian@gmail.com",
            });

            return users;
        }
    }
}
