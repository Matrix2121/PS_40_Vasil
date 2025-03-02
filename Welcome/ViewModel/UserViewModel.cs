﻿using System.Security.Cryptography;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }
        public string Names
        {
            get { return _user.Names; }
            set { _user.Names = value; }
        }
        public string Password
        {
            get { return _user.Password; }
            set { _user.Password = value; }
        }
        public UserRolesEnum Role
        {
            get { return _user.Role; }
            set { _user.Role = value; }
        }
    }
}
