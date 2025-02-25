using DataLayer.Database;
using DataLayer.Model;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Welcome.Model;
using Welcome.Others;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new DatabaseContext())
        {
            context.Database.EnsureCreated();
            context.Add<DatabaseUser>(new DatabaseUser()
            {
                Names = "user",
                Password = "passsword",
                Expires = DateTime.Now,
                Role = UserRolesEnum.STUDENT
            });
            context.SaveChanges();
            var users = context.Users.ToList();

            User login = new User();
            string loginName;
            string loginPass;

            while (true)
            {
                Console.WriteLine("Enter name: ");
                loginName = Console.ReadLine();

                if (loginName.Equals("exit"))
                {
                    break;
                }

                Console.WriteLine("Enter password: ");
                loginPass = Console.ReadLine();

                if (loginPass.Equals("exit"))
                {
                    break;
                }

                var user = (from user1 in users
                           where user1.Names == loginName && user1.Password == loginPass
                           select user1).FirstOrDefault();

                if (user != null)
                {
                    Console.WriteLine("User exists");
                }
                else
                {
                    Console.WriteLine("User doesn't exist");
                }

                if (loginName.Equals("exit") || loginPass.Equals("exit"))
                {
                    break;
                }
            }
        }
    }
}