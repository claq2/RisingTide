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

        public List<CalendarDay> GetDayRangeWithPaymentsFor(DateTime startDate, int numberOfDays, decimal initialBalance)
        {
            List<CalendarDay> result = new List<CalendarDay>();
            decimal currentBalance = initialBalance;
            for (int i = 0; i < numberOfDays; i++)
            {
                DateTime currentDate = startDate.AddDays(i).Date;
                result.Add(new CalendarDay() { Date = currentDate, Payments = new List<SinglePayment>() });
                result[i].EndOfDayBalance = currentBalance;
                foreach (ScheduledPayment scheduledPayment in this.Payments)
                {
                    if (scheduledPayment.Recurrence.Name == Recurrence.None && scheduledPayment.PayOnDate != currentDate)
                    {
                        continue;
                    }

                    DateTime nextPaymentDate = scheduledPayment.NextPaymentDateAsOf(currentDate);
                    if (nextPaymentDate == currentDate)
                    {
                        SinglePayment singlePayment = new SinglePayment()
                        {
                            Amount = scheduledPayment.Amount * (scheduledPayment.PaymentType.Name == PaymentType.Debit?-1:1),
                            Payee = scheduledPayment.Payee,
                            ScheduledPaymentId = scheduledPayment.Id,
                            IncludeInCashFlowAnalysis = scheduledPayment.IncludeInCashFlowAnalysis
                        };

                        result[i].Payments.Add(singlePayment);

                        if (scheduledPayment.IncludeInCashFlowAnalysis)
                        {
                            result[i].EndOfDayBalance += singlePayment.Amount;
                        }
                    }
                }

                result[i].Payments.Sort();
                currentBalance = result[i].EndOfDayBalance;
            }

            return result;
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