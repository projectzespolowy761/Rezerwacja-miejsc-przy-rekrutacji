using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.Logic.Interfaces
{
	public interface IReservationBLL
	{
		int Id { get; set; }
		string UserId { get; set; }
		DateTime ReservationDate { get; set; }
	}
}
