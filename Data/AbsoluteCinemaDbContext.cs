using AbsoluteCinema.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Data
{
    public class AbsoluteCinemaDbContext : DbContext
    {
        public AbsoluteCinemaDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Show> Shows { get; set; }  
        public DbSet<User> Users { get; set; }  
        public DbSet<Booking> Bookings { get; set; }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var shows = new List<Show>()
            {
                new Show { Id = Guid.Parse("94d9c9ac-6c5e-4e51-86cc-990405d84583"), Name = "Dune 3", ShowImageUrl = null, ShowDate = new DateTime(2026, 12, 18),
                    Description = "\"No more terrible disaster could befall your people than for them to fall into the hands of a hero\""},
                new Show { Id = Guid.Parse("7038a7d2-652c-45fb-9160-135b0cd580bf"), Name = "Supergirl", ShowImageUrl = null, ShowDate = new DateTime(2026, 6, 26),
                    Description = "A battle-hardened Kara Zor-El journeys across a harsh universe, forging her own identity as Supergirl while turning pain, loss, and fury into a new kind of hope."},
                new Show { Id = Guid.Parse("82d002bc-67f8-448f-aeb1-15db7d474f8e"), Name = "The Odyssey", ShowImageUrl = null, ShowDate = new DateTime(2026, 7, 17),
                    Description = "Odysseus, king of Ithaca, embarks on a perilous journey to return home after the Trojan War."}
            };

            modelBuilder.Entity<Show>().HasData(shows);

            var users = new List<User>()
            {
                new User { },
                new User { }
            };

            modelBuilder.Entity<Show>().HasData(users);
        }
*/
    }
}
