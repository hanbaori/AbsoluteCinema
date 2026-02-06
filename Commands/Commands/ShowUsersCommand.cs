using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.Commands.Interfaces;
using AbsoluteCinema.UI;

namespace AbsoluteCinema.Commands.Commands
{
    class ShowUsersCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _ui;
        public ShowUsersCommand(AppState appState, IUserInterface ui)
        {
            _appState = appState;
            _ui = ui;
        }
        public string Key => "Users";
        public string Description => "show all users";
        public Role RequiredRole => Role.Admin;

        public void Execute()
        {
            if (_appState.Users.Count == 0)
            {
                _ui.Output("No users found.", TitleColor.Error);
                return;
            }

            foreach (var user in _appState.Users)
            {
                _ui.Output($"Name: {user.Name}, ID: {user.Id}, Role: {user.Role}", TitleColor._);
            }
        }
    }
}
