﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReservationPlaces.Data.Models;
using ReservationPlaces.Logic.Interfaces;
using ReservationPlaces.Logic.Services;
using ReservationPlaces.WebApp.Models;
using ReservationPlaces.WebApp.Services;

namespace ReservationPlaces.WebApp.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("[controller]/[action]")]
	public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PowerUser")]
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

	
		
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost]
		public IEnumerable<string> Post([FromBody]string name)
		{
		    ReservationDAL reservation =new ReservationDAL();
		    reservation.Id = 1;
            reservation.ReservationDate=DateTime.Now;
		    reservation.UserId = "213";
            ReservationServices services=new ReservationServices();
		    services.AddReservation(reservation);
		    string userid = User.FindFirst("id").Value;
            _userManager.GetUserId(User);
			return new string[] { "John Doe", "Jane Doe" };
		}

		[HttpGet]
		public IEnumerable<string> GetGet([FromBody]string name)
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

	}
}