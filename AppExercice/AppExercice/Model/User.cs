﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExercice.Model
{
    public class User
    {
        private string _userID;

        public User(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            _userID = firstName.ToLower() + lastName.ToLower() + phoneNumber;
            FavouriteStores = new List<Stores>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; }
        public List<Stores> FavouriteStores { get; set; }

    }
}

