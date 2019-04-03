using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationPlaces.Data.Interfaces;
using ReservationPlaces.Logic.Models;

namespace ReservationPlaces.Logic.Interfaces
{
	public interface IReservationServices
	{
        Task<bool> AddReservation(ReservationBLL mReservationDal);
        Task<bool> CheckReservation(DateTime Start, DateTime End);
        IEnumerable GetAllReservations();
		ReservationBLL GetUserReservation(string UserId);

		Task<bool> DeleteReservation(string UserId);
	}
}
