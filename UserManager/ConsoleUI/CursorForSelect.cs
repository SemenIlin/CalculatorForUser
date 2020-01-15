using System;
using System.Collections.Generic;

namespace UserManager.ConsoleUI
{
    public class CursorForSelect
    {
        private readonly Dictionary<int, string> commands;  
        private readonly Dictionary<string, Action> action;
        private readonly Cursor cursor = new Cursor { View = '>', Position = 0 };
        
        private char[] choise;

        public CursorForSelect(Dictionary<int, string> commands, Dictionary<string, Action> action)
        {
            this.action = action;
            this.commands = commands;
            ChoiseUser();
        }

        private void ChoiseUser()
        {
            choise = new char[commands.Count];
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    cursor.Position -= 1;
                    break;
                case Direction.Down:
                    cursor.Position += 1;
                    break;
                case Direction.Enter:
                    action[commands[cursor.Position]].Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), $"Unknown direction: {direction}");
            }
            VerifyOutOfBounds();
        }

        private void VerifyOutOfBounds()
        {
            if (cursor.Position >= choise.Length)
            {
                cursor.Position = choise.Length - 1;
            }
            else if (cursor.Position <= 0)
            {
                cursor.Position = 0;
            }            
        }

        public void RenderCursor()
        {
            Console.Clear();        

            for ( int position = 0 ; position < choise.Length; position++)
            {
                if (position == cursor.Position)
                {
                    choise[position] = cursor.View;
                }
                else
                {
                    choise[position] = ' ';
                }
                

                Console.Write(choise[position] + " " + commands[position]);
                Console.WriteLine();
            }           
        }
    }
}
