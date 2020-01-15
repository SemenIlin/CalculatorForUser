using System;
using System.Collections.Generic;
using UserManager.ConsoleUI;
using UserManagerBLL.UserDataValidation;

namespace UserManager
{
    public class Program
    {
        static void Main()
        {
            UI user = new UI();

            Dictionary<int, string> nameCommands = new Dictionary<int, string>()
            {
                {0, "Войти в систему"},
                {1, "Зарегистрироваться" }
            };

            Dictionary<string, Action> action = new Dictionary<string, Action>()
            {
                {"Войти в систему", user.SignInUser},
                { "Зарегистрироваться", user.RegistrationUser }
            };


            Dictionary<int, string> nameCommanOnPageForUser = new Dictionary<int, string>()
            {
                {0, "Выполнить математические операции."},
                {1, "Изменить пароль."},
                {2, "Выйти."}
            };

            Dictionary<string, Action> actionOnPageForUser = new Dictionary<string,Action>()
            {
                {"Выполнить математические операции.", user.SetDataAndGetResult},
                {"Изменить пароль.", user.EditUser},
                {"Выйти.", user.ExitFromAccount}
            };


            Dictionary<int, string> nameCommanOnPageForSuperUser = new Dictionary<int, string>()
            {
                {0, "Посмотреть операции пользователя."},
                {1, "Выйти."}
            };

            Dictionary<string, Action> actionOnPageForSuperUser = new Dictionary<string, Action>()
            {
                {"Посмотреть операции пользователя.", user.GetUser},
                {"Выйти.", user.ExitFromAccoutSuperUser}
            };


            CursorForSelect cursorIn = new CursorForSelect(nameCommands, action);
            CursorForSelect cursorUser = new CursorForSelect(nameCommanOnPageForUser, actionOnPageForUser);
            CursorForSelect cursorSuperUser = new CursorForSelect(nameCommanOnPageForSuperUser, actionOnPageForSuperUser);

            while (true)
            {
                try
                {
                    cursorIn.RenderCursor();
                    cursorIn.Move(InputData());

                    while (user.IsLogin)
                    {
                        try
                        {
                            cursorUser.RenderCursor();
                            cursorUser.Move(InputData());
                        }
                        catch (ValidationException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "!!!");
                            Console.ReadKey();
                        }
                    }

                    while(user.IsLoginSuperUser)
                    {
                        try
                        {
                            cursorSuperUser.RenderCursor();
                            cursorSuperUser.Move(InputData());
                        }
                        catch (ValidationException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "!!!");
                            Console.ReadKey();
                        }
                    }
                }
                catch (ValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "!!!");
                    Console.ReadKey();
                }
            }
        }

        private static Direction InputData()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    return Direction.Up;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    return Direction.Down;
                case ConsoleKey.Enter:
                    return Direction.Enter;                
                default:
                    return InputData();
            }
        }
    }
}
