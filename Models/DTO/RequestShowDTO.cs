using System.ComponentModel.DataAnnotations;
using AbsoluteCinema.Models.Domain.Enums;

namespace AbsoluteCinema.Models.DTO
{
    public class RequestShowDTO
    {
        [Required, 
         MaxLength(50)] 
        public string Name { get; set; }

        [Required,
         MaxLength(500)] 
        public string Description { get; set; }

        [Required]
        public DateTime ShowDate { get; set; }

        [Required,
         MaxLength(250)] 
        public string? ShowImageUrl { get; set; }

        public List<Genre>? Genres { get; set; }
    }
}
