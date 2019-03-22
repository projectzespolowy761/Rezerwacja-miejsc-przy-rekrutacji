using System.ComponentModel.DataAnnotations;

namespace ReservationPlaces.WebApp.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
