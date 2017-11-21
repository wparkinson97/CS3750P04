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
            //TimeTrackerEntityContext db = new TimeTrackerEntityContext("server=localhost;database=CS3750P04;user=student;password=picklerick");
            //TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            //db.GetUsers();
            //db.GetGroups();
            //db.GetProjects();
            //db.GetUserProjects();
            ////db.addUser(new Models.User()
            ////{
            ////    ScreenName = "Added from db",
            ////    FirstName = "Something",
            ////    LastName = "Special",
            ////    isActive = true,
            ////    UserHash = "Not implemeneted yet"
            ////});
            //return "hello from code?";
            return View();
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
