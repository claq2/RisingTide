using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RisingTide.ViewModels
{
    public class SinglePaymentWithDate : SinglePayment, IComparable
    {
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        public override int CompareTo(object obj)
        {
            SinglePaymentWithDate otherAsPaymentDate = obj as SinglePaymentWithDate;
            if (otherAsPaymentDate == null)
            {
                throw new ArgumentException("obj is not a PaymentOnDate");
            }

            if (otherAsPaymentDate.PaymentDate == this.PaymentDate)
            {
                return base.CompareTo(otherAsPaymentDate);
                //if (otherAsPaymentDate.IsDebit == this.IsDebit)
                //{
                //    return 0;
                //}
                //else if (this.IsDebit && !otherAsPaymentDate.IsDebit)
                //{
                //    //this is debit and the other is credit so this comes after
                //    return 1;
                //}
                //else
                //{
                //    // this is credit and other is debit so this comes first
                //    return -1;
                //}
            }
            else
            {
                return this.PaymentDate.CompareTo(otherAsPaymentDate.PaymentDate);
            }
        }
    }
}