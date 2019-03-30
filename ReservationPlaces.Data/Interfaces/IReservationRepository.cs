
using System;

namespace ReservationPlaces.Data.Interfaces
{
	public interface IReservationRepository : IRepository<IReservationDAL>
	{
		IReservationDAL GetByUserId(string UserId);
		bool CheckData(DateTime StartVisit, DateTime EndVisit);
	}
}
