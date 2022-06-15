using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Session_Tutorial_01.Models;

namespace Session_Tutorial_01.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Employee employee)
        {
            //Save employee into Session
            Session["Employee"] = employee;

            // Go to "Profile" action method
            return RedirectToAction("Profile");
        }

        public ActionResult Profile()
        {
            if (Session["Employee"] == null)
            {
                return View("Index");
            }
            return View();
        }
    }
}