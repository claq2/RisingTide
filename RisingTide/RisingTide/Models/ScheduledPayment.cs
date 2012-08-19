using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RisingTide.Models
{
    public class ScheduledPayment : IEntity
    {
        public virtual int Id { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual decimal Amount { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }

        private DateTime payOnDate;
        private DateTime dueDate;
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual DateTime DueDate
        {
            get { return this.dueDate; }
            set { this.dueDate = value.Date; }
        }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual DateTime PayOnDate
        {
            get { return this.payOnDate; }
            set { this.payOnDate = value.Date; }
        }

        public virtual string Subject { get; set; }

        [Display(Name = "Recurrence")]
        public virtual int RecurrenceId { get; set; }

        public virtual Recurrence Recurrence { get; set; }

        [Display(Name = "Type")]
        public virtual int PaymentTypeId { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual bool IncludeInCashFlowAnalysis { get; set; }

        public ScheduledPayment()
        {
            this.IncludeInCashFlowAnalysis = true;
            this.DueDate = DateTime.Today;
            this.PayOnDate = DateTime.Today;
        }

        public DateTime NextDueDateAsOf(DateTime specificDate)
        {
            return this.NextDateAsOf(this.DueDate, specificDate);
        }

        public DateTime NextPaymentDateAsOf(DateTime specificDate)
        {
            return this.NextDateAsOf(this.PayOnDate, specificDate);
        }

        private DateTime NextDateAsOf(DateTime startDate, DateTime specificDate)
        {
            specificDate = specificDate.Date;
            DateTime result = DateTime.MinValue;
            if (this.Recurrence.Name == Recurrence.Weekly)
            {
                result = startDate;
                while (result < specificDate)
                {
                    result = result.AddDays(7);
                }
            }
            else if (this.Recurrence.Name == Recurrence.Biweekly)
            {
                result = startDate;
                while (result < specificDate)
                {
                    result = result.AddDays(14);
                }
            }
            else if (this.Recurrence.Name == Recurrence.Monthly)
            {
                result = startDate;
                while (result < specificDate)
                {
                    result = result.AddMonths(1);
                }
            }
            else if (this.Recurrence.Name == Recurrence.Bimonthly)
            {
                result = startDate;
                while (result < specificDate)
                {
                    result = result.AddMonths(2);
                }
            }
            else if (this.Recurrence.Name == Recurrence.LastDayOfMonth)
            {
                result = startDate.LastDayOfMonth();
                while (result < specificDate)
                {
                    result = result.AddMonths(1).LastDayOfMonth();
                }
            }
            else if (this.Recurrence.Name == Recurrence.None && startDate >= specificDate)
            {
                result = startDate;
            }

            return result;
        }
    }
}