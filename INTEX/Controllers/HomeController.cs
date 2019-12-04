using INTEX.DAL;
using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace INTEX.Controllers
{
    public class HomeController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String username = form["Username"].ToString();
            String password = form["Password"].ToString();
           
            var currentCustomer =
                db.Database.SqlQuery<Customer>(
            "Select * " +
            "FROM Customers " +
            "WHERE Cust_Username = '" + username + "' AND " +
            "Cust_Password = '" + password + "'");
            if (currentCustomer.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                return RedirectToAction("Index", "Customers");
            }
            else if (currentCustomer.Count() == 0)
            {
                var currentEmployee =
                    db.Database.SqlQuery<Employees>(
                "Select * " +
                "FROM Employees " +
                "WHERE Emp_Username = '" + username + "' AND " +
                "Emp_Password = '" + password + "'");
                if (currentEmployee.Count() > 0)
                {
                    FormsAuthentication.SetAuthCookie(username, rememberMe);
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}