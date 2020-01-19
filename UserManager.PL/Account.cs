using UserAccount.BLL.Users;
using UserManagerBLL.CalculatorExample.Structures;
using UserManagerBLL.CommandsOfUser;
using UserManagerBLL.Users;
using System.Collections.Generic;
using UserManagerBLL.RecordsJSON;
using System.IO;

namespace UserManager.PL
{
    public class Account
    {
        private UserInterface userInterface;
        private OperationsOfUser<int> operationsInt;
        private OperationsOfUser<bool> operationsBool;
        private OperationsOfUser<char> operationsChar;
        private OperationsOfUser<Word> operationsWord;   

        public UserSignInDTO UserSignInDTO { get; private set; }

        public bool IsLogin { get; private set; }
        public bool IsLoginSuperUser { get; private set; }
        public List<string> Users { get; private set; }

        public void RegistrationUser(RegistrationModel registration)
        {
            UserSignInDTO = new UserSignInDTO
            {
                Rank = "User",
                Login = registration.Login,
                Password = registration.Password,
                OperationBool = new List<OperationsOfUser<bool>>(1),
                OperationChar = new List<OperationsOfUser<char>>(1),
                OperationInt = new List<OperationsOfUser<int>>(1),
                OperationWord = new List<OperationsOfUser<Word>>(1)
            };

            IsLogin = true;
        }        

        public void SignInUser(SignInModel signIn)
        {
            UserSignInDTO = new UserSignInDTO
            {
                Rank = signIn.Rank,
                Login = signIn.Login,
                Password = signIn.Password,
                OperationBool = new List<OperationsOfUser<bool>>(1),
                OperationChar = new List<OperationsOfUser<char>>(1),
                OperationInt = new List<OperationsOfUser<int>>(1),
                OperationWord = new List<OperationsOfUser<Word>>(1)
            };

            if (UserSignInDTO.Rank == "User")
            {
                IsLogin = true;
            }
            else if(UserSignInDTO.Rank == "Admin")
            {
                IsLoginSuperUser = true;
            }
        }

        public void ExitFromAccount()
        {
            var directory = new DirectoryForJson<UserSignInDTO>(UserSignInDTO.Login, UserSignInDTO, false);
            directory.WriteInDerictory();

            if (UserSignInDTO.Rank == "User")
            {
                IsLogin = false;
            }
            else if (UserSignInDTO.Rank == "Admin")
            {
                IsLoginSuperUser = false;
            }
        }

        public void ExitFromAccoutSuperUser()
        {
            IsLoginSuperUser = false;
        }

        public void EditUser(string newPassword)
        {          
            UserSignInDTO.Password = newPassword;
        }

        public int GetResultAdditionInt(int val1, int val2)
        {
            userInterface = new UserInterface(val1, val2);
            operationsInt = userInterface.CreateIntAddition();
            UserSignInDTO.OperationInt.Add(operationsInt);

            return operationsInt.Result;
        }
               
        public int GetResultSubstractionInt(int val1, int val2)
        {
            userInterface = new UserInterface(val1, val2);
            operationsInt = userInterface.CreateIntSubstraction();
            UserSignInDTO.OperationInt.Add(operationsInt);

            return operationsInt.Result;
        }
               
        public int GetResultDivisionInt(int val1, int val2)
        {
            userInterface = new UserInterface(val1, val2);
            operationsInt = userInterface.CreateIntDivision();
            UserSignInDTO.OperationInt.Add(operationsInt);

            return operationsInt.Result;
        }       
               
        public int GetResultMultiplicationInt(int val1, int val2)
        {
            userInterface = new UserInterface(val1, val2);
            operationsInt = userInterface.CreateIntMultiplication();
            UserSignInDTO.OperationInt.Add(operationsInt);

            return operationsInt.Result;
        }

        public bool GetResultAdditionBool(bool isVal1, bool isVal2)
        {
            userInterface = new UserInterface(isVal1, isVal2);
            operationsBool = userInterface.CreateBoolAddition();
            UserSignInDTO.OperationBool.Add(operationsBool);

            return operationsBool.Result;
        }

