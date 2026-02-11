using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.Commands.Interfaces;
using AbsoluteCinema.UI;

namespace AbsoluteCinema.Commands.Commands
{
    class BookSeatsCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _consoleUI;
        public BookSeatsCommand(AppState appState, IUserInterface consoleUI)
        {
            _appState = appState;
            _consoleUI = consoleUI;
        }

        public string Key => "Book";
        public string Description => "book seats";
        public Role RequiredRole => Role.User;

        public void Execute()
        {
            if (!_appState.Shows.Any())
            {
                _consoleUI.Output("There is no shows right now.", TitleColor.Error);
                return;
            }

            _consoleUI.Output("Enter show name:", TitleColor.Title);
            string name = _consoleUI.Input();

            var show = _appState.Shows.FirstOrDefault(s => s.Name.ToLower().Equals(name.ToLower()));

            if (show == null)
            {
                _consoleUI.Output("Show not found.", TitleColor.Error);
                return;
            }

            var availableSeats = Enumerable
                .Range(1, Show.MAXSEATS)
                .Except(_appState.Bookings
                    .Where(b => b.Show.Id == show.Id)
                    .SelectMany(b => b.Seats)
                    .ToList())
                .ToList();

            _consoleUI.Output($"Available seats:{string.Join(", ", availableSeats)}", TitleColor._);

            _consoleUI.Output("Enter seat numbers:", TitleColor.Title);

            string input = _consoleUI.Input();

            try
            {
                List<int> selectedSeats = input
                    .Split(',')
                    .Select(s => int.Parse(s.Trim()))
                    .ToList();

                var booking = new Booking(show, selectedSeats)
                {
                    User = _appState.CurrentUser
                };

                _appState.Bookings.Add(booking);
                _appState.Save();
                _consoleUI.Output("Booking successful.", TitleColor.Success);
            }
            catch (Exception ex)
            {
                _consoleUI.Output(ex.Message, TitleColor.Error);
            }
        }
    }
}
