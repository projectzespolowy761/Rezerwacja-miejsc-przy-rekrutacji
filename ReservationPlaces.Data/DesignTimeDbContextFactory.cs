using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ReservationPlaces.Common;

namespace ReservationPlaces.Data
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReservationPlacesDataContext>
	{
		public ReservationPlacesDataContext CreateDbContext(string[] args)
		{

			var builder = new DbContextOptionsBuilder<ReservationPlacesDataContext>();
			var connectionString = ConstDbString.ConnectionStringDb;
			builder.UseSqlServer(connectionString);
			return new ReservationPlacesDataContext(builder.Options);
		}
	}
}
