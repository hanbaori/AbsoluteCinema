using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AbsoluteCinema.Data
{
    public class AbsoluteCinemaContext : DbContext
    {
        public DbSet<Show> Shows { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Booking> Booking { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;
                  Initial Catalog=AbsoluteCinema;
                  Integrated Security=True;
                  Connect Timeout=30;
                  Encrypt=False;
                  TrustServerCertificate=True;"
            );

        }
    }
}
