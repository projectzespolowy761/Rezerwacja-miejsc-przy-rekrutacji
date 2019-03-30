using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.EmailService
{
    public interface IEmailSender
    {
       void SendEmail(string email, string subject, string bodyMessage);
    }
}
