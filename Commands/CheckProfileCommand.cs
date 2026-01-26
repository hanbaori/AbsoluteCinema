using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsoluteCinema.Commands
{
    class CheckProfileCommand : ICommand
    {
        private readonly AppState _appState;
        private readonly IUserInterface _ui;
        public CheckProfileCommand(AppState appState, IUserInterface ui)
        {
            _appState = appState;
            _ui = ui;
        }
        public string Key => "Profile";
        public string Description => "view profile and bookings";
        public Role RequiredRole => Role.User;

        public void Execute()
        {
            var user = _appState.CurrentUser;

            _ui.Output($"User: {user.Name}");
            _ui.Output("Bookings:");

            if (user.Bookings.Count == 0)
            {
                _ui.Output("No bookings yet.");
                return;
            }

            foreach (var b in user.Bookings)
                _ui.Output($"{b.Show.Name} ({b.Show.DateOfShow}) - seats: {b.Seats}");
        }
    }
}
