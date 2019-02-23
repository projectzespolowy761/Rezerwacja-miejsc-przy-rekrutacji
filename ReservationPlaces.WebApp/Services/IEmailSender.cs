using System.Threading.Tasks;

namespace ReservationPlaces.WebApp.Services
{
    public interface IEmailSender
    {
        void SendEmail(string email, string subject, string bodyMessage);
    }
}
