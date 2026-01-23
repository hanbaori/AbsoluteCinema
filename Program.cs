using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AbsoluteCinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is just simple realisation just to take look on project\n" +
                "So right now you have options:\n ");

            var appState = new AppState();
            var uiText = new OutputText(appState);

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
                string output = Console.ReadLine();
                check = uiText.CheckString(output);
            }

        }
    }
}
