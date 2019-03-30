using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.Logic.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(string email, string subject, string bodyMessage);
    }
}
