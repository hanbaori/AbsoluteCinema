using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.Commands.Interfaces;
using AbsoluteCinema.UI;

namespace AbsoluteCinema.Commands.Commands
{
    class ShowListCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _consoleUI;
        public ShowListCommand(AppState appState, IUserInterface consoleUI)
        {
            _appState = appState;
            _consoleUI = consoleUI;
        }

        public string Key => "Show";
        public string Description => "show list of available shows";
        public Role RequiredRole => Role.Guest;
        public void Execute()
        {
            if (_appState.Shows.Count == 0)
            {
                _consoleUI.Output("No shows available.", TitleColor.Error);
                return;
            }

            foreach (var show in _appState.Shows)
            {
                _consoleUI.Output(
                    $"Name: {show.Name}; Description: {show.Description}; Date: {show.DateOfShow}; Seats: {show.AvailableSeatsCount()};",
                    TitleColor._
                );
            }
        }
    }
}
