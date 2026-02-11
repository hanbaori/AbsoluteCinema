using System.Collections.Generic;

namespace AbsoluteCinema
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Role Role => Role.User;
        public List<Booking> Bookings { get; } = new List<Booking>();
        public User() { }
        public User(string Name)
        {
            this.Name = Name;
        }
    }
}
