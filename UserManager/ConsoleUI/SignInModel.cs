using System;
using System.IO;
using UserManagerBLL.RecordsJSON;
using UserManagerBLL.UserDataValidation;
using UserManagerBLL.Users;

namespace UserManager.ConsoleUI
{
    public class SignInModel
    {
        public SignInModel()
        {
            SetLogin();
            SetPassword();            

            if(Directory.Exists(Login))
            {
                ValidationUser validation = new ValidationUser(Login, Password, DirectoryForJson<UserSignInDTO>.ReadJson(Login + "\\" + Login + ".json"));
                validation.CheckExistUser();
                Rank = "User";
            }

            else if(Login == "admin" && 
                    Password == "admin")
            {
                Rank = "Admin";
            }
        }

        public string Rank { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        private void SetLogin()
        {
            Console.WriteLine("Введите логин:");
            Login = Console.ReadLine();
        }

        private void SetPassword()
        {
            Console.WriteLine("Введите пароль:");
            Password = Console.ReadLine();
        }
    }
}
