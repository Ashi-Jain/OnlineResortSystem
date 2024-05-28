using OnlineResortSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineResortSystem.Controllers
{
    public class CustomersController : Controller
    {
        private ResortDbEntities dbEntities = new ResortDbEntities();
        // GET: Customers
        public ActionResult Index()
        {
            var customer = dbEntities.Customers.ToList();
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var customer = dbEntities.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {

                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    dbEntities.Customers.Add(customer);
                    dbEntities.SaveChanges();
                return RedirectToAction("Index");
            }
               
            
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var customer = dbEntities.Customers.Find(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var existingCustomer = dbEntities.Customers.Find(id);
                    if (existingCustomer == null)
                    {
                        return HttpNotFound();
                    }

                    existingCustomer.CustomerID = customer.CustomerID;
                    existingCustomer.CustomerPhoneNumber = customer.CustomerPhoneNumber;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.CustomerCheckIn=customer.CustomerCheckIn;
                    existingCustomer.CustomerCheckOut=customer.CustomerCheckOut;

                    dbEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(customer);
           
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var customer=dbEntities.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {

                // TODO: Add delete logic here
                if (id == null)
                {
                    return HttpNotFound();
                }
                var customer = dbEntities.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                dbEntities.Customers.Remove(customer);
                dbEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }
}
