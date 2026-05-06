namespace AbsoluteCinema.Models.Domain
{
    public class Booking
    {
        public Guid Id { get; set; }
        public List<Show> Seats { get; set; }

        public Guid ShowId {  get; set; }
        public Guid UserId { get; set; }

        //Navigation properties
        public Show Show { get; set; }
        public User User { get; set; }
    }
}
