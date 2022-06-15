using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Session_Tutorial_01.Models;

namespace Session_Tutorial_01.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        // GET: Person/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Person person)
        {
            var people = Session["people"] as List<Person>;
            if (people != null && people.Find(p => p.Name == person.Name) != null)
            {
                ViewBag.ExistingPersonError = "This name existed. Please choose another name.";
                return View();
            }
            if (people == null)
            {
                people = new List<Person> { person };
                Session["people"] = people;
            }
            else if (people.Find(p => p.Name == person.Name) == null)
            {
                people.Add(person);
                Session["people"] = people;
            }
            Session["currentPerson"] = person;
            return RedirectToAction("Index");
        }

        // GET: Person/PersonalInfo
        public ActionResult PersonalInfo()
        {
            if (Session["currentPerson"] == null)
            {
                return View("Index");
            }
            return View();
        }

        // GET: Person/Login
        public ActionResult Login()
        {
            if (Session["currentPerson"] != null)
            {
                return View("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            var people = Session["people"] as List<Session_Tutorial_01.Models.Person>;
            if (people == null)
            {
                ViewBag.ErrorFromLoginAction = "This user does no exists. Please register a new account.(1)";
                return View("Register");
            }

            var person = people.Find(x => x.Name == name);
            if (person == null)
            {
                ViewBag.ErrorFromLoginAction = "This user does no exists. Please register a new account.";
                return View("Register");
            }
            else
            {
                if (person.Password == password)
                {
                    Session["currentPerson"] = person;
                    return View("Index");
                }
            }
            ViewBag.ErrorFromLoginAction = "Wrong password. Please try again.";
            return View("Login");

        }

        public ActionResult Logout()
        {
            Session.Remove("currentPerson");
            return View("Index");
        }

        // GET: Person
        public ActionResult Information()
        {
            if (Session["people"] == null)
            {
                return View("Index");
            }
            return View();
        }
    }

}