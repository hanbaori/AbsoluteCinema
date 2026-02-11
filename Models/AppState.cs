using System.Collections.Generic;
using AbsoluteCinema.Data;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema
{
    public class AppState
    {
        private readonly AbsoluteCinemaContext _db;

        public AppState(AbsoluteCinemaContext db)
        {
            _db = db;
        }
        public DbSet<User> Users => _db.Users;
        public DbSet<Show> Shows => _db.Shows;
        public DbSet<Booking> Bookings => _db.Booking;

        public User CurrentUser { get; set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
