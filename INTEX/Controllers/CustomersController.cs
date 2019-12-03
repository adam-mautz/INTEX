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
        public ActionResult Index()
        {
            return View(db.customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customer.Find(id);
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
            ViewBag.States = lstStates;
            if (ModelState.IsValid)
            {
                db.customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customer.Find(id);
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
            Customer customer = db.customer.Find(id);
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
            Customer customer = db.customer.Find(id);
            db.customer.Remove(customer);
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

        public static List<SelectListItem> lstStates = new List<SelectListItem>()
        {
            new SelectListItem() {Text="Alabama", Value="AL"},
            new SelectListItem() { Text="Alaska", Value="AK"},
            new SelectListItem() { Text="Arizona", Value="AZ"},
            new SelectListItem() { Text="Arkansas", Value="AR"},
            new SelectListItem() { Text="California", Value="CA"},
            new SelectListItem() { Text="Colorado", Value="CO"},
            new SelectListItem() { Text="Connecticut", Value="CT"},
            new SelectListItem() { Text="District of Columbia", Value="DC"},
            new SelectListItem() { Text="Delaware", Value="DE"},
            new SelectListItem() { Text="Florida", Value="FL"},
            new SelectListItem() { Text="Georgia", Value="GA"},
            new SelectListItem() { Text="Hawaii", Value="HI"},
            new SelectListItem() { Text="Idaho", Value="ID"},
            new SelectListItem() { Text="Illinois", Value="IL"},
            new SelectListItem() { Text="Indiana", Value="IN"},
            new SelectListItem() { Text="Iowa", Value="IA"},
            new SelectListItem() { Text="Kansas", Value="KS"},
            new SelectListItem() { Text="Kentucky", Value="KY"},
            new SelectListItem() { Text="Louisiana", Value="LA"},
            new SelectListItem() { Text="Maine", Value="ME"},
            new SelectListItem() { Text="Maryland", Value="MD"},
            new SelectListItem() { Text="Massachusetts", Value="MA"},
            new SelectListItem() { Text="Michigan", Value="MI"},
            new SelectListItem() { Text="Minnesota", Value="MN"},
            new SelectListItem() { Text="Mississippi", Value="MS"},
            new SelectListItem() { Text="Missouri", Value="MO"},
            new SelectListItem() { Text="Montana", Value="MT"},
            new SelectListItem() { Text="Nebraska", Value="NE"},
            new SelectListItem() { Text="Nevada", Value="NV"},
            new SelectListItem() { Text="New Hampshire", Value="NH"},
            new SelectListItem() { Text="New Jersey", Value="NJ"},
            new SelectListItem() { Text="New Mexico", Value="NM"},
            new SelectListItem() { Text="New York", Value="NY"},
            new SelectListItem() { Text="North Carolina", Value="NC"},
            new SelectListItem() { Text="North Dakota", Value="ND"},
            new SelectListItem() { Text="Ohio", Value="OH"},
            new SelectListItem() { Text="Oklahoma", Value="OK"},
            new SelectListItem() { Text="Oregon", Value="OR"},
            new SelectListItem() { Text="Pennsylvania", Value="PA"},
            new SelectListItem() { Text="Rhode Island", Value="RI"},
            new SelectListItem() { Text="South Carolina", Value="SC"},
            new SelectListItem() { Text="South Dakota", Value="SD"},
            new SelectListItem() { Text="Tennessee", Value="TN"},
            new SelectListItem() { Text="Texas", Value="TX"},
            new SelectListItem() { Text="Utah", Value="UT"},
            new SelectListItem() { Text="Vermont", Value="VT"},
            new SelectListItem() { Text="Virginia", Value="VA"},
            new SelectListItem() { Text="Washington", Value="WA"},
            new SelectListItem() { Text="West Virginia", Value="WV"},
            new SelectListItem() { Text="Wisconsin", Value="WI"},
            new SelectListItem() { Text="Wyoming", Value="WY"}
        };
        
    }
}
