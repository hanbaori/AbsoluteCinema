using System.ComponentModel.DataAnnotations;
using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Models.Domain.Enums;

namespace AbsoluteCinema.Models.DTO
{
    public class RequestUserDTO
    {
        [Required,
         MaxLength(100)] 
        public string Name { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
