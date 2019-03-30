using ReservationPlaces.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReservationPlaces.Data.Models
{
	[Table("Reservation")]
	public class ReservationDAL : IReservationDAL
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[MaxLength(450)]
		

		public string Name { get; set; }
		public string Surname { get; set; }
		public string Pesel { get; set; }
		public DateTime StartVisit { get; set; }
	    public DateTime EndVisit { get; set; }
        public string Email { get; set; }
		public string UserId { get; set; }
	}
}
