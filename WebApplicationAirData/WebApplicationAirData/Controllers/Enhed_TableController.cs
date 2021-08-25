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
    public class Enhed_TableController : Controller
    {
        private Environmental_Data_2020Entities db = new Environmental_Data_2020Entities();

        // GET: Enhed_Table
        public ActionResult Index()
        {
            return View(db.Enhed_Table.ToList());
        }

        // GET: Enhed_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enhed_Table enhed_Table = db.Enhed_Table.Find(id);
            if (enhed_Table == null)
            {
                return HttpNotFound();
            }
            return View(enhed_Table);
        }

        // GET: Enhed_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enhed_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnhedId,Navn,Kommentar")] Enhed_Table enhed_Table)
        {
            if (ModelState.IsValid)
            {
                db.Enhed_Table.Add(enhed_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enhed_Table);
        }

        // GET: Enhed_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enhed_Table enhed_Table = db.Enhed_Table.Find(id);
            if (enhed_Table == null)
            {
                return HttpNotFound();
            }
            return View(enhed_Table);
        }

        // POST: Enhed_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnhedId,Navn,Kommentar")] Enhed_Table enhed_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enhed_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enhed_Table);
        }

        // GET: Enhed_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enhed_Table enhed_Table = db.Enhed_Table.Find(id);
            if (enhed_Table == null)
            {
                return HttpNotFound();
            }
            return View(enhed_Table);
        }

        // POST: Enhed_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enhed_Table enhed_Table = db.Enhed_Table.Find(id);
            db.Enhed_Table.Remove(enhed_Table);
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
