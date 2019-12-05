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
    public class TestsController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Tests
        public ActionResult Index()
        {
            return View(db.tests.ToList());
        }

        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tests tests = db.tests.Find(id);
            if (tests == null)
            {
                return HttpNotFound();
            }
            return View(tests);
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Compound_Sequence_Code,LT_Number,Test_Type,Comment,StatusID,Raw_Results,Approved,Test_Date_Scheduled,OrderID")] Tests tests)
        {
            if (ModelState.IsValid)
            {
                db.tests.Add(tests);
                db.SaveChanges();
                return RedirectToAction("ShowWorkOrderTests", "Employees");
            }

            return View(tests);
        }

        public static int globalOrderID = 0;
        // GET: Tests/Edit/5
        public ActionResult Edit(int id, int OrderID)
        {
            globalOrderID = OrderID;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testModels tests = new testModels();

            using (db)
            {
                tests.lstTests = db.tests.ToList<Tests>();
            }

            Tests newTest = new Tests();
            for (int i = 0; i < tests.lstTests.Count(); i++)
            {
                if (tests.lstTests[i].OrderID == OrderID && tests.lstTests[i].Compound_Sequence_Code == id)
                {
                    newTest = tests.lstTests[i];
                    break;
                }
            } 
            

        /**    var test =
                db.Database.SqlQuery<Tests>(
                    "SELECT * " +
                    "FROM Tests " +
                    "WHERE Compound_Sequence_Code = '" + id + "' AND OrderID = '" + OrderID + "'");
    **/
            if (tests == null)
            {
                return HttpNotFound();
            }

            return View(newTest);
            
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Compound_Sequence_Code,LT_Number,Test_Type,Comment,StatusID,Raw_Results,Approved,Test_Date_Scheduled,OrderID")] Tests tests, int id, int OrderID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tests).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("ShowWorkOrderTests", "Employees", new {id = OrderID });
            }
            return View(tests);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tests tests = db.tests.Find(id);
            if (tests == null)
            {
                return HttpNotFound();
            }
            return View(tests);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tests tests = db.tests.Find(id);
            db.tests.Remove(tests);
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
