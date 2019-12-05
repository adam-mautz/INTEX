using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INTEX.DAL;
using INTEX.Models;

namespace INTEX.Controllers
{
    public class CompoundsController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Compounds
        public ActionResult Index()
        {
            return View(db.compounds.ToList());
        }

        // GET: Compounds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compounds compounds = db.compounds.Find(id);
            if (compounds == null)
            {
                return HttpNotFound();
            }
            return View(compounds);
        }

        // GET: Compounds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LT_Number,Compound_Name,Compund_Quantity,Appearance,Estimated_Weight,Date_Arrived,Date_Received,Date_Due,Actual_Weight,Max_Tolerated_Dose")] Compounds compounds)
        {
            if (ModelState.IsValid)
            {
                db.compounds.Add(compounds);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compounds);
        }

        // GET: Compounds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compounds compounds = db.compounds.Find(id);
            if (compounds == null)
            {
                return HttpNotFound();
            }
            return View(compounds);
        }

        // POST: Compounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LT_Number,Compound_Name,Compund_Quantity,Appearance,Estimated_Weight,Date_Arrived,Date_Received,Date_Due,Actual_Weight,Max_Tolerated_Dose")] Compounds compounds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compounds).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compounds);
        }

        // GET: Compounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compounds compounds = db.compounds.Find(id);
            if (compounds == null)
            {
                return HttpNotFound();
            }
            return View(compounds);
        }

        // POST: Compounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compounds compounds = db.compounds.Find(id);
            db.compounds.Remove(compounds);
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
