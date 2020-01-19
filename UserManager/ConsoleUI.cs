using System;
using UserManager.PL;
using System.Collections.Generic;
using Exceptions;
using CursorInConsole;

namespace UserManager
{
    public class ConsoleUI
    {
        private readonly Account account;
        private readonly Dictionary<int, Action> action;
        private  Dictionary<string, Action> type;
        private Dictionary<string, Action> commands;

        private CursorForSelect cursorForCommand;
        private CursorForSelect cursorForType;

        private RegistrationModel registration;
        private SignInModel signIn;

        string typeOperation = String.Empty;
        string typeValue = String.Empty;


        private int val1;
        private int val2;

        private bool isVal1;
        private bool isVal2;

        private char symbol1;
        private char symbol2;

        private string word1;
        private string word2;

        private int valueType;        
        private int command;

        private string login;
        private string password;
        private string confirmPassword;
        private string newPassword;
        private string confirmNewPassword;

        public ConsoleUI()
        {
            account = new Account();
            action = new Dictionary<int, Action>
            {
                { 1, CalculateAdditionInt },
                { 2, CalculateAdditionBool },
                { 3, CalculateAdditionChar },
                { 4, CalculateAdditionString },
                { 5, CalculateSubstractionInt },
                { 6, CalculateSubstractionBool },
                { 7, CalculateSubstractionChar },
                { 8, CalculateSubstractionString },
                { 9, CalculateMultiplicationInt },
                { 10, CalculateMultiplicationBool },
                { 11, CalculateMultiplicationChar },
                { 12, CalculateMultiplicationString },
                { 13, CalculateDivisionInt },
                { 14, CalculateDivisionBool },
                { 15, CalculateDivisionChar },
                { 16, CalculateDivisionString }
            };            
        }

        public bool IsType { get; set; }
        public bool IsCommand { get; set; }

        public void RegistrationOfUser()
        {
            SetLogin();
            SetPassword();
            SetConfirmPassword();

            registration = new RegistrationModel(login, password,confirmPassword );
            account.RegistrationUser(registration);
        }

        public void SignIn()
        {
            SetLogin();
            SetPassword();

            signIn = new SignInModel(login, password);
            account.SignInUser(signIn);
        }

        public void EditUser()
        {
            InputNewPassword();
            ConfirmNewPassword();

            ValidationUser validation = new ValidationUser(newPassword, confirmNewPassword);
            validation.CheckUserPassword();

            account.EditUser(newPassword);
        }

        public void SetCommand()
        {
            IsCommand = true;
            commands = new Dictionary<string, Action>
            {
                {"Сложение.", GetCursorPositionFromCommand },
                {"Вычитание.",GetCursorPositionFromCommand },
                {"Умножение.", GetCursorPositionFromCommand},
                {"Деление.", GetCursorPositionFromCommand },
                {"Назад", BackToMainScreen}
            };

            cursorForCommand = new CursorForSelect(commands);

            while (IsCommand)
            {
                Console.WriteLine("Выберите команду:");
                cursorForCommand.RenderCursor();
                cursorForCommand.Move(CursorForSelect.InputData());
            }
        }

        public bool IsLogin()
        {
            return account.IsLogin;
        }

        public bool IsLoginSuperUser()
        { 
            return account.IsLoginSuperUser;
        }

