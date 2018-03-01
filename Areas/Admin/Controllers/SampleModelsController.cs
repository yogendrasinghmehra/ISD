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
    public class SampleModelsController : Controller
    {
        private dbContext db = new dbContext();

        // GET: Admin/SampleModels
        public ActionResult Index()
        {
            return View(db.models.ToList());
        }

        

        // GET: Admin/SampleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SampleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelId,Name,IsEnabled")] SampleModels sampleModels, HttpPostedFileBase LargeImage)
        {
            if (ModelState.IsValid)
            {

                if (LargeImage != null)
                {
                    //saving both small and large images and receiving back their urls.
                    SampleModelMethods sampleModelMethods = new SampleModelMethods();
                    sampleModels.LargeImageUrl = sampleModelMethods.SaveLargeImage(LargeImage);

                    //adding records to database..
                    db.models.Add(sampleModels);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Please Select an image for project.");
                }
                //db.models.Add(sampleModels);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(sampleModels);
        }

        // GET: Admin/SampleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleModels sampleModels = db.models.Find(id);
            if (sampleModels == null)
            {
                return HttpNotFound();
            }
            return View(sampleModels);
        }

        // POST: Admin/SampleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SampleModels sampleModels, HttpPostedFileBase LargeImage)
        {
            if (ModelState.IsValid)
            {
                SampleModelMethods sampleModelMethods = new SampleModelMethods();

                if (LargeImage != null)
                {
                    //deleting old large image file.
                    var oldLargeImageUrlPath = Path.Combine(HttpContext.Server.MapPath(sampleModels.LargeImageUrl));

                    //saving small image and receiving back their urls.                 
                    sampleModels.LargeImageUrl = sampleModelMethods.SaveLargeImage(LargeImage);
                    if (System.IO.File.Exists(oldLargeImageUrlPath))
                    {
                        System.IO.File.Delete(oldLargeImageUrlPath);
                    }
                }



                db.Entry(sampleModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sampleModels);
        }

        // GET: Admin/SampleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleModels sampleModels = db.models.Find(id);
            if (sampleModels == null)
            {
                return HttpNotFound();
            }
            return View(sampleModels);
        }

        // POST: Admin/SampleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SampleModels sampleModels = db.models.Find(id);
            db.models.Remove(sampleModels);
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
