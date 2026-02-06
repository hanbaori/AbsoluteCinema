using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.Commands.Interfaces;
using AbsoluteCinema.UI;

namespace AbsoluteCinema.Commands.Commands
{
    class LogoutCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _consoleUI;
        private readonly AuthorizationUser _auth;

        public LogoutCommand(AppState appState, IUserInterface consoleUI, AuthorizationUser auth)
        {
            _appState = appState;
            _consoleUI = consoleUI;
            _auth = auth;
        }

        public string Key => "Logout";
        public string Description => "log out of profile";
        public Role RequiredRole => Role.User;

        public void Execute()
        {
            _auth.Logout();
            _consoleUI.Output("Logged out.", TitleColor.Success);
        }
    }

}
