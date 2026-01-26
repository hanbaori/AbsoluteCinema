using System;
using System.Linq;

namespace AbsoluteCinema
{
    class AuthorizationUser
    {
        private readonly AppState _appState;
        private readonly IUserInterface _consoleUI;

        public AuthorizationUser(AppState appState, IUserInterface consoleUI)
        {
            _appState = appState;
            _consoleUI = consoleUI;
        }

        public User Register()
        {
            _consoleUI.Output("Enter name:");
            string name = _consoleUI.Input();

            _consoleUI.Output("Enter id:");
            int id = int.Parse(_consoleUI.Input());
            ExistCheck(id);

            _consoleUI.Output("Admin? (yes/no)");
            string role = _consoleUI.Input();

            User user = role.ToLower() == "yes" ? new Admin(name, id) : new User(name, id);

            _appState.Users.Add(user); 

            return user;
        }

        public void Log()
        {
            _consoleUI.Output("Enter name:");
            string name = _consoleUI.Input();

            var user = _appState.Users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (user == null)
                throw new InvalidOperationException("User with this name doesn’t exist.");

            _appState.CurrentUser = user;
        }
        public void Logout()
        {
            if (_appState.CurrentUser == null)
                _consoleUI.Output("No user available");
            _appState.CurrentUser = null;
        }

        public User GetCurrentUser()
        {
            return _appState.CurrentUser;
        }

        private void ExistCheck(int id)
        {
            if (_appState.Users.Any(u => u.Id == id))
                throw new InvalidOperationException("User with this ID already exists.");
        }
    }
}
