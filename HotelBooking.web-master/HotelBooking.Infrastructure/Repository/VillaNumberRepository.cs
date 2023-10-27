﻿using HotelBooking.Application.SharedInterfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repository
{
	public class VillaNumberRepository : GenericRepository<VillaNumber>, IVillaNumberRepository
	{
		ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db):base(db)
        {
			_db = db;
        }
        public void Save()
		{
			_db.SaveChanges();
		}
		public void Update(VillaNumber villaNumber)
		{
			_db.VillaNumbers.Update(villaNumber);
		}
	}
}