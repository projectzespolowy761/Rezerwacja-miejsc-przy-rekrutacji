﻿using ReservationPlaces.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlaces.Logic.Models
{
	class ReservationBLL : IReservationBLL
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public DateTime ReservationDate { get; set; }
	}
}
