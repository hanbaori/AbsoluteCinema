using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteCinema
{
    class Show
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateOfShow { get; set; }
        private Dictionary<int, User> _seats = new Dictionary<int, User>();
        private const int MAXSEATS = 50;

        public Show(string name, string description, string dateOfShow, int seats)
        {
            if(seats > MAXSEATS || seats <= 0)
                throw new ArgumentOutOfRangeException(nameof(seats), $"Seats must be between 1 and {MAXSEATS}.");

            this.Name = name;
            this.Description = description;
            this.DateOfShow = dateOfShow;

            for(int i = 1; i <= seats; i++)
            {
                _seats.Add(i, null);
            }
        }
        public List<int> GetAvailableSeats()
        {
            List<int> list = new List<int>();
            foreach(var pair in _seats)
            {
                if(pair.Value == null)
                    list.Add(pair.Key);
            }
            return list;
        }
        public void BookSeats(List<int> seatNumbers, User currentUser)
        {
            foreach (var num in seatNumbers)
            {
                if (!_seats.ContainsKey(num))
                    throw new InvalidOperationException($"Seat {num} does not exist.");
                if (_seats[num] != null)
                    throw new InvalidOperationException($"Seat {num} is already booked.");
            }
            foreach (var num in seatNumbers)
            {
                _seats[num] = currentUser;
            }
        }
        public int AvailableSeatsCount()
        {
            return _seats.Values.Where(s => s == null).Count();
        }
    }
}