        public bool GetResultSubstractionBool(bool isVal1, bool isVal2)
        {
            userInterface = new UserInterface(isVal1, isVal2);
            operationsBool = userInterface.CreateBoolSubstraction();
            UserSignInDTO.OperationBool.Add(operationsBool);

            return operationsBool.Result;
        }

        public bool GetResultDivisionBool(bool isVal1, bool isVal2)
        {
            userInterface = new UserInterface(isVal1, isVal2);
            operationsBool = userInterface.CreateBoolDivision();
            UserSignInDTO.OperationBool.Add(operationsBool);

            return operationsBool.Result;
        }

        public bool GetResultMultiplicationBool(bool isVal1, bool isVal2)
        {
            userInterface = new UserInterface(isVal1, isVal2);
            operationsBool = userInterface.CreateBoolMultiplication();
            UserSignInDTO.OperationBool.Add(operationsBool);

            return operationsBool.Result;
        }

        public char GetResultAdditionChar(char symbol1, char symbol2)
        {
            userInterface = new UserInterface(symbol1, symbol2);
            operationsChar = userInterface.CreateCharAddition();
            UserSignInDTO.OperationChar.Add(operationsChar);

            return operationsChar.Result;
        }

        public char GetResultSubstractionChar(char symbol1, char symbol2)
        {
            userInterface = new UserInterface(symbol1, symbol2);
            operationsChar = userInterface.CreateCharSubstraction();
            UserSignInDTO.OperationChar.Add(operationsChar);

            return operationsChar.Result;
        }

        public char GetResultDivisionChar(char symbol1, char symbol2)
        {
            userInterface = new UserInterface(symbol1, symbol2);
            operationsChar = userInterface.CreateCharDivision();
            UserSignInDTO.OperationChar.Add(operationsChar);

            return operationsChar.Result;
        }

        public char GetResultMultiplicationChar(char symbol1, char symbol2)
        {
            userInterface = new UserInterface(symbol1, symbol2);
            operationsChar = userInterface.CreateCharMultiplication();
            UserSignInDTO.OperationChar.Add(operationsChar);

            return operationsChar.Result;
        }

        public string GetResultAdditionString(string word1, string word2)
        {
            userInterface = new UserInterface(new Word{Words = word1 }, new Word{ Words = word2 });
            operationsWord = userInterface.CreateWordAddition();
            UserSignInDTO.OperationWord.Add(operationsWord);

            return operationsWord.Result.Words;
        }

        public string GetResultSubstractionString(string word1, string word2)
        {
            userInterface = new UserInterface(new Word { Words = word1 }, new Word { Words = word2 });
            operationsWord = userInterface.CreateWordSubstraction();
            UserSignInDTO.OperationWord.Add(userInterface.CreateWordSubstraction());
            return operationsWord.Result.Words;
        }

        public string GetResultDivisionString(string word1, string word2)
        {
            userInterface = new UserInterface(new Word { Words = word1 },new Word { Words = word2 });
            operationsWord = userInterface.CreateWordDivision();
            UserSignInDTO.OperationWord.Add(operationsWord);

            return operationsWord.Result.Words;
        }

        public string GetResultMultiplicationString(string word1, string word2)
        {
            userInterface = new UserInterface(new Word {Words = word1 }, new Word { Words = word2 });
            operationsWord = userInterface.CreateWordMultiplication();
            UserSignInDTO.OperationWord.Add(operationsWord);

            return operationsWord.Result.Words;
        } 

        public UserSignInDTO GetUser(int id) 
        {
            return DirectoryForJson<UserSignInDTO>.ReadJson(Users[id - 1] + "\\" + Users[id - 1] + ".json");
        }

        public void GetListUsers()
        {
            string path = Directory.GetCurrentDirectory();
            string[] users = Directory.GetDirectories(path);

            Users = new List<string>();

            foreach (var user in users)
            {
                Users.Add(new DirectoryInfo(user).Name);
            }
        }
    }
}
