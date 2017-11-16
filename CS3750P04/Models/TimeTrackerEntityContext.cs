using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CS3750P04.Models
{
    public class TimeTrackerEntityContext
    {
        public string connectionString { get; set; }

        public TimeTrackerEntityContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select * FROM User",conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            UserId = reader.GetInt32("userId"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            isActive = reader.GetBoolean("isActive"),
                            ScreenName = reader.GetString("ScreenName"),
                            UserHash = reader.GetString("UserHash")
                        });
                    }
                }
            }   
            return users;
        }

        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Project", conn);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projects.Add(new Project()
                        {
                            ProjectId = reader.GetInt32("projectId"),
                            ProjectName = reader.GetString("projectName"),
                            Active = reader.GetBoolean("Active")
                        });
                    }
                }
            }
            return projects;
        }

        public List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Group`", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) {
                        groups.Add(new Group()
                        {
                            GroupId = reader.GetInt32("GroupId"),
                            GroupName = reader.GetString("GroupName"),
                            ProjectId = reader.GetInt32("ProjectId")
                        });
                    }
                }
            }
            return groups;
        }

        public List<UserProject> GetUserProjects()
        {
            List<UserProject> userProjects = new List<UserProject>();
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM UserProject", conn);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userProjects.Add(new UserProject()
                        {
                            UserProjectId = reader.GetInt32("UserProjectId"),
                            UserId = reader.GetInt32("UserId"),
                            GroupId = reader.GetInt32("GroupId"),
                            ProjectId = reader.GetInt32("ProjectId")
                        });
                    }
                }
            }
            return userProjects;
        }

        public List<TimeEntry> GetTimeEntries()
        {
            List<TimeEntry> timeEntries = new List<TimeEntry>();
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TimeEntry", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        timeEntries.Add(new TimeEntry()
                        {
                            TimeEntryId = reader.GetInt64("TimeEntryId"),
                            TimeStart = reader.GetDateTime("TimeStart"),
                            TimeStop = reader.GetDateTime("TimeStop"),
                            Deleted = reader.GetBoolean("Deleted"),
                            EntryComment = reader.GetString("EntryComment"),
                            UserId = reader.GetInt32("UserId")
                        });
                    }
                }
            }
            return timeEntries;
        }

        public List<TimeEntryHistory> GetTimeEntryHistories()
        {
            List<TimeEntryHistory> timeEntryHistories = new List<TimeEntryHistory>();

            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TimeEntryHistory", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        timeEntryHistories.Add(new TimeEntryHistory()
                        {
                            TimeEntryHistoryId = reader.GetInt64("TimeEntryHistoryId"),
                            TimeEntryId = reader.GetInt64("TimeEntryId"),
                            ChangedField = reader.GetString("ChangedField"),
                            NewValue = reader.GetString("NewValue"),
                            OldValue = reader.GetString("OldValue"),
                        });
                    }
                }
            }
            
            return timeEntryHistories;
        }

        

        

        
    }
}
