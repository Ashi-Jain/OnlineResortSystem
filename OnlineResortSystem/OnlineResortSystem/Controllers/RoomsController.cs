using OnlineResortSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineResortSystem.Controllers
{
    public class RoomsController : Controller
    {
        private ResortDbEntities dbEntities = new ResortDbEntities();
        // GET: Rooms
        public ActionResult Index()
        {
            var room = dbEntities.Rooms.ToList();
            return View(room);
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var room = dbEntities.Rooms.Find(id);
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        public ActionResult Create(Room room)
        {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    dbEntities.Rooms.Add(room);
                    dbEntities.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(room);   
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var room = dbEntities.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Room room)
        {

                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var existingRoom = dbEntities.Rooms.Find(id);
                    if (existingRoom == null)
                    {
                        return HttpNotFound();
                    }

                    existingRoom.RoomID = room.RoomID;
                    existingRoom.RoomName = room.RoomName;
                    existingRoom.Price = room.Price;
                    existingRoom.Available = room.Available;

                    dbEntities.SaveChanges();

                    return RedirectToAction("Index");
                }
            else
            {
                return View(room);
            }
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var room = dbEntities.Rooms.Find(id);
            if(room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {

            // TODO: Add delete logic here
            if (id == null)
            {
                return HttpNotFound();
            }
            var room = dbEntities.Rooms.Find(id);
            if(room == null)
            {
                return HttpNotFound();
            }
            else
            {
                dbEntities.Rooms.Remove(room);
                dbEntities.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
