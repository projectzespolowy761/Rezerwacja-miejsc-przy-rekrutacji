using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ReservationPlaces.WebApp.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {

        public void SendEmail(string email, string subject, string bodyMessage)
        {
            var fromAddress = new MailAddress("bartwarzik@gmail.com", "ReserwationPlaces");
            var toAddress = new MailAddress(email);
            const string fromPassword = "bartwarzik101999";

           var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
			using (var message = new MailMessage(fromAddress, toAddress)
			{
				IsBodyHtml = true,
               Subject = subject,
                Body = bodyMessage
            })
            
            smtp.Send(message);
            
        }
    }
}

