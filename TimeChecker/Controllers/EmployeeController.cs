﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeChecker.DAL.Data;
using TimeChecker.DAL.Models;


/**
 * Die Klasse EmployeeController ist die Schnittstelle zwischen 
 * Datenbank und den HTMl Seiten (View's) im Ordner "Views" -> "Employee" angelegt.
 * Den Datenbank Inhalt wird über den Konstruktor übergeben.
 * 
 * Methoden: 
 * 
 * Index() - Die Hauptseite von Employee View, hier wird der Datenbank Inhalt 
 * auf der Webseite übergeben und angezeigt.
 * 
 * CreateEdit() - Bestehender Employee bearbeiten
 * 
 * CreateEditEmployee() - Bestehender Employee bearbeiten updaten oder neuer hinzufügen
 * 
 * DeleteEmployee() - Bestehender Employee bearbeiten
 * 
 * 
 * @Author Jose Panov
 * @Version 2022.01.01
 */


namespace TimeChecker.Controllers
{
    public class EmployeeController : Controller
    {
        // Variable für Datenbankinhalt
        private readonly ApplicationDbContext _context;

        // Dependency injection Übergabe des Datenbankinhalts
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Datenbank Inhalt Employees in Variable employees speichern
            var employees = _context.Employees.ToList();

            // Variable employees in ViewBag übergeben
            ViewBag.Employees = employees;

            // ViewBag wird übergeben
            return View();
        }

        // Bestehender Employee aus Datenbank bearbeiten
        public IActionResult CreateEdit(int id)
        {
            if (id == 0)
            {
                return View("CreateEditEmployee");
            }
            
            var employeeInDb = _context.Employees.Find(id);

            if (employeeInDb == null)
            {
                return NotFound();
            }

            return View("CreateEditEmployee",employeeInDb);

        }

        // Employee hinzufügen oder updaten wenn ID nicht 0 
        [HttpPost]
        public IActionResult CreateEditEmployee(Employee employee)
        {
            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                _context.Employees.Update(employee);         
            }

            _context.SaveChanges();

            // Weiterleitung zur Indexseite
            return RedirectToAction("Index");     
        }

        // Employee löschen
        public IActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _context.Employees.Find(id);

            if (employeeInDb == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();

            // Weiterleitung zur Indexseite
            return RedirectToAction("Index");

        }



    }
}
