using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.Commands.Interfaces;
using AbsoluteCinema.UI;

namespace AbsoluteCinema.Commands.Commands
{
    class LogCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _consoleUI;
        private readonly AuthorizationUser _auth;

        public LogCommand(AppState appState, IUserInterface consoleUI, AuthorizationUser auth)
        {
            _appState = appState;
            _consoleUI = consoleUI;
            _auth = auth;
        }

        public string Key => "Log";
        public string Description => "log into profile";
        public Role RequiredRole => Role.Guest;

        public void Execute()
        {
            try
            {
                _auth.Log();
                _consoleUI.Output($"Welcome, {_appState.CurrentUser.Name}", TitleColor.Success);
            }
            catch (Exception ex)
            {
                _consoleUI.Output(ex.Message, TitleColor.Error);
            }
        }
    }

}
