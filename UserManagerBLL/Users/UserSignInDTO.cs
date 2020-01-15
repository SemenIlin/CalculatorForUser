using System.Collections.Generic;
using UserAccount.BLL.Users;
using UserManagerBLL.CalculatorExample.Structures;

namespace UserManagerBLL.Users
{
    public class UserSignInDTO
    {
        public string Rank { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<OperationsOfUser<int>> OperationInt { get; set; }
        public List<OperationsOfUser<char>> OperationChar { get; set; }
        public List<OperationsOfUser<bool>> OperationBool { get; set; }
        public List<OperationsOfUser<Word>> OperationWord { get; set; }
    }
}
