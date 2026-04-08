namespace AbsoluteCinema.Models.Domain
{
    public class Show
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ShowDate { get; set; }
        public string? ShowImageUrl { get; set; }
    }
}
