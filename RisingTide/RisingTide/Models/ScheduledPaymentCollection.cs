using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisingTide.DataAccess;
using System.Collections.ObjectModel;
using RisingTide.ViewModels;

namespace RisingTide.Models
{
    public class ScheduledPaymentCollection : Collection<ScheduledPayment>, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the ScheduledPaymentLibrary class.
        /// </summary>
        public ScheduledPaymentCollection()
            : this(new RisingTideContext())
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the ScheduledPaymentLibrary class.
        /// </summary>
        /// <param name="context"></param>
        public ScheduledPaymentCollection(IDomainContext context)
        {
            this.context = context;
        }

        readonly IDomainContext context;

        public void AddScheduledPayment(ScheduledPayment scheduledPayment)
        {
            base.Add(scheduledPayment);
            context.Save<ScheduledPayment>(scheduledPayment);
            context.SaveChanges();
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
                foreach (ScheduledPayment scheduledPayment in this.Items)
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
                            Amount = scheduledPayment.Amount * (scheduledPayment.PaymentType.Name == PaymentType.Debit ? -1 : 1),
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

        ~ScheduledPaymentCollection()
        {
            Dispose(false);
        }
    }
}