using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RisingTide.ViewModels
{
    public class SinglePaymentWithDate : SinglePayment, IComparable
    {
        public DateTime PaymentDate { get; set; }
    }
}