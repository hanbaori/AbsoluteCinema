using System.Collections.Generic;

namespace AbsoluteCinema
{
    public class AppState
    {
        public User CurrentUser { get; set; }
        public List<Show> Shows { get; } = new List<Show>();
        public List<User> Users { get; } = new List<User>();
    }
}
