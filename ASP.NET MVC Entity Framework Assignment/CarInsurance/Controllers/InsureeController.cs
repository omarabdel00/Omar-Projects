using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities1 db = new InsuranceEntities1();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarMode1,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Start with a base of $50 / month
                decimal monthlyTotal = 50;

                // If the user is 18 or under, add $100 to the monthly total
                if (DateTime.Now.Year - insuree.DateOfBirth.Year <= 18)
                {
                    monthlyTotal += 100;
                }
                // If the user is from 19 to 25, add $50 to the monthly total
                else if (DateTime.Now.Year - insuree.DateOfBirth.Year <= 25)
                {
                    monthlyTotal += 50;
                }
                // If the user is 26 or older, add $25 to the monthly total
                else
                {
                    monthlyTotal += 25;
                }

                // If the car's year is before 2000, add $25 to the monthly total
                if (insuree.CarYear < 2000)
                {
                    monthlyTotal += 25;
                }
                // If the car's year is after 2015, add $25 to the monthly total
                else if (insuree.CarYear > 2015)
                {
                    monthlyTotal += 25;
                }

                // If the car's Make is a Porsche, add $25 to the price
                if (insuree.CarMake.ToLower() == "porsche")
                {
                    monthlyTotal += 25;

                    // If the car's Make is a Porsche and its model is a 911 Carrera, add an additional $25 to the price
                    if (insuree.CarMode1.ToLower() == "911 carrera")
                    {
                        monthlyTotal += 25;
                    }
                }

                // Add $10 to the monthly total for every speeding ticket the user has
                monthlyTotal += 10 * insuree.SpeedingTickets;

                // If the user has ever had a DUI, add 25% to the total
                if (insuree.DUI)
                {
                    monthlyTotal += monthlyTotal * 0.25m;
                }

                // If it's full coverage, add 50% to the total
                if (insuree.CoverageType)
                {
                    monthlyTotal += monthlyTotal * 0.5m;
                }

                // Set the calculated quote
                insuree.Quote = monthlyTotal;

                // Save the insuree object to the database
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarMode1,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }



        // GET: Insuree/Admin
        public ActionResult Admin()
        {
            var quotes = db.Insurees.ToList();

            return View(quotes); // Pass the quotes directly to the view
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
