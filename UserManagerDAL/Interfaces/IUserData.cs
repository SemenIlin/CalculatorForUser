namespace UserManagerDAL.Interfaces
{
    public interface IUserData<T> where T : class
    {
        T GetUser(string name);

        void AddUser(T user);

        void EditUSer(string login, string password);

        bool DeleteUser(string name);
    }
}
