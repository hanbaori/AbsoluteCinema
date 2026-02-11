using System;
using System.Linq;
using AbsoluteCinema.UI;

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
            _consoleUI.Output("Enter name:", TitleColor.Title);
            string name = _consoleUI.Input();

            _consoleUI.Output("Admin? (yes/no)", TitleColor.Title);
            string role = _consoleUI.Input().ToLower();

            if(role != "yes" && role != "no")
                throw new InvalidOperationException("Invalid input.");

            User user = role.ToLower() == "yes" ? new Admin(name) : new User(name);

            _appState.Users.Add(user);
            _appState.Save();

            return user;
        }

        public void Log()
        {
            _consoleUI.Output("Enter name:", TitleColor.Title);
            string name = _consoleUI.Input();

            var user = _appState.Users.FirstOrDefault(u => u.Name.ToLower().Equals(name.ToLower()));

            if (user == null)
                throw new InvalidOperationException("User with this name doesn’t exist.");

            _appState.CurrentUser = user;
        }
        public void Logout()
        {
            if (_appState.CurrentUser == null)
                _consoleUI.Output("No user available", TitleColor.Error);
            _appState.CurrentUser = null;
        }

        public User GetCurrentUser()
        {
            return _appState.CurrentUser;
        }
    }
}
