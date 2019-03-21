using System;

namespace ReservationPlaces.Data.Interfaces
{
	public interface IReservationDAL : IParrentModel
	{
		string UserId { get; set; }
		DateTime ReservationDate { get; set; }
	}
}
