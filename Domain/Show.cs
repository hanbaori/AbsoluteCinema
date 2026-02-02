using System;

namespace AbsoluteCinema
{
    class Show
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateOfShow { get; set; }
        public int AvailableSeats { get; private set; }
        private const int MAXSEATS = 150;

        public Show(string Name, string Description, string DateOfShow, int Seats)
        {
            if(Seats > MAXSEATS || Seats <= 0)
                throw new ArgumentOutOfRangeException(nameof(Seats), $"Seats must be between 1 and {MAXSEATS}.");

            this.Name = Name;
            this.Description = Description;
            this.DateOfShow = DateOfShow;
            this.AvailableSeats = Seats;
        }
        public void BookSeats(int count)
        {
            if (count <= 0 || count > AvailableSeats)
                throw new InvalidOperationException("Not enough seats.");

            AvailableSeats -= count;
        }
    }
}
