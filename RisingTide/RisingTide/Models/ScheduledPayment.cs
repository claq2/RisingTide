using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RisingTide.Models
{
    public class ScheduledPayment : IEntity
    {
        public int Id { get; private set; }

        public bool IsDeleted { get; set; }

        public decimal Amount { get; set; }

        private DateTime payOnDate;
        private DateTime dueDate;
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DueDate
        {
            get { return this.dueDate; }
            set { this.dueDate = value.Date; }
        }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime PayOnDate
        {
            get { return this.payOnDate; }
            set { this.payOnDate = value.Date; }
        }

        public string Subject { get; set; }

        [Display(Name = "Recurrence")]
        public int RecurrenceId { get; set; }

        public virtual Recurrence Recurrence { get; set; }

        [Display(Name = "Type")]
        public int PaymentTypeId { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public bool IncludeInCashFlowAnalysis { get; set; }

        public ScheduledPayment()
        {
            this.IncludeInCashFlowAnalysis = true;
            this.DueDate = DateTime.Today;
            this.PayOnDate = DateTime.Today;
        }

        public DateTime NextPaymentDateAsOf(DateTime specificDate)
        {
            specificDate = specificDate.Date;
            DateTime result = DateTime.MinValue;
            if (this.Recurrence.Name == Recurrence.Weekly)
            {
                result = this.PayOnDate;
                while (result < specificDate)
                {
                    result = result.AddDays(7);
                }
            }
            else if (this.Recurrence.Name == Recurrence.Biweekly)
            {
                result = this.PayOnDate;
                while (result < specificDate)
                {
                    result = result.AddDays(14);
                }
            }
            else if (this.Recurrence.Name == Recurrence.Monthly)
            {
                result = this.PayOnDate;
                while (result < specificDate)
                {
                    result = result.AddMonths(1);
                }
            }
            else if (this.Recurrence.Name == Recurrence.Bimonthly)
            {
                result = this.PayOnDate;
                while (result < specificDate)
                {
                    result = result.AddMonths(2);
                }
            }
            else if (this.Recurrence.Name == Recurrence.None && this.PayOnDate >= specificDate)
            {
                result = this.PayOnDate;
            }

            return result;
        }
    }
}