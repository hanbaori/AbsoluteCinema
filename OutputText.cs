using System;
using System.Collections.Generic;
using AbsoluteCinema.Commands;

namespace AbsoluteCinema
{
    class OutputText
    {
        private readonly AppState _appState;
        private readonly IUserInterface _consoleUI;
        private readonly List<ICommand> _consoleCommands;
        public OutputText(AppState appState, IUserInterface consoleUI)
        {
            _appState = appState;
            _consoleUI = consoleUI;
            var auth = new AuthorizationUser(_appState, _consoleUI);
            _consoleCommands = new List<ICommand>
            {
                new ShowListCommand(_appState, _consoleUI),
                new LogCommand(_appState, _consoleUI, auth),
                new RegisterCommand(_appState, _consoleUI, auth),
                new AddShowCommand(_appState, _consoleUI),
                new DeleteShowCommand(_appState, _consoleUI),
                new LogoutCommand(_appState, _consoleUI, auth)
            }; 
        }

        public void PrintMenu()
        {
            Role currentRole = _appState.CurrentUser?.Role ?? Role.Guest;

            foreach (var cmd in _consoleCommands)
            {
                if (currentRole >= cmd.RequiredRole)
                    _consoleUI.Output($"{cmd.Key}) - {cmd.Description}");
            }

            _consoleUI.Output("EXIT) - exit\n");
        }

        public bool CheckString(string input)
        {
            if (input == "EXIT")
                return false;

            var command = _consoleCommands.Find(c => c.Key == input);

            if (command == null)
            {
                _consoleUI.Output("Unknown command.");
                return true;
            }

            Role currentRole =
                _appState.CurrentUser == null ? Role.Guest : _appState.CurrentUser.Role;

            if (currentRole < command.RequiredRole)
            {
                _consoleUI.Output("Access denied.");
                return true;
            }

            command.Execute();
            return true;
        }

    }
}
