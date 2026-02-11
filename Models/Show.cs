using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteCinema
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateOfShow { get; set; }

        public Dictionary<int, User> Seats = new Dictionary<int, User>();
        public const int MAXSEATS = 50;

        public Show() { }
        public Show(string name, string description, string dateOfShow, int seats)
        {
            if(seats > MAXSEATS || seats <= 0)
                throw new ArgumentOutOfRangeException(nameof(seats), $"Seats must be between 1 and {MAXSEATS}.");

            this.Name = name;
            this.Description = description;
            this.DateOfShow = dateOfShow;

            for(int i = 1; i <= seats; i++)
            {
                Seats.Add(i, null);
            }
        }
    }
}
