using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RisingTide.Models;
using RisingTide.DataAccess;

namespace RisingTide.Controllers
{ 
    public class PaymentsController : Controller
    {
        private RisingTideContext db = new RisingTideContext();

        //
        // GET: /Payments/

        public ViewResult Index()
        {
            var scheduledpayments = db.ScheduledPayments;
            return View(scheduledpayments.ToList());
        }

        //
        // GET: /Payments/Details/5

        public ViewResult Details(int id)
        {
            ScheduledPayment scheduledpayment = db.ScheduledPayments.Find(id);
            return View(scheduledpayment);
        }

        //
        // GET: /Payments/Create

        public ActionResult Create()
        {
            ViewBag.RecurrenceId = new SelectList(db.Recurrences, "Id", "Name");
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name");
            return View(new ScheduledPayment());
        } 

        //
        // POST: /Payments/Create

        [HttpPost]
        public ActionResult Create(ScheduledPayment scheduledpayment)
        {
            if (ModelState.IsValid)
            {
                db.ScheduledPayments.Add(scheduledpayment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.RecurrenceId = new SelectList(db.Recurrences, "Id", "Name", scheduledpayment.RecurrenceId);
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name", scheduledpayment.PaymentTypeId);
            return View(scheduledpayment);
        }
        
        //
        // GET: /Payments/Edit/5
 
        public ActionResult Edit(int id)
        {
            ScheduledPayment scheduledpayment = db.ScheduledPayments.Find(id);
            ViewBag.RecurrenceId = new SelectList(db.Recurrences, "Id", "Name", scheduledpayment.RecurrenceId);
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name", scheduledpayment.PaymentTypeId);
            return View(scheduledpayment);
        }

        //
        // POST: /Payments/Edit/5

        [HttpPost]
        public ActionResult Edit(ScheduledPayment scheduledpayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduledpayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecurrenceId = new SelectList(db.Recurrences, "Id", "Name", scheduledpayment.RecurrenceId);
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name", scheduledpayment.PaymentTypeId);
            return View(scheduledpayment);
        }

        //
        // GET: /Payments/Delete/5
 
        public ActionResult Delete(int id)
        {
            ScheduledPayment scheduledpayment = db.ScheduledPayments.Find(id);
            return View(scheduledpayment);
        }

        //
        // POST: /Payments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ScheduledPayment scheduledpayment = db.ScheduledPayments.Find(id);
            db.ScheduledPayments.Remove(scheduledpayment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}