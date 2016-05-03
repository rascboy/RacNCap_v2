using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RacNCap_V2.Models;

namespace RacNCap_V2.Controllers
{
    public class TrucksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trucks
        public ActionResult Index()
        {
            return View(db.TrucksViewModels.ToList());
        }

        // GET: Trucks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrucksViewModels trucksViewModels = db.TrucksViewModels.Find(id);
            if (trucksViewModels == null)
            {
                return HttpNotFound();
            }
            return View(trucksViewModels);
        }

        // GET: Trucks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrucksViewModelsId,Make,Model")] TrucksViewModels trucksViewModels)
        {
            if (ModelState.IsValid)
            {
                db.TrucksViewModels.Add(trucksViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trucksViewModels);
        }

        // GET: Trucks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrucksViewModels trucksViewModels = db.TrucksViewModels.Find(id);
            if (trucksViewModels == null)
            {
                return HttpNotFound();
            }
            return View(trucksViewModels);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrucksViewModelsId,Make,Model")] TrucksViewModels trucksViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trucksViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trucksViewModels);
        }

        // GET: Trucks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrucksViewModels trucksViewModels = db.TrucksViewModels.Find(id);
            if (trucksViewModels == null)
            {
                return HttpNotFound();
            }
            return View(trucksViewModels);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrucksViewModels trucksViewModels = db.TrucksViewModels.Find(id);
            db.TrucksViewModels.Remove(trucksViewModels);
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
