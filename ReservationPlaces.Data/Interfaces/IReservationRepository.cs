
using System;
using System.Threading.Tasks;

namespace ReservationPlaces.Data.Interfaces
{
	public interface IReservationRepository : IRepository<IReservationDAL>
	{
		IReservationDAL GetByUserId(string UserId);
		bool CheckData(DateTime StartVisit, DateTime EndVisit);
		IReservationDAL UserReservation(string UserId);

		Task<bool> DeleteReservation(string UserId);
	}
}
