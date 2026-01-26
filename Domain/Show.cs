using System;

namespace AbsoluteCinema
{
    class Show
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateOfShow { get; set; }
        public int AvailableSeats { get; private set; }

        public Show()
        {
            Name = String.Empty;
            Description = String.Empty;
            DateOfShow = String.Empty;
            AvailableSeats = int.MinValue;
        }

        public Show(string Name, string Description, string DateOfShow, int Seats)
        {
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
