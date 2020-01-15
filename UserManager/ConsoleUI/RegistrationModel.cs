using System;
using UserManagerBLL.RecordsJSON;
using UserManagerBLL.UserDataValidation;
using UserManagerBLL.Users;

namespace UserManager.ConsoleUI
{
    public class RegistrationModel
    {
        public RegistrationModel()
        {
            SetLogin();
            SetPassword();
            SetConfirmPassword();

            ValidationUser validation = new ValidationUser(Login, Password, ConfirmPassword);
            validation.CheckUserLogin();
            validation.CheckUserPassword();
        }

        public string Login { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }

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

        private void SetConfirmPassword() 
        {
            Console.WriteLine("Повторите пароль:");
            ConfirmPassword = Console.ReadLine();
        }       
    }
}
