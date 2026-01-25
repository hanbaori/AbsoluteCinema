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

            if (role.ToLower() == "yes")
                return new Admin(name, id);

            return new User(name, id);
        }

        public void Log()
        {
            _consoleUI.Output("Enter name:");
            string name = _consoleUI.Input();
            var text = _appState.Users.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (_appState.Users.Exists(s => s.Name.Equals(text)))
                _appState.CurrentUser = text;
            else
                throw new InvalidOperationException("User with this name doesn`t exists.");
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
