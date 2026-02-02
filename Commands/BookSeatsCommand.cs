using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.UI;

namespace AbsoluteCinema.Commands
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
            _consoleUI.Output("Enter show name:", TitleColor.Title);
            string name = _consoleUI.Input();

            var show = _appState.Shows.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (show == null)
            {
                _consoleUI.Output("Show not found.", TitleColor.Error);
                return;
            }

            //тбх тут би реалізувати по номерах букінг, але бебебе
            _consoleUI.Output("Enter seats count:", TitleColor.Title);

            if(!int.TryParse(_consoleUI.Input(), out int seats))
            {
                _consoleUI.Output("Invalid seats number.", TitleColor.Error);
                return;
            }
            
            try
            {
                show.BookSeats(seats);
                _appState.CurrentUser.Bookings.Add(new Booking(show, seats));

                _consoleUI.Output("Booking successful.", TitleColor.Success);
            }
            catch (Exception ex)
            {
                _consoleUI.Output(ex.Message, TitleColor.Error);
            }
        }
    }
}
