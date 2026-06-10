using System.ComponentModel.DataAnnotations;
using AbsoluteCinema.Models.Domain.Enums;

namespace AbsoluteCinema.Models.Domain
{
    public class Show
    {
        public Guid Id { get; set; }
        [MaxLength(50)] public string Name { get; set; }
        [MaxLength(500)] public string Description { get; set; }
        public DateTime ShowDate { get; set; }
        [MaxLength(250)] public string? ShowImageUrl { get; set; }
        public List<Genre>? Genres { get; set; }
    }
}
