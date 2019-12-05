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
    public class CustomersController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Customers
       // [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustID,Cust_First_Name,Cust_Last_Name,Cust_Street_Address1,Cust_Street_Address2,Cust_City,Cust_State,Cust_Zip,Cust_Zip_Plus,Cust_Area_Code,Cust_Phone,Cust_Email,Cust_Username,Cust_Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Quote", "Customers", customer.Cust_Phone);
            }

            return View(customer);
        }

        public static string custPhone;

        public ActionResult Quote(string cPhone)
        {
            ServicesModel services = new ServicesModel();
            using (db)
            {
                services.lstServices = db.services.ToList<Services>();
            }

            ViewBag.Phone = cPhone;
            return View(services);
        }

        public static ServicesModel newModel = new ServicesModel();
        public static List<Services> newList = new List<Services>();

        [HttpPost]
        public ActionResult Quote(ServicesModel model)
        {
            decimal price = 0;
            for (int i = 0; i < model.lstServices.Count(); i++)
            {
                if (model.lstServices[i].isChecked)
                {
                    price += model.lstServices[i].Test_Cost;
                    ViewBag.Price = "Total price: $" + price;
                }
            }

            newList = model.lstServices;
            newModel = model;

            return View(model);
        }

        public ActionResult AddQuote()
        {
           int custID = 11;
           Customer cust = db.customers.Find(custID);
           ViewBag.fName = cust.Cust_First_Name;
           ViewBag.lName = cust.Cust_Last_Name;
           string sTests ="";
            for (int i = 0; i < newModel.lstServices.Count(); i++)
            {
                if (newModel.lstServices[i].isChecked)
                {
                    sTests += ", " + newModel.lstServices[i].Test_Name;
                }
            }
            sTests = sTests.Substring(1);
            ViewBag.tests = sTests;
            return View();
        }
      

        [HttpPost]
        public ActionResult AddQuote(Services model)
        {
            NorthwestContext newDb = new NorthwestContext();

            Compounds myCompound = new Compounds();
            myCompound.Actual_Weight = 12;
            myCompound.Appearance = "blue";
            myCompound.Compound_Name = "myCompound";
            myCompound.Compound_Quantity = 1;
            myCompound.Date_Arrived = Convert.ToDateTime("2020-02-02 11:45:00");
            myCompound.Date_Due = Convert.ToDateTime("2020-02-02 12:45:00");
            myCompound.Date_Received = Convert.ToDateTime("2020-01-02 12:45:00");
            myCompound.Max_Tolerated_Dose = 3;
            myCompound.Estimated_Weight = 10;

            db.compounds.Add(myCompound);
            db.SaveChanges();

            Tests myTest = new Tests();
            int iCount = 0;
            List<string> typeList = new List<string>();
            for (int i = 0; i < newModel.lstServices.Count(); i++)
            {
                if (newModel.lstServices[i].isChecked)
                {
                    iCount++;
                    typeList.Add(newModel.lstServices[i].Test_Type);
                }
            }

            for (int i = 0; i < iCount; i++)
            {
                myTest.LT_Number = myCompound.LT_Number;
                myTest.Test_Type = typeList[i];
                myTest.Comment = "Commenting is very important";
                myTest.StatusID = "U";
                myTest.Raw_Results = "pinvv23489tyhc34cfinjhrep";
                myTest.Approved = false;
                myTest.Test_Date_Scheduled = Convert.ToDateTime("2020-01-02 12:45:00");

                db.tests.Add(myTest);
                db.SaveChanges();

            }






            return View("Index");
        }

 




        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustID,Cust_First_Name,Cust_Last_Name,Cust_Street_Address1,Cust_Street_Address2,Cust_City,Cust_State,Cust_Zip,Cust_Zip_Plus,Cust_Area_Code,Cust_Phone,Cust_Email,Cust_Username,Cust_Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.customers.Find(id);
            db.customers.Remove(customer);
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
