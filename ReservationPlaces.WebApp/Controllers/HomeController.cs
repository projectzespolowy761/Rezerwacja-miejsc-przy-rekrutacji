using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReservationPlaces.WebApp.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("[controller]/[action]")]
	public class HomeController : Controller
    {
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PowerUser")]
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

	
		
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[Authorize(Roles = "Administrator")]
		[HttpPost]
		public IEnumerable<string> Post([FromBody]string name)
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

		[HttpGet]
		public IEnumerable<string> GetGet([FromBody]string name)
		{
			return new string[] { "John Doe", "Jane Doe" };
		}

	}
}