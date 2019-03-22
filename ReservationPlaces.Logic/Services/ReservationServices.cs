using AutoMapper;
using ReservationPlaces.Data.Interfaces;
using ReservationPlaces.Data.Models;
using ReservationPlaces.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.Logic.Services
{
	public class ReservationServices : IReservationServices
	{
		private readonly IReservationRepository _reservationRepo;
		private readonly IMapper _mapper;
		public ReservationServices(IReservationRepository repo, IMapper mapper)
		{
			_reservationRepo = repo;
			_mapper = mapper;
		}

		public void AddReservation(IReservationBLL article)
		{
			_reservationRepo.Add(_mapper.Map<ReservationDAL>(article));
		}
	}
}
