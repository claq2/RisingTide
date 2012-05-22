using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using RisingTide.DataAccess;
using RisingTide.ViewModels;

namespace RisingTide.Models
{
    public class User : IEntity, IDisposable
    {
        public IDomainContext Context { get; set; }
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
            this.Context = context;
        }

        ~User()
        {
            Dispose(false);
        }

        public void AddScheduledPayment(ScheduledPayment scheduledPayment)
        {
            this.Context.Save<ScheduledPayment>(scheduledPayment);
            this.Payments.Add(scheduledPayment);
            this.Context.SaveChanges();
        }

        public void DeleteScheduledPayment(ScheduledPayment scheduledPayment)
        {
            if (this.Payments.Contains(scheduledPayment))
            {
                this.Payments.Remove(scheduledPayment);
                this.Context.Delete<ScheduledPayment>(scheduledPayment.Id);
                this.Context.SaveChanges();
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