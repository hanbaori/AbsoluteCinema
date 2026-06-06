using System.ComponentModel.DataAnnotations;
using AbsoluteCinema.Models.Domain.Enums;

namespace AbsoluteCinema.Models.DTO
{
    public class RequestUserDTO
    {
        [MaxLength(100)] public string Name { get; set; }
        public Role Role { get; set; }
    }
}
