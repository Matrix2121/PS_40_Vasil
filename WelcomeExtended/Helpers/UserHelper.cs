using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace WelcomeExtended_.Helpers
{
    static class UserHelper
    {
        public static string ToString(this User user)
        {
            return("Name: " + user.Names + "\nSchool Number: " + user.SchoolNum
                + "\nEmail: " + user.Email + "\nRole: " + user.Role);
        }
    }
}
