using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisingTide.DataAccess;

namespace RisingTide.Models
{
    public class ScheduledPayments : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the ScheduledPaymentLibrary class.
        /// </summary>
        public ScheduledPayments()
            : this(new RisingTideContext())
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the ScheduledPaymentLibrary class.
        /// </summary>
        /// <param name="context"></param>
        public ScheduledPayments(IDomainContext context)
        {
            this.context = context;
        }

        readonly IDomainContext context;

        public void Add(ScheduledPayment scheduledPayment)
        {
            context.Save<ScheduledPayment>(scheduledPayment);
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        ~ScheduledPayments()
        {
            Dispose(false);
        }
    }
}