﻿using Microsoft.EntityFrameworkCore;
using ReservationPlaces.Data.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationPlaces.Data.Models;
using AutoMapper;

namespace ReservationPlaces.Data.Repositories
{
	public class ReservationRepository : IReservationRepository
	{
		private readonly IMapper _mapper;
		private readonly ReservationPlacesDataContext _context;
		public ReservationRepository(ReservationPlacesDataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
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
        public IReservationDAL Get(IReservationDAL model)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Reservation.FirstOrDefault(p => p.StartVisit == model.StartVisit);
		}

		public IEnumerable GetAll()
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return _context.Reservation.ToList();
		}

        public bool CheckData(DateTime StartVisit, DateTime EndVisit)
        {
            if (_context.Reservation.Any(o=>o.StartVisit==StartVisit)&& _context.Reservation.Any(o => o.EndVisit == EndVisit))
            {
                return false;
            }

            return true;
        }
        public List<ReservationDAL> CheckSender()
        {
			List<ReservationDAL> datelList =
				_context.Reservation.Where(o => o.StartVisit.Date == DateTime.Today).ToList();
			return datelList;
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
