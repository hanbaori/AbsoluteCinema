using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsoluteCinema.Commands
{
    class BookSeatsCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _ui;
        public BookSeatsCommand(AppState appState, IUserInterface ui)
        {
            _appState = appState;
            _ui = ui;
        }

        public string Key => "Book";
        public string Description => "book seats";
        public Role RequiredRole => Role.User;

        public void Execute()
        {
            _ui.Output("Enter show name:");
            string name = _ui.Input();

            var show = _appState.Shows.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (show == null)
            {
                _ui.Output("Show not found.");
                return;
            }

            //тбх тут би реалізувати по номерах букінг, але бебебе
            _ui.Output("Enter seats count:");
            int seats = int.Parse(_ui.Input());

            show.BookSeats(seats);
            _appState.CurrentUser.Bookings.Add(new Booking(show, seats));

            _ui.Output("Booking successful.");
        }
    }
}
