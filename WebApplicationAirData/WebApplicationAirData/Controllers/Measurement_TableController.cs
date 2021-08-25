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
    public class Measurement_TableController : Controller
    {
        private Environmental_Data_2020Entities db = new Environmental_Data_2020Entities();

        // GET: Measurement_Table
        public ActionResult Index()
        {
            var measurement_Table = db.Measurement_Table.Include(m => m.DataType_Table).Include(m => m.Enhed_Table).Include(m => m.Product_Table);
            return View(measurement_Table.Take(1000).ToList());
        }

        // GET: Measurement_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement_Table measurement_Table = db.Measurement_Table.Find(id);
            if (measurement_Table == null)
            {
                return HttpNotFound();
            }
            return View(measurement_Table);
        }

        // GET: Measurement_Table/Create
        public ActionResult Create()
        {
            ViewBag.DataTypeId = new SelectList(db.DataType_Table, "DataTypeId", "DataTypeNavn");
            ViewBag.EnhedId = new SelectList(db.Enhed_Table, "EnhedId", "Navn");
            ViewBag.ProduktId = new SelectList(db.Product_Table, "ProduktId", "ProduktId");
            return View();
        }

        // POST: Measurement_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaaResultat,StofId,DataTypeId,InstruksId,EnhedId,AKorrektion,BKorrektion,ProduktId")] Measurement_Table measurement_Table)
        {
            if (ModelState.IsValid)
            {
                db.Measurement_Table.Add(measurement_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DataTypeId = new SelectList(db.DataType_Table, "DataTypeId", "DataTypeNavn", measurement_Table.DataTypeId);
            ViewBag.EnhedId = new SelectList(db.Enhed_Table, "EnhedId", "Navn", measurement_Table.EnhedId);
            ViewBag.ProduktId = new SelectList(db.Product_Table, "ProduktId", "ProduktId", measurement_Table.ProduktId);
            return View(measurement_Table);
        }

        // GET: Measurement_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement_Table measurement_Table = db.Measurement_Table.Find(id);
            if (measurement_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.DataTypeId = new SelectList(db.DataType_Table, "DataTypeId", "DataTypeNavn", measurement_Table.DataTypeId);
            ViewBag.EnhedId = new SelectList(db.Enhed_Table, "EnhedId", "Navn", measurement_Table.EnhedId);
            ViewBag.ProduktId = new SelectList(db.Product_Table, "ProduktId", "ProduktId", measurement_Table.ProduktId);
            return View(measurement_Table);
        }

        // POST: Measurement_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaaResultat,StofId,DataTypeId,InstruksId,EnhedId,AKorrektion,BKorrektion,ProduktId")] Measurement_Table measurement_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measurement_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DataTypeId = new SelectList(db.DataType_Table, "DataTypeId", "DataTypeNavn", measurement_Table.DataTypeId);
            ViewBag.EnhedId = new SelectList(db.Enhed_Table, "EnhedId", "Navn", measurement_Table.EnhedId);
            ViewBag.ProduktId = new SelectList(db.Product_Table, "ProduktId", "ProduktId", measurement_Table.ProduktId);
            return View(measurement_Table);
        }

        // GET: Measurement_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement_Table measurement_Table = db.Measurement_Table.Find(id);
            if (measurement_Table == null)
            {
                return HttpNotFound();
            }
            return View(measurement_Table);
        }

        // POST: Measurement_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measurement_Table measurement_Table = db.Measurement_Table.Find(id);
            db.Measurement_Table.Remove(measurement_Table);
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
