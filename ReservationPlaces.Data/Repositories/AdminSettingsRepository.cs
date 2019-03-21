using ReservationPlaces.Data.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReservationPlaces.Data.Repositories
{
	class AdminSettingsRepository : IAdminSettingsRepository
	{

		private readonly ReservationPlacesDataContext _context;
		public AdminSettingsRepository(ReservationPlacesDataContext context)
		{
			_context = context;
		}

		public int Add(IAdminSettingsDAL item)
		{
            var data = _context.Add(item);
            _context.SaveChanges();
            _context.Entry(item).State = EntityState.Detached;
            return data.Entity.Id;
        }

		public void AddMany(IEnumerable<IAdminSettingsDAL> items)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
		    var item = await _context.AdminSettings.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
		    _context.Remove(item);
		    _context.SaveChanges();
        }

		public IAdminSettingsDAL Get(int id)
		{
		    _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		    return _context.AdminSettings.FirstOrDefault(p => p.Id == id);
        }

		public IEnumerable GetAll()
		{
		    _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		    return _context.AdminSettings.ToList();
        }

		public void Update(IAdminSettingsDAL item)
		{
		    _context.Update(item);
		    _context.SaveChanges();
		    _context.Entry(item).State = EntityState.Detached;
        }
	}
}
