using System;

namespace ReservationPlaces.Data.Interfaces
{
	public interface IReservationDAL : IParrentModel
	{
		string UserId { get; set; }
		DateTime StartVisit { get; set; }
	    DateTime EndVisit { get; set; }
        string Email { get; set; }
    }
}
