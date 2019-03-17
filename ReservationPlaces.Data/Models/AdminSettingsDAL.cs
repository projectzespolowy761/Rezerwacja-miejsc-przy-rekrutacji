using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReservationPlaces.Data.Interfaces;

namespace ReservationPlaces.Data.Models
{
    [Table("Settings")]
    public class AdminSettingsDAL : IAdminSettingsDAL
    {
        [Key]
      public int Id { get; set; }
        [MaxLength(450)]
       public string UserId { get; set; }
       public DateTime StartPeriod { get; set; }
       public DateTime EndPeriod { get; set; }
       public  int Interval { get; set; }
       public DateTime OpenHour { get; set; }
       public DateTime CloseHour { get; set; }
    }
}