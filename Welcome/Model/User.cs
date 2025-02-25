using Welcome.Others;
namespace Welcome.Model
{
    public class User
    {
        private string _names;
        private int _id;
        private string _password;
        private UserRolesEnum _role;
        private DateTime _expires;

        public User(string names, string schoolNum, string password, UserRolesEnum role)
        {
            _names = names;

            string tempPass = password;
            int lenght = tempPass.Length;
            char[] charArr = new char[lenght * 2 + 1];

            for (int i = 0; i < lenght; i++)
            {
                charArr[i * 2 + 1] = tempPass[i];
                charArr[i * 2] = '$';
            }

            charArr[lenght * 2] = '$';

            string cryptedPass = new(charArr);
            _password = cryptedPass;

            _role = role;
        }

        public User(string names, string password, UserRolesEnum role)
        {
            _names = names;

            string tempPass = password;
            int lenght = tempPass.Length;
            char[] charArr = new char[lenght * 2 + 1];

            for (int i = 0; i < lenght; i++)
            {
                charArr[i * 2 + 1] = tempPass[i];
                charArr[i * 2] = '$';
            }

            charArr[lenght * 2] = '$';

            string cryptedPass = new(charArr);
            _password = cryptedPass;

            _role = role;
        }

        public User()
        {

        }
        public string Names { 
            get { return _names; } 
            set { _names = value; } 
        }
        public string Password
        {
            get
            { 
                string cryptedPass = _password;
                int lenght = (cryptedPass.Length - 1) / 2;
                char[] passCharArr = new char[lenght];

                for (int i = 0; i < lenght; i++)
                {
                    passCharArr[i] = cryptedPass[i * 2 + 1];
                }

                string decryptedPass = new(passCharArr);
                return decryptedPass;

            }

            set 
            {
                string tempPass = value;
                int lenght = tempPass.Length;
                char[] charArr = new char[lenght * 2 + 1];

                for (int i = 0; i < lenght; i++)
                {
                    charArr[i * 2 + 1] = tempPass[i];
                    charArr[i * 2] = '$';
                }

                charArr[lenght * 2] = '$';

                string cryptedPass = new(charArr);
                _password = cryptedPass;
            }
        }
        public UserRolesEnum Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
