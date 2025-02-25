using Welcome.Others;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            string name = _viewModel.Names;
            UserRolesEnum role = _viewModel.Role;

            Console.WriteLine("\nWelcome\nUser: {" + name + "}\nRole: {" + role + "}");
        }
        public void DisplayAll()
        {
            string name = _viewModel.Names;
            UserRolesEnum role = _viewModel.Role;

            Console.WriteLine("\nWelcome\nUser: {" + name + "}\nRole: {" + role + "}");
        }
        public void DisplayError1()
        {
            throw new Exception("error 1");
        }

        public void DisplayError2()
        {
            throw new Exception("error 2");
        }
    }
}
