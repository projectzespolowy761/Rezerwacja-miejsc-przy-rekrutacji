using Microsoft.EntityFrameworkCore;
using ReservationPlaces.Data.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationPlaces.Data.Repositories
{
	public class ReservationRepository : IReservationRepository
	{

		private readonly ReservationPlacesDataContext _context;
		public ReservationRepository(ReservationPlacesDataContext context)
		{
			_context = context;
		}

		public int Add(IReservationDAL item)
		{
			var data = _context.Add(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
			return data.Entity.Id;
		}

		public void AddMany(IEnumerable<IReservationDAL> items)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(int id)
		{
			var item = await _context.Reservation.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
			_context.Remove(item);
			_context.SaveChanges();
		}

		public IReservationDAL Get(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Reservation.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Reservation.ToList();
		}

		public IReservationDAL GetByUserId(string UserId)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Reservation.FirstOrDefault(p => p.UserId == UserId);
		}

		public void Update(IReservationDAL item)
		{
			_context.Update(item);
			_context.SaveChanges();
			_context.Entry(item).State = EntityState.Detached;
		}
	}
}
