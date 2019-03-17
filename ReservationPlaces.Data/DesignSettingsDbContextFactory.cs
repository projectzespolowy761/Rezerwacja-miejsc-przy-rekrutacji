using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ReservationPlaces.Common;

namespace ReservationPlaces.Data
{
    public class DesignSettingsDbContextFactory : IDesignTimeDbContextFactory<AdminSettingsDataContext>
    {
        public AdminSettingsDataContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<AdminSettingsDataContext>();
            var connectionString = ConstDbString.ConnectionStringDb;
            builder.UseSqlServer(connectionString);
            return new AdminSettingsDataContext(builder.Options);
        }
    }
}
