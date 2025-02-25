using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended_.Data;

namespace WelcomeExtended_.Helpers
{
    static class UserDataHelper
    {
        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            if (name == null)
            {
                throw new Exception($"The name field cannot be empty");
            }
            else if (password == null)
            {
                throw new Exception("The password field cannot be empty");
            }
            else
            {
                return userData.ValidateUser(name, password);
            }
        }
        public static User GetUser(this UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        }
    }
}
