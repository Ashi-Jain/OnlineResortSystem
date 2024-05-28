using OnlineResortSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineResortSystem.Controllers
{
    public class AmenitiesController : Controller
    {
        private ResortDbEntities dbEntities = new ResortDbEntities();

        // GET: Amenities
        public ActionResult Index()
        {
            var amenities = dbEntities.Amenities.ToList();
            return View(amenities);
        }

        // GET: Amenities/Details/5
        public ActionResult Details(int id)
        {
            var amenity = dbEntities.Amenities.Find(id);
            if(amenity == null)
            {
                return HttpNotFound();
            }
            return View(amenity);
        }

        // GET: Amenities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        [HttpPost]
        public ActionResult Create(Amenity amenity)
        {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    dbEntities.Amenities.Add(amenity);
                    dbEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(amenity);
        }

        // GET: Amenities/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Amenity amenity = dbEntities.Amenities.Find(id);
            if (amenity == null)
            {
                return HttpNotFound();
            }
            return View(amenity);
        }

        // POST: Amenities/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Amenity amenity)
        {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var existingAmenity = dbEntities.Amenities.Find(id);
                    if (existingAmenity == null)
                    {
                        return HttpNotFound();
                    }
                    existingAmenity.AmenityId = amenity.AmenityId;
                    existingAmenity.AmenityName = amenity.AmenityName;
                    existingAmenity.AmenityDescription = amenity.AmenityDescription;
                    existingAmenity.AmenityCategory = amenity.AmenityCategory;

                    dbEntities.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(amenity);
                }
        }

        // GET: Amenities/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var amenity = dbEntities.Amenities.Find(id);
            if (amenity == null)
            {
                return HttpNotFound();
            }
            return View(amenity);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var amenity = dbEntities.Amenities.Find(id);
                if(amenity == null)
                {
                    return HttpNotFound();
                }
                dbEntities.Amenities.Remove(amenity);
                dbEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
