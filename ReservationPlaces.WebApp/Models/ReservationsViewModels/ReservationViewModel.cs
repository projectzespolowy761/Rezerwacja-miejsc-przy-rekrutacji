using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationPlaces.WebApp.Models.ReservationsViewModels
{
    public class ReservationViewModel
	{

		public string Email { get; set; }
		public string UserId { get; set; }

		[Required(ErrorMessage = "Please enter the user's first name.")]
		[StringLength(50, ErrorMessage = "The First Name must be less than {1} characters.")]
		[Display(Name = "First Name:")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please enter the user's last name.")]
		[StringLength(50, ErrorMessage = "The Last Name must be less than {1} characters.")]
		[Display(Name = "Last Name:")]
		public string Surname { get; set; }
		[Required]
		[StringLength(11)]
		public string Pesel { get; set; }
		public DateTime StartVisit { get; set; }
        public DateTime EndVisit { get; set; }

		public string  DateStart { get; set; }

		public string  DateEnd { get; set; }
	}
}
