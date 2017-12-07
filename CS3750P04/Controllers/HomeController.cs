using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS3750P04.Models;
using CS3750P04.ViewModels;

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

        public IActionResult User(int projectID, int userID)
        {
            ViewData["Message"] = "The main screen with user info and metrics.";
            TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;

            #region Get the Group ID, given the userID and projectID
            List<int> allGroupsForProject = db.GetGroups().FindAll(g => g.ProjectId == projectID).ConvertAll(g => g.GroupId);
            List<int> allGroupsForUser = db.GetUserProjects().FindAll(u => u.UserId == userID).ConvertAll(g => g.GroupId);
            int groupID = 0;
            foreach (int g in allGroupsForUser)
            {
                foreach (int g2 in allGroupsForProject)
                {
                    if (g == g2)
                        groupID = g;
                }
            }
            #endregion

            // Populate the viewModel and return a view using it
            UserViewModel viewModel = new UserViewModel()
            {
                selectedUser = db.GetUsers().Find(u => u.UserId == userID),
                selectedGroup = db.GetGroups().Find(g => g.GroupId == groupID),
                timeEntries = db.GetTimeEntries().FindAll(te => te.UserId == userID && te.GroupId == groupID)
        };
            return View(viewModel);
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
