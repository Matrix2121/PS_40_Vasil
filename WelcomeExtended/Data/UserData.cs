using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Others;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WelcomeExtended_.Data
{
    class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData()
        {
            _nextId = 0;
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }
        public void DeleteUser(User user)
        {
            if (_users.Exists(u => u.Equals(user)))
            {
                _users.Remove(user);
            }
        }
        public bool ValidateUser(string name, string password)
        {
            var successLog = new ActionOnLogin(Delegates.LogSuccessfulLogin);
            var unsuccessLog = new ActionOnError(Delegates.LogUnsuccessfulLogin);
            foreach (var user in _users)
            {
                if(user.Names == name)
                {
                    if (user.Names == name && user.Password != password)
                    {
                        successLog(name,false);
                    }
                    else
                    {
                        successLog(name, true);
                        return true;
                    }
                }
            }
            throw new Exception("This user is not found");
        }
        public bool ValidateUsserLambda(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password).FirstOrDefault() != null ? true : false;
        }
        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Names == name && user.Password == password
                      select user.Id;
            return ret != null ? true : false;
        }
        public User GetUser(string name, string password)
        {
            var user = from user1 in _users
                        where user1.Names == name && user1.Password == password
                        select user1;
            return user.FirstOrDefault();
        }
        public void SetAcvite(string name, DateTime date)
        {
            var user = (from user1 in _users
                       where user1.Names == name
                       select user1).FirstOrDefault();
            if (user == null)
            {
                return;
            }
            user.Expires = date;
        }
        public void AssignUserRole(string name, UserRolesEnum role)
        {
            var user = (from user1 in _users
                        where user1.Names == name
                        select user1).FirstOrDefault();
            if (user == null)
            {
                return;
            }
            user.Role = role;
        }
    }
}
