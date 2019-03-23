﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReservationPlaces.Data.Models;
using ReservationPlaces.Logic.Interfaces;
using ReservationPlaces.Logic.Services;
using ReservationPlaces.WebApp.Models;
using ReservationPlaces.WebApp.Services;

namespace ReservationPlaces.WebApp.Controllers
{
	[Route("[controller]/[action]")]
	public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private IHttpContextAccessor _httpContext;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContext,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _httpContext = httpContext;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PowerUser")]
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

	
		
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost]
		public async Task<IActionResult> Post([FromBody]string name)
		{
            
		    string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ReservationDAL reservation =new ReservationDAL();
            reservation.ReservationDate=DateTime.Now;
		    reservation.UserId = userId;
            ReservationServices services=new ReservationServices();
		    await services.AddReservation(reservation);
		    string userid = User.FindFirst("id").Value;
            _userManager.GetUserId(User);
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