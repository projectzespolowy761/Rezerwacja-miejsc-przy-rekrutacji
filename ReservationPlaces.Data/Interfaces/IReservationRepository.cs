
namespace ReservationPlaces.Data.Interfaces
{
	interface IReservationRepository : IRepository<IReservationDAL>
	{
		 IReservationDAL GetByUserId(string UserId);
	}
}
