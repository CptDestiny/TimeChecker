﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeChecker.DAL.Data;
using TimeChecker.DAL.Models;
using TimeChecker.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

namespace TimeChecker.Controllers
{
    [Authorize]
    public class TimeentryController : Controller
    {
        // Variable für Datenbankinhalt
        private readonly ApplicationDbContext _context;

        const string pathtxt = @"C:\Users\jopa\Desktop\Timeentry_Data.txt";


        // Dependency injection Übergabe des Datenbankinhalts
        public TimeentryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            // Datenbankinhalt Timeentry in Variable employees speichern
            var timeentry = _context.Timeentry.ToList();
        
            // Variable timeentry in ViewBag übergeben
             ViewBag.Timeentry = timeentry;
            
             // ViewBag wird übergeben
             return View();            
        }

        // Bestehender Timeentry aus Datenbank bearbeiten
        public IActionResult CreateEdit(int id)
        {
            if (id == 0)
            {
                return View("CreateEditTimeentry");
            }

            var timeentryInDb = _context.Timeentry.Find(id);

            if (timeentryInDb == null)
            {
                return NotFound();
            }

            return View("CreateEditTimeentry", timeentryInDb);

        }

        // Timeentry hinzufügen oder updaten wenn ID nicht 0 
        [HttpPost]
        public IActionResult CreateEditTimeentry(Timeentry timeentry)
        {
            if (timeentry.ID == 0)
            {
                _context.Timeentry.Add(timeentry);
            }
            else
            {
                _context.Timeentry.Update(timeentry);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Timeentry löschen
        public IActionResult DeleteTimeentry(int id)
        {
            var timeentryInDb = _context.Timeentry.Find(id);

            if (timeentryInDb == null)
            {
                return NotFound();
                
            }

            _context.Timeentry.Remove(timeentryInDb);
            _context.SaveChanges();


            return RedirectToAction("Index");

        }

        // Timeentry Daten in Textdatei exportieren
        public IActionResult Export()
        {
            var timeentryinDB = _context.Timeentry.ToList();

            SaveWithStream(pathtxt, timeentryinDB);

            return RedirectToAction("Index");
        }

        // Textdatei via stream speichern
        private static void SaveWithStream(string path, List<Timeentry> timeentryinDB)
        {
            var convertString = "";

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (TextWriter writer = new StreamWriter(fs))
            {
            
                foreach (var timeentry in timeentryinDB)
                {

                        switch (timeentry.Type)
                        {
                            case 1:
                            convertString = timeentry.Type.ToString("Check In");
                            break;
                            
                            case 2:
                            convertString = timeentry.Type.ToString("Check Out");
                            break;

                            case 3:
                            convertString = timeentry.Type.ToString("Start Break");
                            break;

                            case 4:
                            convertString = timeentry.Type.ToString("Stop Break");
                            break;

                            default: 
                            break;

                        }

                    if (timeentry.Comment == null)
                    {
                        timeentry.Comment = "Leer";
                    }

                    writer.WriteLine(convertString);
                    writer.WriteLine(timeentry.DateTime);
                    writer.WriteLine(timeentry.Comment);
                    writer.WriteLine(timeentry.User);
                    writer.WriteLine();
                }

                 
                
            }
        }
    }
}
