using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.Commands.Interfaces;
using AbsoluteCinema.UI;

namespace AbsoluteCinema.Commands.Commands
{
    class RegisterCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _consoleUI;
        private readonly AuthorizationUser _auth;

        public RegisterCommand(AppState appState, IUserInterface consoleUI, AuthorizationUser auth)
        {
            _appState = appState;
            _consoleUI = consoleUI;
            _auth = auth;
        }

        public string Key => "Reg";
        public string Description => "register to profile";
        public Role RequiredRole => Role.Guest;

        public void Execute()
        {
            try
            {
                _appState.CurrentUser = _auth.Register();
                _consoleUI.Output($"Welcome, {_appState.CurrentUser.Name}", TitleColor.Success);
            }
            catch (Exception ex)
            {
                _consoleUI.Output(ex.Message, TitleColor.Error);
            }
        }
    }

}
