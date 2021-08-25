using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationAirData.Models;

namespace WebApplicationAirData.Controllers
{
    public class Opstilling_TableController : Controller
    {
        private Environmental_Data_2020Entities db = new Environmental_Data_2020Entities();

        // GET: Opstilling_Table
        public ActionResult Index()
        {
            var opstilling_Table = db.Opstilling_Table.Include(o => o.Maalested_Table);
            return View(opstilling_Table.ToList());
        }

        // GET: Opstilling_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opstilling_Table opstilling_Table = db.Opstilling_Table.Find(id);
            if (opstilling_Table == null)
            {
                return HttpNotFound();
            }
            return View(opstilling_Table);
        }

        // GET: Opstilling_Table/Create
        public ActionResult Create()
        {
            ViewBag.MaaleStedId = new SelectList(db.Maalested_Table, "MaaleStedId", "Navn");
            return View();
        }

        // POST: Opstilling_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpstillingId,Kode,MaaleStedId")] Opstilling_Table opstilling_Table)
        {
            if (ModelState.IsValid)
            {
                db.Opstilling_Table.Add(opstilling_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaaleStedId = new SelectList(db.Maalested_Table, "MaaleStedId", "Navn", opstilling_Table.MaaleStedId);
            return View(opstilling_Table);
        }

        // GET: Opstilling_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opstilling_Table opstilling_Table = db.Opstilling_Table.Find(id);
            if (opstilling_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaaleStedId = new SelectList(db.Maalested_Table, "MaaleStedId", "Navn", opstilling_Table.MaaleStedId);
            return View(opstilling_Table);
        }

        // POST: Opstilling_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpstillingId,Kode,MaaleStedId")] Opstilling_Table opstilling_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opstilling_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaaleStedId = new SelectList(db.Maalested_Table, "MaaleStedId", "Navn", opstilling_Table.MaaleStedId);
            return View(opstilling_Table);
        }

        // GET: Opstilling_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opstilling_Table opstilling_Table = db.Opstilling_Table.Find(id);
            if (opstilling_Table == null)
            {
                return HttpNotFound();
            }
            return View(opstilling_Table);
        }

        // POST: Opstilling_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opstilling_Table opstilling_Table = db.Opstilling_Table.Find(id);
            db.Opstilling_Table.Remove(opstilling_Table);
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
