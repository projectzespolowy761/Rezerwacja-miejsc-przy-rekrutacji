using ReservationPlaces.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservationPlaces.Common;
using ReservationPlaces.Data;
using ReservationPlaces.Data.Interfaces;

namespace ReservationPlaces.Logic.Services
{
	public class ReservationServices
	{
	    private  ReservationRepository _context;
        public ReservationServices()
	    {
            DesignTimeDbContextFactory dbContext=new DesignTimeDbContextFactory();
	        ReservationPlacesDataContext data=dbContext.CreateDbContext(new []{"-a"});
            //private ReservationPlacesDataContext context = new ReservationPlacesDataContext();
             _context = new ReservationRepository(data);       
        }

	    public void AddReservation(IReservationDAL mReservationDal)
	    {
	        _context.Add(mReservationDal);
	    }

	}
}
