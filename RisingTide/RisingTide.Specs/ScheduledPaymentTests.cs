using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using RisingTide.Models;

namespace RisingTide.Specs
{
    public class ScheduledPaymentTests
    {
        [Subject("ScheduledPayment Creation")]
        public class when_creating_a_scheduled_payment
        {
            static ScheduledPayment payment;
            Because of = () => payment = new ScheduledPayment();
            It should_not_be_deleted = () => payment.IsDeleted.ShouldBeFalse();
            It should_be_included_in_projections = () => payment.IncludeInCashFlowAnalysis.ShouldBeTrue();
            It should_have_todays_date_for_due_date = () => payment.DueDate.ShouldEqual(DateTime.Today);
            It should_have_todays_date_for_payment_date = () => payment.PayOnDate.ShouldEqual(DateTime.Today);
        }
    }
}