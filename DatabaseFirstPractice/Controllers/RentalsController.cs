using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseFirstPractice.Models;

namespace DatabaseFirstPractice.Controllers
{
    public class RentalsController : Controller
    {
        private DatabaseFirstPracticeContext db = new DatabaseFirstPracticeContext();

        // GET: Rentals
        public ActionResult Index()
        {
            var rentals = db.Rentals.Include(r => r.Customer).Include(r => r.Movies);
            return View(rentals.ToList());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentals rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            return View(rentals);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName");
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalId,RentalDate,CustomerId,MovieId")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                db.Rentals.Add(rentals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", rentals.CustomerId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", rentals.MovieId);
            return View(rentals);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentals rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", rentals.CustomerId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", rentals.MovieId);
            return View(rentals);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId,RentalDate,CustomerId,MovieId")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", rentals.CustomerId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title", rentals.MovieId);
            return View(rentals);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentals rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            return View(rentals);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rentals rentals = db.Rentals.Find(id);
            db.Rentals.Remove(rentals);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
