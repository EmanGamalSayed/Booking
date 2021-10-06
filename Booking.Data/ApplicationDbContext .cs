using Booking.Core.Models;
using Booking.Core.Models.Auth;
using Booking.Data.DataInitializer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Booking.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        private readonly IDataInitializer _dataInitializer;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDataInitializer dataInitializer)
            : base(options)
        {
            _dataInitializer = dataInitializer;
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Trip> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Seed
            builder.Entity<Role>().HasData(_dataInitializer.SeedRoles());
            builder.Entity<User>().HasData(_dataInitializer.SeedUsers());
            builder.Entity<UserRole>().HasData(_dataInitializer.SeedUserRoles());
            builder.Entity<Trip>().HasData(_dataInitializer.SeedTrips());
            #endregion
            base.OnModelCreating(builder);

        }

    }
}
