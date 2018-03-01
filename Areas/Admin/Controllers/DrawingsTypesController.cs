using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISD.Areas.Admin.Models;

namespace ISD.Areas.Admin.Controllers
{
    public class DrawingsTypesController : Controller
    {
        private dbContext db = new dbContext();

        // GET: Admin/DrawingsTypes
        public ActionResult Index()
        {
            return View(db.drawingTypes.ToList());
        }

        // GET: Admin/DrawingsTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawingsType drawingsType = db.drawingTypes.Find(id);
            if (drawingsType == null)
            {
                return HttpNotFound();
            }
            return View(drawingsType);
        }

        // GET: Admin/DrawingsTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DrawingsTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrawingTypeId,Name")] DrawingsType drawingsType)
        {
            if (ModelState.IsValid)
            {
                db.drawingTypes.Add(drawingsType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drawingsType);
        }

        // GET: Admin/DrawingsTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawingsType drawingsType = db.drawingTypes.Find(id);
            if (drawingsType == null)
            {
                return HttpNotFound();
            }
            return View(drawingsType);
        }

        // POST: Admin/DrawingsTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrawingTypeId,Name")] DrawingsType drawingsType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drawingsType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drawingsType);
        }

        // GET: Admin/DrawingsTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrawingsType drawingsType = db.drawingTypes.Find(id);
            if (drawingsType == null)
            {
                return HttpNotFound();
            }
            return View(drawingsType);
        }

        // POST: Admin/DrawingsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrawingsType drawingsType = db.drawingTypes.Find(id);
            db.drawingTypes.Remove(drawingsType);
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
