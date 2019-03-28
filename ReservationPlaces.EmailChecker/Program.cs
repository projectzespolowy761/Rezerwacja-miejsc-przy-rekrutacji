using ReservationPlaces.Data;
using ReservationPlaces.Data.Repositories;
using System;
using System.Timers;
using ReservationPlaces.Logic.Services;

namespace ReservationPlaces.EmailChecker
{
    class Program
    {
        private static ReservationRepository reservationRepository;
        private static EmailSender emailSender;
        static void Main(string[] args)
        {
            DesignTimeDbContextFactory dbContext = new DesignTimeDbContextFactory();
            EmailSender emailSender=new EmailSender();
            ReservationPlacesDataContext data = dbContext.CreateDbContext(new[] {"-a"});
            reservationRepository = new ReservationRepository(data);
            Timer aTimer = new System.Timers.Timer();
            aTimer.Interval = 60000;
            aTimer.Enabled = true;
            aTimer.Start();
            aTimer.Elapsed += new ElapsedEventHandler(RunEvent);
            while (true)
            {

            }
        }

        public static void RunEvent(object source, ElapsedEventArgs e)
        {
            var variable = reservationRepository.CheckSender(DateTime.Now);
            if (variable!=null)
            {
              var record=  reservationRepository.GetByUserId(variable);
                emailSender.SendEmail(record.ToString(),"Przypomnienie","Jutro twoja wizyta o"+DateTime.Now+1);
            }
        }
    }
}
