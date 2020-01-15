using System.Linq;
using UserManagerDAL.Interfaces;
using UserManagerDAL.Models;
using UserManagerDAL.Storage;

namespace UserManagerDAL.Repositories
{
    public class UserRepository : IUserData<User>
    {
        private readonly Storages storages;

        public UserRepository()
        {
            storages = Storages.GetStorages();
        }

        public void AddUser(User user)
        {
            storages.Users.Add(user);
        }

        public bool DeleteUser(string login)
        {
            if (login != System.String.Empty)
            {
                storages.Users.Remove(storages.Users.FirstOrDefault(u => u.Login == login));

                return true;
            }
            else 
            {
                return false;            
            }
        }

        public void EditUSer(string login, string password)
        {
            if (login != System.String.Empty)
            {
                storages.Users.FirstOrDefault(u => u.Login == login).Password = password;
            } 
        }

        public User GetUser(string name)
        {
            return storages.Users.FirstOrDefault(u => u.Login == name);           
        }
    }
}
