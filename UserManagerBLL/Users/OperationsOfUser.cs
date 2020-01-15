
namespace UserAccount.BLL.Users
{
    public class OperationsOfUser<T> where T: struct
    {
        public T Value1 { get; set; }
        public T Value2 { get; set; }
        public T Result { get; set; }
    }
}
