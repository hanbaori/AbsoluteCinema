using System;
using System.Collections.Generic;

namespace AbsoluteCinema
{
    class OutputText
    {
        private readonly AppState _appState;
        private readonly ListOfShow _shows;
        private readonly List<ConsoleCommand> _consoleCommands;
        public OutputText(AppState appState)
        {
            _appState = appState;
            _shows = new ListOfShow(appState);
            _consoleCommands = new List<ConsoleCommand>
            {
                new ConsoleCommand(
                    "Show",
                    "show list of available shows",
                    Role.Guest,
                    () => _shows.ShowList()
                    ),
                new ConsoleCommand(
                    "Reg",
                    "register to profile",
                    Role.Guest,
                    () =>
                    {
                        _appState.CurrentUser = ConsoleUserCheck.Register();
                        Console.WriteLine($"Welcome, {_appState.CurrentUser.Name}");
                    }),
                new ConsoleCommand(
                    "Add",
                    "add new show",
                    Role.Admin,
                    () => _shows.Add()
                    ),
                new ConsoleCommand(
                    "Delete",
                    "delete a show",
                    Role.Admin,
                    () => _shows.Delete()
                    ),
                new ConsoleCommand(
                    "Logout",
                    "log out of profile",
                    Role.User,
                    () =>
                    {
                        _appState.CurrentUser = null;
                        Console.WriteLine("Logged out.");
                    }),
            }; ;
        }

        
        public void PrintMenu()
        {
            Role currentRole = _appState.CurrentUser == null ? Role.Guest : _appState.CurrentUser.Role;

            foreach (var cmd in _consoleCommands)
            {
                if (currentRole >= cmd.Role)
                    Console.WriteLine($"{cmd.Key}) - {cmd.Value}");
            }

            Console.WriteLine("EXIT) - exit");
        }

        public bool CheckString(string input)
        {
            if (input == "EXIT")
                return false;

            var command = _consoleCommands.Find(c => c.Key == input);

            if (command == null)
            {
                Console.WriteLine("Unknown command.");
                return true;
            }

            Role currentRole =
                _appState.CurrentUser == null ? Role.Guest : _appState.CurrentUser.Role;

            if (currentRole < command.Role)
            {
                Console.WriteLine("Access denied.");
                return true;
            }

            command.ConsoleAction();
            return true;
        }

    }
}
