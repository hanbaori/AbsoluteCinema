namespace AbsoluteCinema.Models.DTO
{
    public class RequestBookingDTO
    {
        public Guid Id { get; set; }
        public int BookedSeats { get; set; }
        public Guid ShowId { get; set; }
        public Guid UserId { get; set; }
    }
}
