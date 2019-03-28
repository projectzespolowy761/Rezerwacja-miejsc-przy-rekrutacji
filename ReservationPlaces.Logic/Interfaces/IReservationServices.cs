using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReservationPlaces.Data.Interfaces;

namespace ReservationPlaces.Logic.Interfaces
{
	public interface IReservationServices
	{
        Task<bool> AddReservation(IReservationDAL mReservationDal);
	    IEnumerable GetAllReservations();
	}
}
