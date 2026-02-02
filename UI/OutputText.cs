using System;
using System.Collections.Generic;
using AbsoluteCinema.Commands;
using AbsoluteCinema.UI;

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
                new BookSeatsCommand(_appState, _consoleUI),
                new CheckProfileCommand(_appState, _consoleUI),
                new LogCommand(_appState, _consoleUI, auth),
                new RegisterCommand(_appState, _consoleUI, auth),
                new AddShowCommand(_appState, _consoleUI),
                new DeleteShowCommand(_appState, _consoleUI),
                new ShowUsersCommand(_appState, _consoleUI),
                new LogoutCommand(_appState, _consoleUI, auth)
            }; 
        }

        public void PrintMenu()
        {
            Role currentRole = _appState.CurrentUser?.Role ?? Role.Guest;

            _consoleUI.Output("", TitleColor._);
            foreach (var cmd in _consoleCommands)
            {
                if (currentRole >= cmd.RequiredRole)
                    _consoleUI.Output($"{cmd.Key}) - {cmd.Description}", TitleColor.Command);
            }

            _consoleUI.Output("Exit) - exit\n", TitleColor.Command);
        }

        public bool CheckString(string input)
        {
            if (input.ToLower() == "exit")
                return false;

            var command = _consoleCommands.Find(c => c.Key.ToLower() == input.ToLower());

            if (command == null)
            {
                _consoleUI.Output("Unknown command.", TitleColor.Error);
                return true;
            }

            Role currentRole =
                _appState.CurrentUser == null ? Role.Guest : _appState.CurrentUser.Role;

            if (currentRole < command.RequiredRole)
            {
                _consoleUI.Output("Access denied.", TitleColor.Error);
                return true;
            }

            command.Execute();
            return true;
        }

    }
}
