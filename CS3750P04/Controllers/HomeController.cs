using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CS3750P04.Models;

using System;
using System.Data;
using System.Web;

namespace CS3750P04.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            int? id = (int?)(HttpContext.Session.GetInt32("userId")) ?? -1;
            if (id == -1)
                return RedirectToAction("Login");
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            User user = db.GetUsers().Where(dbUser => username == dbUser.ScreenName && dbUser.UserHash == password).First();
            HttpContext.Session.SetInt32("userId", user.UserId);
            return RedirectToAction("Index");
            //return View();
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(string username, string password,string firstName, string lastName, int groupId)
        {
            TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            db.addUser(new Models.User()
            {
                ScreenName = username,
                UserHash = password,
                FirstName = firstName,
                LastName = lastName,
                isActive = true
            });
            db.addUserProject(new UserProject()
            {
                GroupId = groupId,
                UserId = db.GetUsers().Find(user => user.ScreenName == username).UserId
            });
            HttpContext.Session.SetInt32("userId", db.GetUsers().Find(user => user.ScreenName == username).UserId);

            return RedirectToAction("Index");
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
