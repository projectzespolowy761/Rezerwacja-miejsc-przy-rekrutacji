using ReservationPlaces.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReservationPlaces.Data.Models
{
	[Table("Reservation")]
	public class ReservationDAL : IReservationDAL
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(450)]
		public string UserId { get; set; }
		public DateTime ReservationDate { get; set; }
	}
}
