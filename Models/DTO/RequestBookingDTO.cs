using System.ComponentModel.DataAnnotations;

namespace AbsoluteCinema.Models.DTO
{
    public class RequestBookingDTO
    {
        [Required]
        public int BookedSeats { get; set; }
        [Required]
        public Guid ShowId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
    