using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteCinema.Commands.Interfaces;
using AbsoluteCinema.UI;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Commands.Commands
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
            var user = _appState.Users
                .Where(u => u.Id == _appState.CurrentUser.Id)
                .Include(b => b.Bookings)
                .ThenInclude(b => b.Show)
                .FirstOrDefault();

            if (user == null)
            {
                _ui.Output("User is not found.", TitleColor.Error);
                return;
            }

            _ui.Output($"User: {user.Name}", TitleColor._);
            _ui.Output("Bookings:", TitleColor._);

            if (!user.Bookings.Any())
            {
                _ui.Output("No bookings yet.", TitleColor.Error);
                return;
            }

            foreach (var b in user.Bookings)
            {
                string seatsList = string.Join(", ", b.Seats);
                _ui.Output($"{b.Show.Name} ({b.Show.DateOfShow}) - seats: {seatsList}", TitleColor._);
            }
        }
    }
}
