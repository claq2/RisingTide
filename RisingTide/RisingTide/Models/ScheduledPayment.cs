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

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime FirstPayment { get; set; }

        public string Payee { get; set; }

        [Display(Name="Recurrence")]
        public int RecurrenceId { get; set; }

        public virtual Recurrence Recurrence { get; set; }

        [Display(Name="Type")]
        public int PaymentTypeId { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public bool IncludeInProjection { get; set; }
    }
}