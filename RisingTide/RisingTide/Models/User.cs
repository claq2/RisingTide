using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using RisingTide.DataAccess;

namespace RisingTide.Models
{
    public class User : IEntity, IDisposable
    {
        public readonly IDomainContext context;
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual ICollection<ScheduledPayment> Payments { get; set; }
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Initializes a new instance of the ScheduledPaymentLibrary class.
        /// </summary>
        public User()
            : this(new RisingTideContext())
        {

        }

        /// <summary>
        /// Initializes a new instance of the ScheduledPaymentLibrary class.
        /// </summary>
        /// <param name="context"></param>
        public User(IDomainContext context)
        {
            this.context = context;
        }

        ~User()
        {
            Dispose(false);
        }

        public void AddScheduledPayment(ScheduledPayment scheduledPayment)
        {
            this.context.Save<ScheduledPayment>(scheduledPayment);
            this.Payments.Add(scheduledPayment);
            this.context.SaveChanges();
        }

        public void DeleteScheduledPayment(ScheduledPayment scheduledPayment)
        {
            if (this.Payments.Contains(scheduledPayment))
            {
                this.Payments.Remove(scheduledPayment);
                this.context.Delete<ScheduledPayment>(scheduledPayment.Id);
                this.context.SaveChanges();
            }
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
    }
}