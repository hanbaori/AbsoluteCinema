using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.Commands;
using AbsoluteCinema.Data;

namespace AbsoluteCinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is just simple realisation just to take look on project\n" +
                "So right now you have options: ");

            using var db = new AbsoluteCinemaContext();
            var appState = new AppState(db);
            var consoleUI = new ConsoleUI();
            var uiText = new OutputText(appState, consoleUI);

            bool check = true;
            while (check)
            {
                uiText.PrintMenu();
                string output = consoleUI.Input();
                check = uiText.CheckString(output);
            }

        }
    }
}
