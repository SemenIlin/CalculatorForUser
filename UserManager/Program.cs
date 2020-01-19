using CursorInConsole;
using Exceptions;
using System;
using System.Collections.Generic;

namespace UserManager
{
    public class Program
    {
        static void Main()
        {
            ConsoleUI ui = new ConsoleUI();

            Dictionary<string, Action> action = new Dictionary<string, Action>()
            {
                {"Войти в систему", ui.SignIn},
                { "Зарегистрироваться", ui.RegistrationOfUser }
            };

            Dictionary<string, Action> actionOnPageForUser = new Dictionary<string, Action>()
            {
                {"Выполнить математические операции.", ui.SetCommand},
                {"Изменить пароль.", ui.EditUser},
                {"Выйти.", ui.ExitFromAccount}
            };


            Dictionary<string, Action> actionOnPageForSuperUser = new Dictionary<string, Action>()
            {
                {"Посмотреть операции пользователя.", ui.SelectUserFromList},
                {"Выйти.", ui.ExitFromAccountSuperUser}
            };

            CursorForSelect cursorIn = new CursorForSelect(action);
            CursorForSelect cursorUser = new CursorForSelect(actionOnPageForUser);
            CursorForSelect cursorSuperUser = new CursorForSelect(actionOnPageForSuperUser);

            while (true)
            {
                try
                {
                    cursorIn.RenderCursor();
                    cursorIn.Move(CursorForSelect.InputData());

                    while (ui.IsLogin())
                    {
                        try
                        {
                            cursorUser.RenderCursor();
                            cursorUser.Move(CursorForSelect.InputData());
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

                    while (ui.IsLoginSuperUser())
                    {
                        try
                        {
                            cursorSuperUser.RenderCursor();
                            cursorSuperUser.Move(CursorForSelect.InputData());
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

    }
}
