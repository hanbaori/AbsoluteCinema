using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.Commands;

namespace AbsoluteCinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is just simple realisation just to take look on project\n" +
                "So right now you have options:\n ");

            var appState = new AppState();
            var consoleUI = new ConsoleUI();
            var uiText = new OutputText(appState, consoleUI);

            appState.Users.Add(new User("user1", 1));

            appState.Shows.AddRange(new[]
            {
                new Show("show1", "blabla", "21.01", 100),
                new Show("show2", "blabla", "21.01", 100),
                new Show("show3", "blabla", "21.01", 100),
                new Show("show4", "blabla", "21.01", 100),
            });

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
