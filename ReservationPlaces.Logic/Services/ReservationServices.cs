using ReservationPlaces.Data.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservationPlaces.Common;
using ReservationPlaces.Data;
using ReservationPlaces.Data.Interfaces;
using ReservationPlaces.Data.Models;
using ReservationPlaces.Logic.Interfaces;
using ReservationPlaces.Logic.Models;

namespace ReservationPlaces.Logic.Services
{
	public class ReservationServices : IReservationServices
	{
	    private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

		public ReservationServices(IReservationRepository reservationRepository, IMapper mapper)
	    {
			_reservationRepository = reservationRepository;
			_mapper = mapper;
		}

        public Task<bool> AddReservation(ReservationBLL mReservationDal)
        {

            if (_reservationRepository.CheckData(mReservationDal.StartVisit, mReservationDal.EndVisit))
            {
				_reservationRepository.Add(_mapper.Map<ReservationBLL, IReservationDAL>(mReservationDal));

                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
	    public Task<bool> CheckReservation(DateTime Start, DateTime End)
	    {     
	        return Task.FromResult(_reservationRepository.CheckData( Start,  End)); 
	    }

	    public  IEnumerable GetAllReservations()
	    {
	        return _reservationRepository.GetAll();
        }
    }
}
