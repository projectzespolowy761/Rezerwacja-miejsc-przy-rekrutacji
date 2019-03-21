using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.Logic.Interfaces
{
    public interface IAdminSettingsBLL
    {
         int Id { get; set; }
         string UserId { get; set; }
        DateTime StartPeriod { get; set; }
        DateTime EndPeriod { get; set; }
        int Interval { get; set; }
        DateTime OpenHour { get; set; }
        DateTime CloseHour { get; set; }
    }
}
