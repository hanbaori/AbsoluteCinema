using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbsoluteCinema.Models.Domain.Enums;

namespace AbsoluteCinema.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        [MaxLength(50)] public string FileName { get; set; }
        [MaxLength(10)] public string FileExtension { get; set; }
        public long FileSizeInBytes { get; set; }
        [MaxLength(250)] public string FilePath { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
