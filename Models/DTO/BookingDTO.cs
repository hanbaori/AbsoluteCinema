using AbsoluteCinema.Models.DTO;

namespace AbsoluteCinema.Models.Domain
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public int BookedSeats { get; set; }
        public Guid ShowId {  get; set; }
        public Guid UserId { get; set; }

        //Navigation properties
        public ShowDTO Show { get; set; }
        public UserDTO User { get; set; }
    }
}
