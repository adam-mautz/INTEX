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
    public class EmployeesController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Employees
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //Methods written by hand. Most methods for the employee login run through here.

        //Shows all customers who have unfinished work orders
        [HttpGet]
        public ActionResult CurrentCustomers()
        {
            return View(db.customers.ToList());
        }

        public ActionResult ShowCustomerWorkOrders(int id) //displays all the work orders with a given CustID
        {
            var currentCustomer =
               db.Database.SqlQuery<Work_Orders>(
           "Select * " +
           "FROM Work_Orders " +
           "WHERE CustID = '" + id + "'"); 
            return View(currentCustomer.ToList());
        }

        //Retrieves all the tests that will be performed on a specific work order
        public ActionResult ShowWorkOrderTests(int? id, int? OrderID)
        {
            var currentWorkOrder =
               db.Database.SqlQuery<Tests>(
                   "select t.Compound_Sequence_Code, t.LT_Number, t.Test_Type, t.Comment, t.StatusID, t.Raw_Results, t.Approved, t.Test_Date_Scheduled, t.OrderID " +
                   "from tests t join work_orders wo on wo.OrderID = t.OrderID " +
                   "where t.orderID = '" + id + "'"); 

            return View(currentWorkOrder.ToList());
        }

        public ActionResult TestComment() //displays the view where test info can be uploaded and test comments can be made by Singapore
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult CurrentWorkOrders() //sorts work orders by level of completion and displays them to the view
        {

            var unscheduledWO
                = db.Database.SqlQuery<Work_Orders>(
                    "SELECT * " +
                    "FROM Work_Orders " +
                    "WHERE StatusID = 'I'");

            var scheduledWO
                = db.Database.SqlQuery<Work_Orders>(
                    "SELECT * " +
                    "FROM Work_Orders " +
                    "WHERE StatusID = 'P'");

            var completeWO
                = db.Database.SqlQuery<Work_Orders>(
                    "SELECT * " +
                    "FROM Work_Orders " +
                    "WHERE StatusID = 'C'");

            unscheduledWO.ToList();//combines the three queries to display data sorted by level of completion
            scheduledWO.ToList();
            completeWO.ToList();

            var combine = unscheduledWO.Concat(scheduledWO);
            var currentWOs = combine.Concat(completeWO);

            return View(currentWOs);
        }

        [HttpGet]
        public ActionResult PastWorkOrders() //displays all work orders, no matter the status
        {
            return View(db.work_orders.ToList());
        }

        [HttpPost]
        public ActionResult PastWorkOrders(FormCollection form)//searches database for the orderId searched by the user
        {
            String search = form["Search"].ToString();

            //searches for customer ID in work orders table
            var checkSearch =
            db.Database.SqlQuery<Work_Orders>(
            "Select * " +
            "FROM Work_Orders " +
            "WHERE OrderID = '" + search + "'");


            if (checkSearch.Count() > 0)
            {
                return View(checkSearch.ToList());
            }
            else
            {
                return View(db.work_orders.ToList());
            }
            
        }

        [HttpPost]
        public ActionResult PastWorkOrders1(FormCollection form)//searches database for the orderId searched by the user
        {
            String First = form["FirstName"].ToString();
            String Last = form["LastName"].ToString();

            //searches for first and last name in customer table
            var FirstLastCheck =
                db.Database.SqlQuery<Work_Orders>(
                    "SELECT * " +
                    "FROM Work_Orders " +
                    "JOIN Customers ON Work_Orders.CustID = Customers.CustID " +
                    "WHERE Customers.Cust_First_Name = '" + First + "' AND Customers.Cust_Last_Name = '" + Last + "'");

            if (FirstLastCheck.Count() > 0)
            {
                return View("PastWorkOrders", FirstLastCheck.ToList());
            }
            else
            {
                return View("PastWorkOrders", db.work_orders.ToList());
            }

        }




        [HttpGet]
        public ActionResult ReportIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CurrentWorkOrders(int OrderID, int LT_Number, int Compound_Sequence_Code)
        {
            return View();
        }

        [HttpGet] 
        public ActionResult ProfitabilityReport()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PerformanceReport()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DataReport()
        {
            return View();
        }

        public ActionResult Employees() //shows a list of all the employees, allows for creating and editing etc.
        {
            return View(db.employees.ToList());
        }




        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,Emp_First_Name,Emp_Last_Name,Emp_Street_Address1,Emp_Street_Address2,Emp_City,Emp_State,Emp_Zip,Emp_Zip_Plus,Emp_Area_Code,Emp_Phone,Emp_Email,Emp_Username,Emp_Password")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,Emp_First_Name,Emp_Last_Name,Emp_Street_Address1,Emp_Street_Address2,Emp_City,Emp_State,Emp_Zip,Emp_Zip_Plus,Emp_Area_Code,Emp_Phone,Emp_Email,Emp_Username,Emp_Password")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.employees.Find(id);
            db.employees.Remove(employees);
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
