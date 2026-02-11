using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsoluteCinema
{
    public class Booking
    {
        public int Id { get; set; }
        public Show Show { get; set; }
        public List<int> Seats { get; set; }
        public User User { get; set; }
        public Booking() { }
        public Booking(Show show, List<int> seats)
        {
            Show = show;
            Seats = seats;
        }
    }
}

