using System;
using System.Collections.Generic;
using System.Text;
using ReservationPlaces.Logic.Interfaces;

namespace ReservationPlaces.Logic.Models
{
    class AdminSettingsBLL:IAdminSettingsBLL
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime StartPeriod { get; set; }
       public DateTime EndPeriod { get; set; }
       public int Interval { get; set; }
       public DateTime OpenHour { get; set; }
       public DateTime CloseHour { get; set; }       
    }
}
