using AbsoluteCinema.Models.Domain;
using Microsoft.EntityFrameworkCore;
using AbsoluteCinema.Models.Domain.Enums;

namespace AbsoluteCinema.Data
{
    public class AbsoluteCinemaDbContext : DbContext
    {
        public AbsoluteCinemaDbContext(DbContextOptions<AbsoluteCinemaDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Show> Shows { get; set; }  
        public DbSet<User> Users { get; set; }  
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var shows = new List<Show>()
            {
                new Show { Id = Guid.Parse("94d9c9ac-6c5e-4e51-86cc-990405d84583"), Name = "Dune 3", ShowImageUrl = null, ShowDate = new DateTime(2026, 12, 18),
                    Genres = new List<Genre> { Genre.Adventure, Genre.SciFi, Genre.Drama }, 
                    Description = "\"No more terrible disaster could befall your people than for them to fall into the hands of a hero\""},
                new Show { Id = Guid.Parse("7038a7d2-652c-45fb-9160-135b0cd580bf"), Name = "Supergirl", ShowImageUrl = null, ShowDate = new DateTime(2026, 6, 26),
                    Genres = new List<Genre> { Genre.SciFi, Genre.Action, Genre.Fantasy },
                    Description = "A battle-hardened Kara Zor-El journeys across a harsh universe, forging her own identity as Supergirl while turning pain, loss, and fury into a new kind of hope."},
                new Show { Id = Guid.Parse("82d002bc-67f8-448f-aeb1-15db7d474f8e"), Name = "The Odyssey", ShowImageUrl = null, ShowDate = new DateTime(2026, 7, 17),
                    Genres = new List<Genre> { Genre.Drama, Genre.Action, Genre.Fantasy },
                    Description = "Odysseus, king of Ithaca, embarks on a perilous journey to return home after the Trojan War."}
            };

            modelBuilder.Entity<Show>().HasData(shows);

            var users = new List<User>()
            {
                new User { Id = Guid.Parse("850b3567-e7e4-4bd1-a1a6-ed802f68cd46"), Name = "Admin", Role = Role.Admin },
                new User { Id = Guid.Parse("e5d5c3ea-a7ed-4dbc-8091-86a548c78a12"), Name = "User", Role = Role.User },
            };

            modelBuilder.Entity<User>().HasData(users);
        }

    }
}
