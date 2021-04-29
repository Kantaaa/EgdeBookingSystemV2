using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EgdeBookingSystemV2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgdeBookingSystemV2.Data
{
    public class EgdeBookingSystemConnection : IdentityDbContext
    {
        public EgdeBookingSystemConnection()
        {
        }

        public EgdeBookingSystemConnection(DbContextOptions<EgdeBookingSystemConnection> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Location> Locations { get; set; }

        //Dette er Eriks lille prosjekt som krangler med IdentityUsers. Kommer forhåpentligvis tilbake til løsning. 
        //
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Booking>().ToTable("Booking");
        //    modelBuilder.Entity<Category>().ToTable("Category");
        //    modelBuilder.Entity<Equipment>().ToTable("Equipment");
        //    modelBuilder.Entity<Location>().ToTable("Lacation");

        //    modelBuilder.Entity<TUserRole>()
        //    .HasKey(r => new { r.UserId, r.RoleId })
        //    .ToTable("AspNetUserRoles");

        //    modelBuilder.Entity<TUserLogin>()
        //                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
        //                .ToTable("AspNetUserLogins");
        //}
    }

}