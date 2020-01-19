using System;
using System.Collections.Generic;

namespace CursorInConsole
{
    public class CursorForSelect
    {
        private readonly string[] commands;
        private readonly Dictionary<string, Action> action;
        
        private char[] choise;

        public CursorForSelect( Dictionary<string, Action> action)
        {
            this.action = action;
            commands = new string[action.Count];
            Cursor = new Cursor { View = '>', Position = 0 };
            CreateCommands();
            ChoiseUser();
        }

        public Cursor Cursor { get; private set; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    Cursor.Position -= 1;
                    break;
                case Direction.Down:
                    Cursor.Position += 1;
                    break;
                case Direction.Enter:
                    action[commands[Cursor.Position]].Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), $"Unknown direction: {direction}");
            }
            VerifyOutOfBounds();
        }

        public void RenderCursor()
        {
            Console.Clear();        

            for ( int position = 0 ; position < choise.Length; position++)
            {
                if (position == Cursor.Position)
                {
                    choise[position] = Cursor.View;
                }
                else
                {
                    choise[position] = ' ';
                }
                

                Console.Write(choise[position] + " " + commands[position]);
                Console.WriteLine();
            }           
        }

        public static Direction InputData()
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

        private void VerifyOutOfBounds()
        {
            if (Cursor.Position >= choise.Length)
            {
                Cursor.Position = choise.Length - 1;
            }
            else if (Cursor.Position <= 0)
            {
                Cursor.Position = 0;
            }
        }

        private void ChoiseUser()
        {
            choise = new char[action.Count];
        }

        private string[] CreateCommands()
        {
            int iterator = 0;
            foreach (var item in action)
            {
                commands[iterator] = item.Key;
                ++iterator;
            }

            return commands;
        }
    }
}
