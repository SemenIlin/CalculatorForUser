using System.IO;
using UserManagerBLL.RecordsJSON;
using Exceptions;
using UserManagerBLL.Users;

namespace UserManager.PL
{
    public class SignInModel
    {
        public SignInModel(string login, string password)
        {
            if(Directory.Exists(login))
            {
                ValidationUser validation = new ValidationUser(login, password, DirectoryForJson<UserSignInDTO>.ReadJson(login + "\\" + login + ".json"));
                validation.CheckExistUser();
                Rank = "User";
            }

            else if(login == "admin" && 
                    password == "admin")
            {
                Rank = "Admin";
            }

            Login = login;
            Password = password;
        }

        public string Rank { get; private set; }
        public string Login { get; set; }
        public string Password { get; set; }

        
    }
}
