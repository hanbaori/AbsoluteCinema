using System.ComponentModel.DataAnnotations;
using System.Data;
using AbsoluteCinema.Models.Domain.Enums;

namespace AbsoluteCinema.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(100)] public string Name { get; set; }
        public Role Role { get; set; } = Role.Guest;

        public List<Booking> Bookings { get; set; }
    }
}
