﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public string Index()
        {
            return "This is my <b>default</b> action...";
        }

        // GET: /HelloWorld/Welcome
        //public string Welcome()
        //{
        //    return "This is the Welcome action method...";
        //}

        public string Welcome(string name, int numTimes = 1)
        {
            return HttpUtility.HtmlEncode($"Hello {name}, NumTime is: {numTimes}");
            //return $"Hello {name}, NumTime is: {numTimes}";
        }

    }
}