        public void SelectUserFromList()
        {
            account.GetListUsers();
            int count = 1;
            foreach(var item in account.Users)
            {
                Console.WriteLine($"{count}: {item}");
                ++count;
            }

            if (account.Users.Count < 1)
            {
                return;
            }

            Console.WriteLine("Введитете номер пользователя.");
            if (int.TryParse(Console.ReadLine(), out int choise))
            {
                if (choise > account.Users.Count ||
                   choise < 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            var user = account.GetUser(choise);

            Console.WriteLine($"Логин: {user.Login}.\n" +
                             $"Пароль: {user.Password}.\n");
            Console.WriteLine("Операции:");
            foreach (var item in user.OperationInt)
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

        public void ExitFromAccount()
        {
            account.ExitFromAccount();
        }

        public void ExitFromAccountSuperUser()
        {
            account.ExitFromAccoutSuperUser();
        }

        private void CalculateAdditionInt()
        {
            InputInt();
            Console.WriteLine("Результат: " + account.GetResultAdditionInt(val1, val2));            
        }

        private void CalculateAdditionBool()
        {
            InputBool();
            Console.WriteLine("Результат: " + account.GetResultAdditionBool(isVal1, isVal2));
        }

        private void CalculateAdditionChar()
        {
            InputChar();
            Console.WriteLine("Результат: " + account.GetResultAdditionChar(symbol1, symbol2));
        }

        private void CalculateAdditionString()
        {
            InputString();
            Console.WriteLine("Результат: " + account.GetResultAdditionString(word1, word2));
        }

        private void CalculateSubstractionInt()
        {
            InputInt();
            Console.WriteLine("Результат: " + account.GetResultSubstractionInt(val1, val2));
        }

        private void CalculateSubstractionBool()
        {
            InputBool();
            Console.WriteLine("Результат: " + account.GetResultSubstractionBool(isVal1, isVal2));
        }

        private void CalculateSubstractionChar()
        {
            InputChar();
            Console.WriteLine("Результат: " + account.GetResultSubstractionChar(symbol1, symbol2));
        }

        private void CalculateSubstractionString()
        {
            InputString();
            Console.WriteLine("Результат: " + account.GetResultSubstractionString(word1, word2));
        }

        private void CalculateMultiplicationInt()
        {
            InputInt();
            Console.WriteLine("Результат: " + account.GetResultMultiplicationInt(val1, val2));
        }

        private void CalculateMultiplicationBool()
        {
            InputBool();
            Console.WriteLine("Результат: " + account.GetResultMultiplicationBool(isVal1, isVal2));
        }

        private void CalculateMultiplicationChar()
        {
            InputChar();
            Console.WriteLine("Результат: " + account.GetResultMultiplicationChar(symbol1, symbol2));
        }

        private void CalculateMultiplicationString()
        {
            InputString();
            Console.WriteLine("Результат: " + account.GetResultMultiplicationString(word1, word2));
        }

        private void CalculateDivisionInt()
        {
            InputInt();
            Console.WriteLine("Результат: " + account.GetResultDivisionInt(val1, val2));
        }

        private void CalculateDivisionBool()
        {
            InputBool();
            Console.WriteLine("Результат: " + account.GetResultDivisionBool(isVal1, isVal2));
        }

        private void CalculateDivisionChar()
        {
            InputChar();
            Console.WriteLine("Результат: " + account.GetResultDivisionChar(symbol1, symbol2));
        }

        private void CalculateDivisionString()
        {
            InputString();
            Console.WriteLine("Результат: " + account.GetResultDivisionString(word1, word2));
        }       

        private void SetValueType()
        {
            int iterator = 0;

            IsType = true;
            type = new Dictionary<string, Action>
            {
                {"Int.", GetCursorPositionFromType },
                {"Bolean.",GetCursorPositionFromType },
                {"Char.", GetCursorPositionFromType },
                {"String.", GetCursorPositionFromType },
                {"Назад.", BackToCommand},
            };
            cursorForType = new CursorForSelect(type);
            
            foreach (var item in commands)
            {
                if(iterator == cursorForCommand.Cursor.Position)
                {
                    typeOperation = item.Key;
                    break;
                }
                ++iterator;
            }

            while (IsType)
            {
                cursorForType.RenderCursor();
                cursorForType.Move(CursorForSelect.InputData());
            }
        }

       private void Calculate()
        {
            int iterator = 0;
            foreach (var item in type)
            {
                if (iterator == cursorForType.Cursor.Position)
                {
                    typeValue = item.Key;
                    break;
                }
                ++iterator;
            }
            Console.WriteLine("Операция: " + typeOperation);
            Console.WriteLine("Тип: " + typeValue);

            int select = 4 * (command) + valueType + 1;
            action[select].Invoke();
            Console.ReadLine();
            IsCommand = false;
            IsType = false;
        }

        private void GetCursorPositionFromCommand()
        {
            command = cursorForCommand.Cursor.Position;
            SetValueType();
        }

        private void BackToMainScreen()
        {
            IsCommand = false;
        }

        private void GetCursorPositionFromType()
        {
            valueType = cursorForType.Cursor.Position;
            Calculate();
        }

        private void BackToCommand()
        {
            IsType = false;
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

        private void SetLogin()
        {
            Console.WriteLine("Введите логин:");
            login = Console.ReadLine();
        }

        private void SetPassword()
        {
            Console.WriteLine("Введите пароль:");
            password = Console.ReadLine();
        }

        private void SetConfirmPassword()
        {
            Console.WriteLine("Повторите пароль:");
            confirmPassword = Console.ReadLine();
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
            word1 = Console.ReadLine();
            Console.WriteLine("Вторая строка");
            word2 = Console.ReadLine();
        }
    }
}
