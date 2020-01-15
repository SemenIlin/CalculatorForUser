using UserManagerBLL.CommandsOfUsers;
using UserManagerBLL.Users;
using UserManagerDAL.Repositories;

namespace UserManagerBLL.CommandsOfUser
{
    class UserCommand : IUserCommands
    {
        private readonly UserRepository repository;

        public UserCommand()
        {
            repository = new UserRepository();
        }

        public void AddUser(UserRegistrationDTO user)
        {
            repository.AddUser(new UserManagerDAL.Models.User {Login = user.Login, Password = user.Password, Rank = user.Rank });
        }

        public bool DeleteUser(UserSignInDTO user)
        {
            return repository.DeleteUser(user.Login);
        }

        public void EditUSer(string login, string password)
        {
            repository.EditUSer(login, password);
        }

        public UserSignInDTO GetUser(string name) 
        {
            var user = repository.GetUser(name);
            return new UserSignInDTO { Login = user.Login, Password = user.Password };
        }
    }
}
