using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReservationPlaces.Logic.Interfaces;
using ReservationPlaces.Logic.Models;
using ReservationPlaces.Logic.Services;
using ReservationPlaces.WebApp.Models;
using ReservationPlaces.WebApp.Services;

namespace ReservationPlaces.WebApp.Controllers
{
	[Route("[controller]/[action]")]
	public class HomeController : Controller
    {
		private readonly IReservationServices _reservationServices;

		public HomeController(IReservationServices reservationServices)
        {
			_reservationServices = reservationServices;
		}

		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

	
		
		[HttpPost]
		public IEnumerable<string> Post([FromBody]string name)
		{
			_reservationServices.AddReservation(new ReservationBLL() { Id = 2,ReservationDate=new DateTime(),UserId="asdas"});
			return new string[] { "John Doe", "Jane Doe" };
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet]
		public IEnumerable<string> GetGet()
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

	}
}