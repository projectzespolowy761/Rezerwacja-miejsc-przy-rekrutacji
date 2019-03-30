using AutoMapper;
using ReservationPlaces.Data.Models;
using ReservationPlaces.Logic.Models;
using ReservationPlaces.WebApp.Models;
using System.Collections.Generic;
using ReservationPlaces.WebApp.Models.ReservationsViewModels;
using ReservationPlaces.Data.Interfaces;

namespace ReservationPlaces.WebApp.CommonWeb
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<ReservationDAL, ReservationBLL>();
			CreateMap<ReservationBLL, ReservationDAL>();
            CreateMap<ReservationViewModel, ReservationBLL>();
			CreateMap<ReservationDAL, IReservationDAL>();
			CreateMap<IReservationDAL, ReservationDAL>();
		}
	}
}