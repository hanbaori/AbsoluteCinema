namespace AbsoluteCinema.Models.DTO
{
    public class RequestShowDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ShowDate { get; set; }
        public string? ShowImageUrl { get; set; }
    }
}
