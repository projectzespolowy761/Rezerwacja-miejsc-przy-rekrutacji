using ReservationPlaces.Data.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationPlaces.Data.Repositories
{
	public class AdminSettingsRepository : IAdminSettingsRepository
	{

		private readonly ReservationPlacesDataContext _context;
		public AdminSettingsRepository(ReservationPlacesDataContext context)
		{
			_context = context;
		}

		public int Add(IAdminSettingsDAL item)
		{
			throw new NotImplementedException();
		}

		public void AddMany(IEnumerable<IAdminSettingsDAL> items)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IAdminSettingsDAL Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable GetAll()
		{
			throw new NotImplementedException();
		}

		public void Update(IAdminSettingsDAL item)
		{
			throw new NotImplementedException();
		}
	}
}
