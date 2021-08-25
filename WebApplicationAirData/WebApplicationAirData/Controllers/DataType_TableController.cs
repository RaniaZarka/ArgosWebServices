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
    public class DataType_TableController : Controller
    {
        private Environmental_Data_2020Entities db = new Environmental_Data_2020Entities();

        // GET: DataType_Table
        public ActionResult Index()
        {
            return View(db.DataType_Table.ToList());
        }

        // GET: DataType_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataType_Table dataType_Table = db.DataType_Table.Find(id);
            if (dataType_Table == null)
            {
                return HttpNotFound();
            }
            return View(dataType_Table);
        }

        // GET: DataType_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataType_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DataTypeId,DataTypeNavn")] DataType_Table dataType_Table)
        {
            if (ModelState.IsValid)
            {
                db.DataType_Table.Add(dataType_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dataType_Table);
        }

        // GET: DataType_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataType_Table dataType_Table = db.DataType_Table.Find(id);
            if (dataType_Table == null)
            {
                return HttpNotFound();
            }
            return View(dataType_Table);
        }

        // POST: DataType_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DataTypeId,DataTypeNavn")] DataType_Table dataType_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dataType_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataType_Table);
        }

        // GET: DataType_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataType_Table dataType_Table = db.DataType_Table.Find(id);
            if (dataType_Table == null)
            {
                return HttpNotFound();
            }
            return View(dataType_Table);
        }

        // POST: DataType_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataType_Table dataType_Table = db.DataType_Table.Find(id);
            db.DataType_Table.Remove(dataType_Table);
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
