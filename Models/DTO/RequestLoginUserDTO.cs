using System.ComponentModel.DataAnnotations;

namespace AbsoluteCinema.Models.DTO
{
    public class RequestLoginUserDTO
    {
        [Required, DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
