using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsoluteCinema
{
    class Booking
    {
        public int Id { get; set; }
        public Show Show { get; }
        public List<int> Seats { get; }

        public Booking(Show show, List<int> seats)
        {
            Show = show;
            Seats = seats;
        }
    }
}

