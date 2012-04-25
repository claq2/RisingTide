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
        private IDomainContext db = new RisingTideContext();

        //
        // GET: /Payments/

        public ViewResult Index()
        {
            return View(db.ScheduledPayments.ToList());
        }

        //
        // GET: /Payments/Details/5

        public ViewResult Details(int id)
        {
            ScheduledPayment scheduledpayment = db.ScheduledPayments.FirstOrDefault(s => s.Id == id);
            return View(scheduledpayment);
        }

        //
        // GET: /Payments/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Payments/Create

        [HttpPost]
        public ActionResult Create(ScheduledPayment scheduledpayment)
        {
            if (ModelState.IsValid)
            {
                db.Save<ScheduledPayment>(scheduledpayment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(scheduledpayment);
        }
        
        //
        // GET: /Payments/Edit/5
 
        public ActionResult Edit(int id)
        {
            ScheduledPayment scheduledpayment = db.ScheduledPayments.FirstOrDefault(s => s.Id == id);
            return View(scheduledpayment);
        }

        //
        // POST: /Payments/Edit/5

        [HttpPost]
        public ActionResult Edit(ScheduledPayment scheduledpayment)
        {
            if (ModelState.IsValid)
            {
                db.Save<ScheduledPayment>(scheduledpayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduledpayment);
        }

        //
        // GET: /Payments/Delete/5
 
        public ActionResult Delete(int id)
        {
            ScheduledPayment scheduledpayment = db.ScheduledPayments.FirstOrDefault(s => s.Id == id);
            return View(scheduledpayment);
        }

        //
        // POST: /Payments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete<ScheduledPayment>(id);
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