using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsoluteCinema
{
    class Booking
    {
        public Show Show { get; }
        public int Seats { get; }

        public Booking(Show show, int seats)
        {
            Show = show;
            Seats = seats;
        }
    }
}

