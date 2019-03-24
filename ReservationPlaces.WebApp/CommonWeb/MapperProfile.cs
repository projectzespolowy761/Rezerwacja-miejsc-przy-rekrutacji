using AutoMapper;
using ReservationPlaces.Data.Models;
using ReservationPlaces.Logic.Models;
using ReservationPlaces.WebApp.Models;
using System.Collections.Generic;

namespace ReservationPlaces.WebApp.CommonWeb
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<ReservationDAL, ReservationBLL>();
			CreateMap<ReservationBLL, ReservationDAL>();


		}
	}
}