using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISD.Areas.Admin.Models;
using System.IO;

namespace ISD.Areas.Admin.Controllers
{
    [Authorize]
    public class DrawingsController : Controller
    {
        private dbContext db = new dbContext();

        // GET: Admin/Drawings
        public ActionResult Index()
        {
            return View(db.drawings.ToList());
        }

      

        // GET: Admin/Drawings/Create
        public ActionResult Create()
        {
            Drawing drawing = new Drawing();
            drawing.drawingList = db.drawingTypes.ToList();

            return View(drawing);
        }

        // POST: Admin/Drawings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Drawing drawing, HttpPostedFileBase LargeImage)
        {
            if (ModelState.IsValid)
            {
                if (LargeImage != null)
                {
                    //saving both small and large images and receiving back their urls.
                    DrawingMethods drawingMethods = new DrawingMethods();
                    drawing.LargeImageUrl = drawingMethods.SaveLargeImage(LargeImage, db.drawingTypes.Single(i => i.DrawingTypeId == drawing.DrawingTypeId).Name);
                    
                    //adding records to database..
                    db.drawings.Add(drawing);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Please Select an image for project.");
                }
                
            }

            return View(drawing);
        }

        // GET: Admin/Drawings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drawing drawing = db.drawings.Find(id);
            if (drawing == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrawingTypeId = new SelectList(db.drawingTypes, "DrawingTypeId", "Name", drawing.DrawingTypeId);
            return View(drawing);
        }

        // POST: Admin/Drawings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Drawing drawing, HttpPostedFileBase LargeImage)
        {
            if (ModelState.IsValid)
            {

                DrawingMethods drawingMethods = new DrawingMethods();
                
                if (LargeImage != null)
                {
                    //deleting old large image file.
                    var oldLargeImageUrlPath = Path.Combine(HttpContext.Server.MapPath(drawing.LargeImageUrl));

                    //saving small image and receiving back their urls.                 
                    drawing.LargeImageUrl = drawingMethods.SaveLargeImage(LargeImage,drawing.drawingsType.Name);
                    if (System.IO.File.Exists(oldLargeImageUrlPath))
                    {
                        System.IO.File.Delete(oldLargeImageUrlPath);
                    }
                }
                db.Entry(drawing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");                
            }
            return View(drawing);
        }




        //
        // GET: /Admin/Drawing/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Drawing drawing = db.drawings.Find(id);
            if (drawing == null)
            {
                return HttpNotFound();
            }
            return View(drawing);
        }

        //
        // POST: /Admin/Drawing/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Drawing drawing = db.drawings.Find(id);
            db.drawings.Remove(drawing);
            db.SaveChanges();

            //deleting large and small images from folders.
            var oldLargeImageUrlPath = Path.Combine(HttpContext.Server.MapPath(drawing.LargeImageUrl));            

            if (System.IO.File.Exists(oldLargeImageUrlPath))
            {
                System.IO.File.Delete(oldLargeImageUrlPath);
            }           
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
