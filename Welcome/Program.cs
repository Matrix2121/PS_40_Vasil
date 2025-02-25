using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using Welcome.Others;
namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new("Vasil Stoykov", "121222094", "pass", UserRolesEnum.STUDENT);
            UserViewModel userViewModel = new(user);
            UserView userView = new(userViewModel);

            userView.Display();

            userView.DisplayAll();

            Console.ReadKey();
        }
    }
}
