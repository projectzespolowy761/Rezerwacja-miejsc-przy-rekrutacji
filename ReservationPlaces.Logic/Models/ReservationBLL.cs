using ReservationPlaces.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.Logic.Models
{
	public class ReservationBLL : IReservationBLL
	{
		public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime StartVisit { get; set; }
        public DateTime EndVisit { get; set; }
        public string Email { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Pesel { get; set; }
	}
}
