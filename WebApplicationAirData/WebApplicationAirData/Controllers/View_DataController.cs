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
    public class View_DataController : Controller
    {
        private Environmental_Data_2020Entities4 db = new Environmental_Data_2020Entities4();

        // GET: View_Data
        public ActionResult Index()
        {
            return View(db.View_Data.Take(1000).ToList());
        }

        // GET: View_Data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Data view_Data = db.View_Data.Find(id);
            if (view_Data == null)
            {
                return HttpNotFound();
            }
            return View(view_Data);
        }

        // GET: View_Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: View_Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "time_stamp,Data_Type,Enhed_Name,Stof_Name,MeasurePlace_Name,Measurement_Result,Constuction_Code,AktivitetId")] View_Data view_Data)
        {
            if (ModelState.IsValid)
            {
                db.View_Data.Add(view_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view_Data);
        }

        // GET: View_Data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Data view_Data = db.View_Data.Find(id);
            if (view_Data == null)
            {
                return HttpNotFound();
            }
            return View(view_Data);
        }

        // POST: View_Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "time_stamp,Data_Type,Enhed_Name,Stof_Name,MeasurePlace_Name,Measurement_Result,Constuction_Code,AktivitetId")] View_Data view_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view_Data);
        }

        // GET: View_Data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Data view_Data = db.View_Data.Find(id);
            if (view_Data == null)
            {
                return HttpNotFound();
            }
            return View(view_Data);
        }

        // POST: View_Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            View_Data view_Data = db.View_Data.Find(id);
            db.View_Data.Remove(view_Data);
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
