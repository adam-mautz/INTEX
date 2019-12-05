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
    public class Work_OrdersController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Work_Orders
        public ActionResult Index()
        {
            int custID = 1;

            Work_Orders custWO = db.work_orders.Find(custID);
            return View(custWO);
        }

        // GET: Work_Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Orders work_Orders = db.work_orders.Find(id);
            if (work_Orders == null)
            {
                return HttpNotFound();
            }
            return View(work_Orders);
        }

        // GET: Work_Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Work_Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustID,LT_Number,Rushed,Discount_Percentage,StatusID,Comments,Reports")] Work_Orders work_Orders)
        {
            if (ModelState.IsValid)
            {
                db.work_orders.Add(work_Orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work_Orders);
        }

        // GET: Work_Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Orders work_Orders = db.work_orders.Find(id);
            if (work_Orders == null)
            {
                return HttpNotFound();
            }
            return View(work_Orders);
        }

        // POST: Work_Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustID,LT_Number,Rushed,Discount_Percentage,StatusID,Comments,Reports")] Work_Orders work_Orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_Orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PastWorkOrders", "Employees");
            }
            return View(work_Orders);
        }

        // GET: Work_Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Orders work_Orders = db.work_orders.Find(id);
            if (work_Orders == null)
            {
                return HttpNotFound();
            }
            return View(work_Orders);
        }

        // POST: Work_Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work_Orders work_Orders = db.work_orders.Find(id);
            db.work_orders.Remove(work_Orders);
            db.SaveChanges();
            return RedirectToAction("PastWorkOrders", "Employees");
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
