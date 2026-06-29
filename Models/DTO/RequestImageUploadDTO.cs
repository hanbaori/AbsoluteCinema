using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbsoluteCinema.Models.Domain.Enums;

namespace AbsoluteCinema.Models.Domain
{
    public class RequestImageUploadDTO
    {
        [Required, MaxLength(50)] 
        public string FileName { get; set; }

        [NotMapped] 
        public IFormFile File { get; set; }
    }
}
