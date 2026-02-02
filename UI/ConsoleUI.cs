using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.UI;

namespace AbsoluteCinema
{
    class ConsoleUI : IUserInterface
    {
        public void Output(string text, TitleColor title)
        {
            switch (title)
            {
                case TitleColor.Title:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case TitleColor.Description:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case TitleColor.Command:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case TitleColor.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case TitleColor.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine(text, title);
            Console.ResetColor();
        }
        public string Input()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Output("Input cannot be empty.", TitleColor.Error);
            }
        }
    }
}
