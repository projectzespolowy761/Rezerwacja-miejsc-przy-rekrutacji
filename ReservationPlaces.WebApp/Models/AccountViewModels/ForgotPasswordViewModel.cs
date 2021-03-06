﻿using System.ComponentModel.DataAnnotations;

namespace ReservationPlaces.WebApplication.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
