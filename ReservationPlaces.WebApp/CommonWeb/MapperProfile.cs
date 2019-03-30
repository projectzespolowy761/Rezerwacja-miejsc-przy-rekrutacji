using AutoMapper;
using ReservationPlaces.Data.Models;
using ReservationPlaces.Logic.Models;
using ReservationPlaces.WebApp.Models;
using System.Collections.Generic;
using ReservationPlaces.WebApp.Models.ReservationsViewModels;

namespace ReservationPlaces.WebApp.CommonWeb
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<ReservationDAL, ReservationBLL>();
			CreateMap<ReservationBLL, ReservationDAL>();
            CreateMap<ReservationViewModel, ReservationBLL>();

        }
	}
}