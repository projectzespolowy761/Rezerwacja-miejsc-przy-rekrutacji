using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReservationPlaces.Data.Models;

namespace ReservationPlaces.Data
{
   public class AdminSettingsDataContext:DbContext
    {
        public AdminSettingsDataContext(DbContextOptions<AdminSettingsDataContext> conn) : base(conn)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        //entities
        public DbSet<AdminSettingsDAL> Settings { get; set; }
    }
}
