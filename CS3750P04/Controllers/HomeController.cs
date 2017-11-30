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
           // TimeTrackerEntityContext db = new TimeTrackerEntityContext("server=localhost;database=CS3750P04;user=student;password=picklerick");
            //TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            //db.GetUsers();
            //db.GetGroups();
            //db.GetProjects();
            //db.GetUserProjects();

            //User user = db.GetUsers()[0];

            //user.FirstName = "new first name";

            //Project proj = db.GetProjects()[0];

            //proj.ProjectName = "updated name";

            //db.updateProject(proj);

            //Group group = db.GetGroups()[0];

            //group.GroupName = "Updated Group Name";

            //db.updateGroup(group);

            //TimeEntry time = db.GetTimeEntries()[0];

            //time.TimeStop = null;

            //db.updateTimeEntry(time);

           // db.updateUser(user);

            //db.GetUsers();

            //db.addUser(new Models.User()
            //{
            //    ScreenName = "Added from db",
            //    FirstName = "Something",
            //    LastName = "Special",
            //    isActive = true,
            //    UserHash = "Not implemeneted yet"
            //});
            //db.addProject(new Models.Project()
            //{
            //    ProjectName = "Test Project",
            //    Active = true
            //});

            //db.GetUsers();
            //db.GetProjects();

            //db.addGroup(new Group()
            //{
            //    GroupName = "Test Group",
            //    ProjectId = 1
            //});

            //db.GetGroups();

            //db.addUserProject(new UserProject()
            //{
            //    UserId = 1,
            //    GroupId = 1
            //});

            //db.GetUserProjects();

            //db.addTimeEntry(new TimeEntry()
            //{
            //    TimeStart = DateTime.UtcNow,
            //    UserId = 1,
            //    CreateDate = DateTime.UtcNow,
            //    Deleted = false,
            //    EntryComment = "fadfda"
            //});

            //db.GetTimeEntries();

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
