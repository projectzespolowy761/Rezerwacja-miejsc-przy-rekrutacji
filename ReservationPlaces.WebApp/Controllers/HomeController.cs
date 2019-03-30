using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationPlaces.Logic.Interfaces;
using ReservationPlaces.Logic.Models;
using ReservationPlaces.WebApp.Models.ReservationsViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReservationPlaces.WebApp.Controllers
{
	[Route("[controller]/[action]")]
	public class HomeController : Controller
	{
		private readonly IReservationServices _reservationServices;
		private readonly IMapper _mapper;

		public HomeController(IReservationServices reservationServices, IMapper mapper)
		{
			_reservationServices = reservationServices;
			_mapper = mapper;
		}


		[HttpGet]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PowerUser")]
		public IEnumerable GetAllReservations()
		{
			return _reservationServices.GetAllReservations();
		}



		[HttpPost]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PowerUser")]
		public async Task<IActionResult> AddReservation([FromBody]ReservationViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					model.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

					model.Email = User.FindFirst(ClaimTypes.Email)?.Value;

					model.StartVisit=new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
						.AddMilliseconds(Convert.ToInt64(model.DateStart))
						.ToLocalTime();

					model.EndVisit = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
						.AddMilliseconds(Convert.ToInt64(model.DateEnd))
						.ToLocalTime();

					bool allow = await _reservationServices.CheckReservation(model.StartVisit, model.EndVisit);
					if (allow)
					{
						await _reservationServices.AddReservation(_mapper.Map<ReservationViewModel, ReservationBLL>(model));
						return Ok();
					}
					else
					{
						ModelState.AddModelError(string.Empty, "Termin jest zajęty");
						return BadRequest(ModelState);
					}


				}
				return BadRequest(ModelState);
			}
			catch (Exception e)
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