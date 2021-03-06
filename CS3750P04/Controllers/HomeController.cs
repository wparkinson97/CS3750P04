﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CS3750P04.Models;
using CS3750P04.ViewModels;
using System.Data;
using System.Web;

namespace CS3750P04.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? projectID, int? userID)
        {
            //TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            int? id = (int?)(HttpContext.Session.GetInt32("userId")) ?? -1;
            if (id == -1)
                return RedirectToAction("Login");

            projectID = projectID ?? 1;
            userID = userID ?? id;

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
                allGroups = db.GetGroups(),
                timeEntries = db.GetTimeEntries().FindAll(te => te.UserId == userID && te.GroupId == groupID)
            };
            return View(viewModel);
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
        public IActionResult CreateUser(string username, string password, string firstName, string lastName, int groupId)
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
        [HttpGet]
        public IActionResult TrackTime()
        {
            int? id = (int?)(HttpContext.Session.GetInt32("userId")) ?? -1;
            if (id == -1)
                return RedirectToAction("Login");

            TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            var entrys = db.GetTimeEntries().Where(tt => tt.UserId == id && tt.TimeStop == null);
            
            return View(entrys.FirstOrDefault());
        }
        [HttpPost]
        public IActionResult endTrack(DateTime timeStop,int timeEntryId)
        {
            TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            TimeEntry existingEntry =  db.GetTimeEntries().Find(te => te.TimeEntryId == timeEntryId);
            existingEntry.TimeStop = timeStop;
            db.updateTimeEntry(existingEntry);
            return RedirectToAction("TrackTime");
        }
        [HttpPost]
        public IActionResult startTrack(DateTime startTime)
        {
            int? id = (int?)(HttpContext.Session.GetInt32("userId")) ?? -1;
            if (id == -1)
                return RedirectToAction("Login");
            TimeTrackerEntityContext db = HttpContext.RequestServices.GetService(typeof(TimeTrackerEntityContext)) as TimeTrackerEntityContext;
            db.addTimeEntry(new TimeEntry()
            {
                TimeStart = startTime,
                CreateDate = DateTime.UtcNow,
                Deleted = false,
                EntryComment = "",
                GroupId = db.GetUserProjects().Where(u => u.UserId == id).FirstOrDefault().GroupId,
                TimeStop = null,
                UserId = (int)id
            });
            return RedirectToAction("TrackTime") ;
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
                allGroups = db.GetGroups(),
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