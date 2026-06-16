using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Data
{
    public class AbsoluteCinemaAuthDbContext : IdentityDbContext
    {
        public AbsoluteCinemaAuthDbContext(DbContextOptions<AbsoluteCinemaAuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = "4280d803-51d9-4ea8-ab6c-dfb0db9c5920";
            var admin = "30181g304-h9b2-4ea8-ab6c-dfb0db9c5920";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = user,
                    Name = "User",
                    NormalizedName = "User".ToUpper(),
                    ConcurrencyStamp = user
                },
                new IdentityRole
                {
                    Id = admin,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = admin
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
