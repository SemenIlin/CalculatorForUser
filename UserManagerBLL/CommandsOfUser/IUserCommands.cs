using UserManagerBLL.Users;

namespace UserManagerBLL.CommandsOfUsers
{
    public interface IUserCommands
    {
        UserSignInDTO GetUser(string name);

        void AddUser(UserRegistrationDTO user);

        void EditUSer(string login, string password);

        bool DeleteUser(UserSignInDTO user);
    }
}
