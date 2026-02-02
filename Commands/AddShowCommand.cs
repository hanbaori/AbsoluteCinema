using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.UI;

namespace AbsoluteCinema.Commands
{
    class AddShowCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _consoleUI;

        public AddShowCommand(AppState appState, IUserInterface consoleUI)
        {
            _appState = appState;
            _consoleUI = consoleUI;
        }

        public string Key => "Add";
        public string Description => "add new show";
        public Role RequiredRole => Role.Admin;

        public void Execute()
        {
            _consoleUI.Output("Enter show name:", TitleColor.Title);
            string name = _consoleUI.Input();

            _consoleUI.Output("Enter description:", TitleColor.Title);
            string desc = _consoleUI.Input();

            _consoleUI.Output("Enter date:", TitleColor.Title);
            string date = _consoleUI.Input();

            _consoleUI.Output("Enter seats:", TitleColor.Title);
            if (!int.TryParse(_consoleUI.Input(), out int seats))
            {
                _consoleUI.Output("Invalid seats number.", TitleColor.Error);
                return;
            }

            _appState.Shows.Add(new Show(name, desc, date, seats));
        }
    }

}
