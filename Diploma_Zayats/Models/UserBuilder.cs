using System;
using NUnit.Framework;
using Diploma_Zayats.Utilities.Configuration;

namespace Diploma_Zayats.Models
{
    public class UserBuilder
    {
        private User user;

        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetUserName(string userName)
        {
            user.Username = userName;

            return this;
        }

        public UserBuilder SetPassword(string password)
        {
            user.Password = password;

            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}

