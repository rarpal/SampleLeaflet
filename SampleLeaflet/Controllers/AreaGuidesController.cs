using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleLeaflet.Models;

namespace SampleLeaflet.Controllers
{
    public class AreaGuidesController : Controller
    {
        private DBEntitiesAreaGuide db = new DBEntitiesAreaGuide();

        // GET: AreaGuides
        public ActionResult Index()
        {
            return PartialView(db.AreaGuides.ToList());
        }

        // GET: AreaGuides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaGuide areaGuide = db.AreaGuides.Find(id);
            if (areaGuide == null)
            {
                return HttpNotFound();
            }
            return View(areaGuide);
        }

        // GET: AreaGuides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaGuides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AreaID,Type,AvgPrice,Rating,Notes,ID")] AreaGuide areaGuide)
        {
            if (ModelState.IsValid)
            {
                db.AreaGuides.Add(areaGuide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areaGuide);
        }

        // GET: AreaGuides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaGuide areaGuide = db.AreaGuides.Find(id);
            if (areaGuide == null)
            {
                return HttpNotFound();
            }
            return PartialView(areaGuide);
        }

        // POST: AreaGuides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AreaID,Type,AvgPrice,Rating,Notes,ID")] AreaGuide areaGuide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaGuide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areaGuide);
        }

        // GET: AreaGuides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaGuide areaGuide = db.AreaGuides.Find(id);
            if (areaGuide == null)
            {
                return HttpNotFound();
            }
            return View(areaGuide);
        }

        // POST: AreaGuides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaGuide areaGuide = db.AreaGuides.Find(id);
            db.AreaGuides.Remove(areaGuide);
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
