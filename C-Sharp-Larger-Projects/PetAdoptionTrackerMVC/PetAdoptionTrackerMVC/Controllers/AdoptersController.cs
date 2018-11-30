using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetAdoptionTrackerMVC.DAL;
using PetAdoptionTrackerMVC.Models;

namespace PetAdoptionTrackerMVC.Controllers
{
    public class AdoptersController : Controller
    {
        private PetAdoptionContext db = new PetAdoptionContext();

        // GET: Adopters
        public ActionResult Index()
        {
            return View(db.Adopters.ToList());
        }

        // GET: Adopters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopter adopter = db.Adopters.Find(id);
            if (adopter == null)
            {
                return HttpNotFound();
            }
            return View(adopter);
        }

        // GET: Adopters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adopters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,EmailAddress")] Adopter adopter)
        {
            if (ModelState.IsValid)
            {
                db.Adopters.Add(adopter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adopter);
        }

        // GET: Adopters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopter adopter = db.Adopters.Find(id);
            if (adopter == null)
            {
                return HttpNotFound();
            }
            return View(adopter);
        }

        // POST: Adopters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,EmailAddress")] Adopter adopter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adopter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adopter);
        }

        // GET: Adopters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopter adopter = db.Adopters.Find(id);
            if (adopter == null)
            {
                return HttpNotFound();
            }
            return View(adopter);
        }

        // POST: Adopters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adopter adopter = db.Adopters.Find(id);
            db.Adopters.Remove(adopter);
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
