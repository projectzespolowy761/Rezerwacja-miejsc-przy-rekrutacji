using Microsoft.EntityFrameworkCore;
using ReservationPlaces.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.Data
{
	public class ReservationPlacesDataContext : DbContext
	{
		public ReservationPlacesDataContext(DbContextOptions<ReservationPlacesDataContext> conn) : base(conn)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}

		//entities
		public DbSet<ReservationDAL> Reservation { get; set; }
		public DbSet<AdminSettingsDAL> AdminSettings { get; set; }
	}
}
