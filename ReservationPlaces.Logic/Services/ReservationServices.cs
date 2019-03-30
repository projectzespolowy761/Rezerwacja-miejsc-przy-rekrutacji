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
	public class ReservationServices: Interfaces.IReservationServices
	{
	    private  ReservationRepository reservationRepository;
        private readonly MapperConfiguration configuration;
        public ReservationServices()
	    {
            DesignTimeDbContextFactory dbContext=new DesignTimeDbContextFactory();
	        ReservationPlacesDataContext data=dbContext.CreateDbContext(new []{"-a"});
	        reservationRepository = new ReservationRepository(data);
            configuration = new MapperConfiguration(cfg => { cfg.CreateMap<IReservationDAL, ReservationDAL>(); });
        }

        public Task<bool> AddReservation(ReservationBLL mReservationDal)
        {

            if (reservationRepository.CheckData(mReservationDal.StartVisit, mReservationDal.EndVisit))
            {
                IMapper iMapper = configuration.CreateMapper();

                reservationRepository.Add(iMapper.Map<ReservationBLL, IReservationDAL>(mReservationDal));
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
	    public Task<bool> CheckReservation(DateTime Start, DateTime End)
	    {     
	        return Task.FromResult(reservationRepository.CheckData( Start,  End)); 
	    }

	    public  IEnumerable GetAllReservations()
	    {
	        return reservationRepository.GetAll();
        }
    }
}
