using System.Data;
using AbsoluteCinema.Models.Domain.Enums;

namespace AbsoluteCinema.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Role Role => Role.User;
    }
}
