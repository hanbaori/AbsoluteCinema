using System;
using System.Linq;

namespace AbsoluteCinema
{
    class ListOfShow
    {

        private readonly AppState _appState;

        public ListOfShow(AppState appState)
        {
            _appState = appState;
        }

        public void ShowList()
        {
            if (_appState.Shows.Count == 0)
            {
                Console.WriteLine("No shows available.");
                return;
            }
            foreach (var show in _appState.Shows)
            {
                Console.WriteLine("Name: " + show.Name + "; Description: " + show.Description + "; Date of a show: " + show.DateOfShow);
            }
        }
        public void Add()
        {
            Console.WriteLine("Enter show name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter description:");
            string desc = Console.ReadLine();

            Console.WriteLine("Enter date:");
            string date = Console.ReadLine();

            Console.WriteLine("Enter seats:");
            if (!int.TryParse(Console.ReadLine(), out int seats))
            {
                Console.WriteLine("Invalid seats number.");
                return;
            }

            _appState.Shows.Add(new Show(name, desc, date, seats));
        }

        public void Delete()
        {
            Console.WriteLine("Enter show name");
            string deleteName = Console.ReadLine();
            var show = _appState.Shows.FirstOrDefault(s => s.Name.Equals(deleteName, StringComparison.OrdinalIgnoreCase));

            if (show == null)
            {
                Console.WriteLine("Show not found.");
                return;
            }

            _appState.Shows.Remove(show);
            Console.WriteLine("Show deleted.");
        }
    }
}
