using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.Logic.Interfaces
{
	public interface IReservationBLL
	{
		int Id { get; set; }
         string UserId { get; set; }
         DateTime StartVisit { get; set; }
         DateTime EndVisit { get; set; }
		 string Name { get; set; }
		 string Surname { get; set; }
		 string Pesel { get; set; }
		string Email { get; set; }
    }
}
