using System;

namespace AbsoluteCinema
{
    class Show
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateOfShow { get; set; }
        public int Seats { get; set; }

        public Show()
        {
            Name = String.Empty;
            Description = String.Empty;
            DateOfShow = String.Empty;
            Seats = int.MinValue;
        }

        public Show(string Name, string Description, string DateOfShow, int Seats)
        {
            this.Name = Name;
            this.Description = Description;
            this.DateOfShow = DateOfShow;
            this.Seats = Seats;
        }
    }
}
