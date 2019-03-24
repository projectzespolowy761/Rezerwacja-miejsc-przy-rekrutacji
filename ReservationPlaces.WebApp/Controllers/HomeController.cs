using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReservationPlaces.Data.Models;
using ReservationPlaces.Logic.Services;

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
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PowerUser")]
        public async Task<IActionResult> Post([FromBody]string name)
		{
            
		    string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			await _reservationServices.AddReservation(new ReservationDAL() { Id = 2,ReservationDate=new DateTime(),UserId= userId });
		    return Ok();
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet]
		public IEnumerable<string> GetGet()
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

	}
}