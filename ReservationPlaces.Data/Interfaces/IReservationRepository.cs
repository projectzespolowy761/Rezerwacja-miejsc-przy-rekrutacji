
namespace ReservationPlaces.Data.Interfaces
{
	public interface IReservationRepository : IRepository<IReservationDAL>
	{
		 IReservationDAL GetByUserId(string UserId);
	}
}
