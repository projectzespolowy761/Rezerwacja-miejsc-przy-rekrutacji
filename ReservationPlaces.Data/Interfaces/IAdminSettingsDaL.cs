using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.Data.Interfaces
{
    interface IAdminSettingsDAL	: IParrentModel
    {
        string UserId { get; set; }
        DateTime StartPeriod { get; set; }
        DateTime EndPeriod { get; set; }
        int Interval { get; set; }
        DateTime OpenHour { get; set; }
        DateTime CloseHour { get; set; }
    }
}
