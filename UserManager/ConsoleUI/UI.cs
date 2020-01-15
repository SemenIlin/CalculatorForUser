using System;
using UserAccount.BLL.Users;
using UserManagerBLL.CalculatorExample.Structures;
using UserManagerBLL.CommandsOfUser;
using UserManagerBLL.UserDataValidation;
using UserManagerBLL.Users;
using System.Collections.Generic;
using UserManagerBLL.RecordsJSON;
using System.IO;

namespace UserManager.ConsoleUI
{
    public class UI
    {
        private RegistrationModel registration;
        private SignInModel signIn;

        private UserInterface userInterface;
        private OperationsOfUser<int> operationsInt;
        private OperationsOfUser<bool> operationsBool;
        private OperationsOfUser<char> operationsChar;
        private OperationsOfUser<Word> operationsWord;

        private string[] userName;

        private int command;
        private int valueType;

        private int val1;
        private int val2;

        private bool isVal1;
        private bool isVal2;

        private char symbol1;
        private char symbol2;

        private Word word1;
        private Word word2;

        private string newPassword;
        private string confirmNewPassword;

        public UserSignInDTO UserSignInDTO { get; private set; }

        public bool IsLogin { get; private set; }
        public bool IsLoginSuperUser { get; private set; }

        public void RegistrationUser()
        {
            registration = new RegistrationModel();

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

        public void SignInUser()
        {
            signIn = new SignInModel();
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

        public void EditUser()
        {
            InputNewPassword();
            ConfirmNewPassword();

            ValidationUser validation = new ValidationUser(newPassword, confirmNewPassword);
            validation.CheckUserPassword();

            UserSignInDTO.Password = newPassword;
        }

        public void SetDataAndGetResult()
        {
            SetCommand();
            SetValueType();

            switch(command)
            {
                case 1:
                    switch (valueType)
                    {
                        case 1:
                            InputInt();

                            userInterface = new UserInterface(val1, val2);
                            operationsInt = userInterface.CreateIntAddition();                            
                            UserSignInDTO.OperationInt.Add(operationsInt);

                            Console.WriteLine(operationsInt.Result);
                            Console.ReadLine();
                            break;

                        case 2:
                            InputBool();

                            userInterface = new UserInterface(isVal1, isVal2);
                            operationsBool = userInterface.CreateBoolAddition();
                            UserSignInDTO.OperationBool.Add(operationsBool);
                                
                            Console.WriteLine(operationsBool.Result);
                            Console.ReadLine();
                            break;

                        case 3:
                            InputChar();

                            userInterface = new UserInterface(symbol1, symbol2);
                            operationsChar = userInterface.CreateCharAddition();
                            UserSignInDTO.OperationChar.Add(operationsChar);

                            Console.WriteLine(operationsChar.Result);
                            Console.ReadLine();
                            break;

                        case 4:
                            InputString();

                            userInterface = new UserInterface(word1, word2);
                            operationsWord = userInterface.CreateWordAddition();
                            UserSignInDTO.OperationWord.Add(operationsWord);

                            Console.WriteLine(operationsWord.Result.Words);
                            Console.ReadLine();
                            break;
                    }
                    break;

                case 2:
                    switch (valueType)
                    {
                        case 1:
                            InputInt();

                            userInterface = new UserInterface(val1, val2);
                            operationsInt = userInterface.CreateIntSubstraction();
                            UserSignInDTO.OperationInt.Add(operationsInt);

                            Console.WriteLine(operationsInt.Result);
                            Console.ReadLine();
                            break;

                        case 2:
                            InputBool();

                            userInterface = new UserInterface(isVal1, isVal2);
                            operationsBool = userInterface.CreateBoolSubstraction();
                            UserSignInDTO.OperationBool.Add(operationsBool);

                            Console.WriteLine(operationsBool.Result);
                            Console.ReadLine();
                            break;

                        case 3:
                            InputChar();

                            userInterface = new UserInterface(symbol1, symbol2);
                            operationsChar = userInterface.CreateCharSubstraction();
                            UserSignInDTO.OperationChar.Add(operationsChar);

                            Console.WriteLine(operationsChar.Result);
                            Console.ReadLine();
                            break;

                        case 4:
                            InputString();

                            userInterface = new UserInterface(word1, word2);
                            operationsWord = userInterface.CreateWordSubstraction();
                            UserSignInDTO.OperationWord.Add(userInterface.CreateWordSubstraction());

                            Console.WriteLine(operationsWord.Result.Words);
                            Console.ReadLine();
                            break;
                    }
                    break;

                case 3:
                    switch (valueType)
                    {
                        case 1:
                            InputInt();

                            userInterface = new UserInterface(val1, val2);
                            operationsInt = userInterface.CreateIntMultiplication();
                            UserSignInDTO.OperationInt.Add(operationsInt);

                            Console.WriteLine(operationsInt.Result);
                            Console.ReadLine();
                            break;

                        case 2:
                            InputBool();

                            userInterface = new UserInterface(isVal1, isVal2);
                            operationsBool = userInterface.CreateBoolMultiplication();
                            UserSignInDTO.OperationBool.Add(operationsBool);

                            Console.WriteLine(operationsBool.Result);
                            Console.ReadLine();
                            break;

                        case 3:
                            InputChar();

                            userInterface = new UserInterface(symbol1, symbol2);
                            operationsChar = userInterface.CreateCharMultiplication();
                            UserSignInDTO.OperationChar.Add(operationsChar);

                            Console.WriteLine(operationsChar.Result);
                            Console.ReadLine();
                            break;

                        case 4:
                            InputString();

                            userInterface = new UserInterface(word1, word2);
                            operationsWord = userInterface.CreateWordMultiplication();
                            UserSignInDTO.OperationWord.Add(operationsWord);

                            Console.WriteLine(operationsWord.Result.Words);
                            Console.ReadLine();
                            break;
                    }

                    break;

                case 4:
                    switch (valueType)
                    {
                        case 1:
                            InputInt();

                            userInterface = new UserInterface(val1, val2);
                            operationsInt = userInterface.CreateIntDivision();
                            UserSignInDTO.OperationInt.Add(operationsInt);

                            Console.WriteLine(operationsInt.Result);
                            Console.ReadLine();
                            break;

                        case 2:
                            InputBool();

                            userInterface = new UserInterface(isVal1, isVal2);
                            operationsBool = userInterface.CreateBoolDivision();
                            UserSignInDTO.OperationBool.Add(operationsBool);

                            Console.WriteLine(operationsBool.Result);
                            Console.ReadLine();
                            break;

                        case 3:
                            InputChar();

                            userInterface = new UserInterface(symbol1, symbol2);
                            operationsChar = userInterface.CreateCharDivision();
                            UserSignInDTO.OperationChar.Add(operationsChar);

                            Console.WriteLine(operationsChar.Result);
                            Console.ReadLine();
                            break;

                        case 4:
                            InputString();

                            userInterface = new UserInterface(word1, word2);
                            operationsWord = userInterface.CreateWordDivision();
                            UserSignInDTO.OperationWord.Add(operationsWord);

                            Console.WriteLine(operationsWord.Result.Words);
                            Console.ReadLine();
                            break;
                    }
                    break;
            }            
        }       

        public void GetUser() 
        {
            GetListUsers();
            if(userName.Length < 1)
            {
                Console.WriteLine("Нету пользователей.");
                return;
            }
            
            Console.WriteLine("Введитете номер пользователя.");
            if (int.TryParse(Console.ReadLine(), out int choise))
            {
                if(choise > userName.Length ||
                   choise <= 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            var user = DirectoryForJson<UserSignInDTO>.ReadJson(userName[choise - 1] + "\\" + userName[choise - 1] + ".json");

            GetViewUser(user);
        }

        public void ExitFromAccoutSuperUser()
        {
            IsLoginSuperUser = false;
        }

        private void GetListUsers()
        {
            Console.WriteLine("Пользователи:");

            string path = Directory.GetCurrentDirectory();
            string[] users = Directory.GetDirectories(path);

            userName = new string[users.Length];
            int counter = 0;

            foreach (var user in users)
            {
                userName[counter] = new DirectoryInfo(user).Name;
                Console.WriteLine($"{counter + 1}. {userName[counter]}.");
                ++counter;
            }

        }

        private void SetCommand()
        {
            Console.WriteLine("Выберите команду:");
            Console.WriteLine("1. Сложение.\n" +
                              "2. Вычитание.\n" +
                              "3. Умножение. \n" +
                              "4. Деление.");

            int.TryParse(Console.ReadLine(), out command);
            if ((command < 1) || (command > 4))
            {
                throw new ValidationException("Неизвестная команда", "");
            }
        }

        private void SetValueType()
        {
            Console.WriteLine("Выберите тип:");
            Console.WriteLine("1. Int. \n" +
                              "2. Bolean. \n" +
                              "3. Char.\n" +
                              "4. String. ");

            int.TryParse(Console.ReadLine(), out valueType);

            if ((valueType < 1) || (valueType > 4))
            {
                throw new ValidationException("Неизвестная команда", "");
            }
        }

        private void InputInt()
        {
            Console.WriteLine("Введите два целых числа.");
            Console.WriteLine("Первое число");
            int.TryParse(Console.ReadLine(), out val1);
            Console.WriteLine("Второе число");
            int.TryParse(Console.ReadLine(), out val2);
        }

        private void InputBool()
        {
            Console.WriteLine("Введите два значения 0 или 1.\n" +
                              "Примечание: отличное от 1 значение рассматривается как 0!");
            Console.WriteLine("Первое значение");
            int.TryParse(Console.ReadLine(), out int temp1);
            if (temp1 == 1)
            {
                isVal1 = true;
            }
            else
            {
                isVal1 = false;
            }

            Console.WriteLine("Второе число");
            int.TryParse(Console.ReadLine(), out int temp2);
            if (temp2 == 1)
            {
                isVal2 = true;
            }
            else
            {
                isVal2 = false;
            }
        }

        private void InputChar()
        {
            Console.WriteLine("Введите два символа.");
            Console.WriteLine("Первое символ:");
            symbol1 = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine("Второе символ:");
            symbol2 = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        private void InputString()
        {
            Console.WriteLine("Введите две строки.");
            Console.WriteLine("Первая строка.");
            word1 = new Word { Words = Console.ReadLine() };
            Console.WriteLine("Вторая строка");
            word2 = new Word { Words = Console.ReadLine() };
        }     

        private void InputNewPassword()
        {
            Console.WriteLine("Введите новый пароль.");
            newPassword = Console.ReadLine();
        }

        private void ConfirmNewPassword()
        {
            Console.WriteLine("Повторите новый пароль.");
            confirmNewPassword = Console.ReadLine();
        }

        private void GetViewUser(UserSignInDTO user)
        {
            Console.WriteLine($"Логин: {user.Login}.\n" +
                              $"Пароль: {user.Password}.\n");
            Console.WriteLine("Операции:");
            foreach(var item in user.OperationInt)
            {
                Console.WriteLine($"Первое значение: {item.Value1}, второе значение: {item.Value2} Результат: {item.Result}");
            }
            foreach (var item in user.OperationBool)
            {
                Console.WriteLine($"Первое значение: {item.Value1}, второе значение: {item.Value2} Результат: {item.Result}");
            }
            foreach (var item in user.OperationChar)
            {
                Console.WriteLine($"Первое значение: {item.Value1}, второе значение: {item.Value2} Результат: {item.Result}");
            }
            foreach (var item in user.OperationWord)
            {
                Console.WriteLine($"Первое значение: {item.Value1.Words}, второе значение: {item.Value2.Words} Результат: {item.Result.Words}");
            }

            Console.ReadLine();
        }
    }
}
