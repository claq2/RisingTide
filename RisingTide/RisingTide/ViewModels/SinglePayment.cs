using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisingTide.Models;

namespace RisingTide.ViewModels
{
    public class SinglePayment : IComparable
    {
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public string Subject { get; set; }
        public int ScheduledPaymentId { get; set; }
        public bool IncludeInCashFlowAnalysis { get; set; }

        /// <summary>
        /// Initializes a new instance of the SinglePayment class.
        /// </summary>
        public SinglePayment()
        {
            this.PaymentType = new PaymentType();
        }

        public virtual int CompareTo(object obj)
        {
            SinglePayment otherAsPayment = obj as SinglePayment;
            if (otherAsPayment == null)
            {
                throw new ArgumentException("obj is not a SinglePayment");
            }

            if (otherAsPayment.PaymentType.Name == this.PaymentType.Name)
            {
                return 0;
            }
            else if (this.PaymentType.Name == PaymentType.Debit && otherAsPayment.PaymentType.Name == PaymentType.Credit)
            {
                //this is debit and the other is credit so this comes after
                return 1;
            }
            else
            {
                // this is credit and other is debit so this comes first
                return -1;
            }
        }
    }
}