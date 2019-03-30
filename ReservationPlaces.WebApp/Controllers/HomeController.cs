using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using ReservationPlaces.Data.Interfaces;
using ReservationPlaces.Data.Models;
using ReservationPlaces.Logic.Interfaces;
using ReservationPlaces.Logic.Models;
using ReservationPlaces.Logic.Services;
using ReservationPlaces.WebApp.Models.ReservationsViewModels;

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
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PowerUser")]
        public  IEnumerable GetAllReservations()
		{
		    return _reservationServices.GetAllReservations();
		}

	
		
		[HttpPost]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PowerUser")]
        public async Task<IActionResult> Post([FromForm]ReservationViewModel model)
		{
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                string email = User.FindFirst(ClaimTypes.Email)?.Value;
                bool allow = await _reservationServices.CheckReservation(model.StartVisit,model.EndVisit);
                if (allow)
                {
                  var res= Mapper.Map(model, new ReservationBLL());
                    await _reservationServices.AddReservation(res);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
        }
            catch
            {
                return BadRequest();
            }

        }

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet]
		public IEnumerable<string> GetGet()
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

	}
}