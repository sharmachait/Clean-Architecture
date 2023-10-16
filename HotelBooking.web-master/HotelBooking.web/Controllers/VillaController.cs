﻿using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Web.Controllers
{
    
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VillaController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var villa = _db.Villas.ToList();
            return View(villa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if(obj.Name==obj.Description)
            {
                ModelState.AddModelError("Description","Description and name can not be same.");
            }
            if(ModelState.IsValid)
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index","Villa");
            }
            else
            {
                return View(obj);
            }
        }
        [HttpGet]
        public IActionResult Update(int villaId)
        {
            Villa? villa = _db.Villas.FirstOrDefault(x => x.Id == villaId);
            //same as
            villa = _db.Villas.Find(villaId);
            if (villa == null)
            {
                return RedirectToAction("Error","Home");
            }
            return View(villa);
        }

		[HttpPost]
		public IActionResult Update(Villa obj)
		{
			if (ModelState.IsValid)
			{
				_db.Villas.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index", "Villa");
			}
			else
			{
				return View(obj);
			}
		}
        [HttpGet]
        public IActionResult Delete(int villaId)
        {
            Villa? villa=_db.Villas.FirstOrDefault(x=>x.Id== villaId);
            if(villa!=null)
                return View(villa);
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            var AlteredRows=_db.Villas.Where(x=>x.Id== villa.Id).ExecuteDelete();
            if (AlteredRows == 0)
            {
                return RedirectToAction("Error", "Home");
            }
            return RedirectToAction("Index");
        }
	}
}
