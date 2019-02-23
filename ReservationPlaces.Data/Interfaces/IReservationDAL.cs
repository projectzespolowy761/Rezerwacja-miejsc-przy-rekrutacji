using System;

namespace ReservationPlaces.Data.Interfaces
{
	interface IReservationDAL : IParrentModel
	{
		string UserId { get; set; }
		DateTime ReservationDate { get; set; }
	}
}
