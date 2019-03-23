using ReservationPlaces.Data.Repositories;
using System;
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
	public class ReservationServices:IReservationServices
	{
	    private  ReservationRepository reservationRepository;

        public ReservationServices()
	    {
            DesignTimeDbContextFactory dbContext=new DesignTimeDbContextFactory();
	        ReservationPlacesDataContext data=dbContext.CreateDbContext(new []{"-a"});
	        reservationRepository = new ReservationRepository(data);

	    }

	    public Task AddReservation(IReservationDAL mReservationDal)
	    {
            reservationRepository.Add(mReservationDal);
           return Task.CompletedTask;
	    }

	}
}
