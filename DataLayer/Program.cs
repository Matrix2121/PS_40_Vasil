using DataLayer.Database;
using DataLayer.Model;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new DatabaseContext())
        {
            context.Database.EnsureCreated();

            //context.Add<DatabaseUser>(new DatabaseUser()
            //{
            //    Names = "user",
            //    Password = "passsword",
            //    Expires = DateTime.Now,
            //    Role = UserRolesEnum.STUDENT
            //});
            //context.SaveChanges();

            //Cheking if the user exists in the DB
            //User login = new User();
            //string loginName;
            //string loginPass;

            //while (true)
            //{
            //    Console.WriteLine("Enter name: ");
            //    loginName = Console.ReadLine();

            //    if (loginName.Equals("exit"))
            //    {
            //        break;
            //    }

            //    Console.WriteLine("Enter password: ");
            //    loginPass = Console.ReadLine();

            //    if (loginPass.Equals("exit"))
            //    {
            //        break;
            //    }

            //    var user = (from user1 in users
            //                where user1.Names == loginName && user1.Password == loginPass
            //                select user1).FirstOrDefault();

            //    if (user != null)
            //    {
            //        Console.WriteLine("User exists");
            //    }
            //    else
            //    {
            //        Console.WriteLine("User doesn't exist");
            //    }

            //    if (loginName.Equals("exit") || loginPass.Equals("exit"))
            //    {
            //        break;
            //    }
            //}

            var newUser = new DatabaseUser();
            string name;
            string pass;
            string input;

            while (true)
            {
                bool exitFlag = false;
                Console.WriteLine("Load all/Add/Remove/Exit(1/2/3/0): ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var users = context.Users.ToList();

                        if (users.Count == 0)
                        {
                            Console.WriteLine("No users found in the database.");
                        }
                        else
                        {
                            foreach (var user in users)
                            {
                                Console.WriteLine($"ID: {user.Id}, Name: {user.Names}, Role: {user.Role}");
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();
                        newUser.Names = name;

                        Console.WriteLine("Enter password: ");
                        pass = Console.ReadLine();
                        newUser.Password = pass;

                        context.Users.Add(newUser);
                        context.SaveChanges();
                        break;
                    case "3":
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();

                        var userToRemove = context.Users.FirstOrDefault(u => u.Names == name);

                        if(userToRemove != null)
                        {
                            context.Users.Remove(userToRemove);
                            context.SaveChanges();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No user with this name has been found!");
                            break;
                        }
                    case "0":
                        exitFlag = true;
                        break;
                }

                foreach(var user in context.Users)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.Names}, Role: {user.Role}");
                }

                if (exitFlag)
                {
                    break;
                }
            }
            context.SaveChanges();


            foreach (var log in context.Logs)
            {
                Console.WriteLine(log.TimeStamp + ": ID: " + log.Id + " Message: " + log.Message);
            }
            
        }
    }
}