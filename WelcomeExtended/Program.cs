using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Others;
using WelcomeExtended_.Data;
using WelcomeExtended_.Helpers;
namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserData userData = new UserData();

                User studentUser = new User()
                {
                    Names = "Student",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                userData.AddUser(studentUser);

                User studentUser2 = new User()
                {
                    Names = "Student2",
                    Password = "1234",
                    Role = UserRolesEnum.STUDENT
                };
                userData.AddUser(studentUser2);

                User teacherUser = new User()
                {
                    Names = "Teacher",
                    Password = "1234",
                    Role = UserRolesEnum.PROFESSOR
                };
                userData.AddUser(teacherUser);

                User adminUser = new User()
                {
                    Names = "Admin",
                    Password = "12345",
                    Role = UserRolesEnum.ADMIN
                };
                userData.AddUser(adminUser);

                string loginName;
                string loginPass;
                User login = new User();

                Console.WriteLine("Enter name: ");
                loginName = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                loginPass = Console.ReadLine();

                userData.ValidateUser(loginName, loginPass);
                login = userData.GetUser(loginName, loginPass);

                Console.WriteLine(UserHelper.ToString(login)); 

            }
            catch (Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
        }
    }
}
