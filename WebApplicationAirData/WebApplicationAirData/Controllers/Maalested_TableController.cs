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
    public class Maalested_TableController : Controller
    {
        private Environmental_Data_2020Entities db = new Environmental_Data_2020Entities();

        // GET: Maalested_Table
        public ActionResult Index()
        {
            return View(db.Maalested_Table.ToList());
        }

        // GET: Maalested_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maalested_Table maalested_Table = db.Maalested_Table.Find(id);
            if (maalested_Table == null)
            {
                return HttpNotFound();
            }
            return View(maalested_Table);
        }

        // GET: Maalested_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maalested_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaaleStedId,Navn,Akronym,GeometriId")] Maalested_Table maalested_Table)
        {
            if (ModelState.IsValid)
            {
                db.Maalested_Table.Add(maalested_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maalested_Table);
        }

        // GET: Maalested_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maalested_Table maalested_Table = db.Maalested_Table.Find(id);
            if (maalested_Table == null)
            {
                return HttpNotFound();
            }
            return View(maalested_Table);
        }

        // POST: Maalested_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaaleStedId,Navn,Akronym,GeometriId")] Maalested_Table maalested_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maalested_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maalested_Table);
        }

        // GET: Maalested_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maalested_Table maalested_Table = db.Maalested_Table.Find(id);
            if (maalested_Table == null)
            {
                return HttpNotFound();
            }
            return View(maalested_Table);
        }

        // POST: Maalested_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maalested_Table maalested_Table = db.Maalested_Table.Find(id);
            db.Maalested_Table.Remove(maalested_Table);
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
