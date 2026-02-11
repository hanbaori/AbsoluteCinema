using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsoluteCinema.Commands.Commands
{
    using System.Linq;
    using AbsoluteCinema.Commands.Interfaces;
    using AbsoluteCinema.UI;

    class DeleteShowCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _consoleUI;
        public DeleteShowCommand(AppState appState, IUserInterface consoleUI)
        {
            _appState = appState;
            _consoleUI = consoleUI;
        }

        public string Key => "Delete";
        public string Description => "delete a show";
        public Role RequiredRole => Role.Admin;

        public void Execute()
        {
            _consoleUI.Output("Enter show name:", TitleColor.Title);
            string name = _consoleUI.Input();

            var show = _appState.Shows
                .FirstOrDefault(s => string.Equals(s.Name.ToLower(), name.ToLower()));

            if (show == null)
            {
                _consoleUI.Output("Show not found.", TitleColor.Error);
                return;
            }   

            _appState.Shows.Remove(show);
            _appState.Save();
            _consoleUI.Output("Show deleted.", TitleColor.Success);
        }
    }

}
