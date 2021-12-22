using System;
using System.Collections.Generic;
using System.Windows;

namespace TimeChecker.WPF.Services
{
    class TimeManagerService : ITimeManagerService
    {
        public string User { get; set; }
        public int Type { get; set; }
        public DateTime DateTimeNow { get; set; }
        public string Time { get; set; }
        public string Comment { get; set; }


        public TimeManagerService(string user, int type, DateTime dateTimeNow, string comment)
        {
            User = user;
            Type = type;
            DateTimeNow = dateTimeNow;
            Comment = comment;
            CreateTimeEntry();

        }

        public void CreateTimeEntry()
        {
            //date
            DateTimeNow = DateTime.Now;


            var timeEntry = new Dictionary<string, string>();
            timeEntry.Add("User", User.ToString());
            timeEntry.Add("Type", Type.ToString());
            timeEntry.Add("DateTimeNow", DateTimeNow.ToString());
            timeEntry.Add("Comment", Comment);

            string dictSet = "";
            foreach (var element in timeEntry)
            {
                dictSet = dictSet + $" {element},";
            }
            MessageBox.Show(dictSet);
            //send to dal

        }

    }
}
