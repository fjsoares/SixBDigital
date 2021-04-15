using System;
using Microsoft.EntityFrameworkCore;
using SimpleCrypto;
using SixBDigital.CarValeting.Core.Entities;

namespace SixBDigital.CarValeting.Infrastructure
{
    public class SixBDigitalCarValetingContext : DbContext
    {
        protected internal SixBDigitalCarValetingContext()
        {
        }

        public SixBDigitalCarValetingContext(DbContextOptions<SixBDigitalCarValetingContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(builder =>
            {
                builder.Property(x => x.Id).IsRequired().Metadata.IsPrimaryKey();
                builder.Property(x => x.BookingDateTime).IsRequired();
                builder.Property(x => x.Flexibility).IsRequired();
                builder.Property(x => x.VehicleSize).IsRequired();
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.ContactNumber).IsRequired();
                builder.Property(x => x.EmailAddress).IsRequired();
                builder.Property(x => x.Approved).IsRequired();
            });

            var creation = DateTime.UtcNow;

            var cryptoService = new PBKDF2();
            var salt = cryptoService.GenerateSalt();
            string hashedPassword = cryptoService.Compute("l7iM007iD9o", salt);

            modelBuilder.Entity<User>(builder =>
            {
                builder.Property(x => x.Id).IsRequired().Metadata.IsPrimaryKey();
                builder.Property(x => x.UserName).IsRequired();
                builder.Property(x => x.Password).IsRequired();
                builder.HasData(new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = hashedPassword,
                    Salt = salt,
                    CreatedAt = creation,
                    UpdatedAt = creation
                });
            });
        }
    }
}
