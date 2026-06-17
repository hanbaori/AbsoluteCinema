using System.ComponentModel.DataAnnotations;

namespace AbsoluteCinema.Models.DTO
{
    public class RequestRegisterUserDto
    {
        [Required, DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required, DataType(DataType.Text)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
