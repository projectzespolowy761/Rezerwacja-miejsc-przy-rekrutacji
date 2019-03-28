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

namespace ReservationPlaces.Logic.Services
{
	public class ReservationServices: Interfaces.IReservationServices
	{
	    private  ReservationRepository reservationRepository;

        public ReservationServices()
	    {
            DesignTimeDbContextFactory dbContext=new DesignTimeDbContextFactory();
	        ReservationPlacesDataContext data=dbContext.CreateDbContext(new []{"-a"});
	        reservationRepository = new ReservationRepository(data);

	    }

        public Task<bool> AddReservation(IReservationDAL mReservationDal)
        {
            if (reservationRepository.CheckData(mReservationDal.StartVisit, mReservationDal.EndVisit))
            {
                reservationRepository.Add(mReservationDal);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
	    public Task CheckReservation(IReservationDAL mReservationDal)
	    {
            
	        reservationRepository.Get(mReservationDal);
	        return Task.CompletedTask;
	    }

	    public  IEnumerable GetAllReservations()
	    {
	        return reservationRepository.GetAll();
        }
    }
}
