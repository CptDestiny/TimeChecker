using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeChecker.DAL.Data;
using TimeChecker.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace TimeCheckerWPF5._0
{
    public class Class2
    {

        private  ApplicationDbContext _context;

        public Class2(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Timeentry> GetTodoItems()
        {
            var timeentry = _context.Timeentry.ToList();

            return timeentry;
        }




        //public IActionResult CreateEdit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return View("CreateEditTimeentry");
        //    }

        //    var timeentryInDb = _context.Timeentry.Find(id);

        //    if (timeentryInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View("CreateEditTimeentry", timeentryInDb);

        //}


        //[HttpPost]
        //public IActionResult CreateEditTimeentry(Timeentry timeentry)
        //{
        //    if (timeentry.ID == 0)
        //    {
        //        _context.Timeentry.Add(timeentry);
        //    }
        //    else
        //    {
        //        _context.Timeentry.Update(timeentry);
        //    }

        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}


        //public IActionResult DeleteTimeentry(int id)
        //{
        //    var timeentryInDb = _context.Timeentry.Find(id);

        //    if (timeentryInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Timeentry.Remove(timeentryInDb);
        //    _context.SaveChanges();


        //    return RedirectToAction("Index");

        //}
    }
}
    

