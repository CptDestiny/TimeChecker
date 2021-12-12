using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using Microsoft.VisualBasic;

namespace TimeChecker.BLL
{
    public partial class BusinessLogic
    {
        private int User { get; set; }
        private int Type { get; set; }
        private string Date { get; set; }
        private string Time { get; set; }
        private string Comment { get; set; }

        public bool CreateTimeEntry(int entryType, string user, string comment)
        {
            //date
            var actualDate = DateTime.Now.ToShortDateString();
            //Time
            var actualTime = DateTime.Now.ToShortTimeString();

            var timeEntry = new Dictionary<string, string>();
            timeEntry.Add("User", user);
            timeEntry.Add("Type",entryType.ToString());
            timeEntry.Add("Date", actualDate);
            timeEntry.Add("Time", actualTime);
            timeEntry.Add("Comment", comment);
            
            //send the set to DAL?

            return true;
        }



    }
}
