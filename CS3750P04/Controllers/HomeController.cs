using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS3750P04.Models;

namespace CS3750P04.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            ViewData["Message"] = "This is a terrible test.";
            var model = db.GetUsers();
            
            return View(model.FirstOrDefault());
        }

        public IActionResult User()
        {
            ViewData["Message"] = "The main screen with user info and metrics.";
            TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            var model = db.GetUsers();

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
