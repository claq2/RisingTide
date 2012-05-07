using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RisingTide.Models;
using System.Collections.ObjectModel;
using RisingTide.ViewModels;
using Machine.Specifications;

namespace RisingTide.Specs
{
    public class ScheduledPaymentCollectionTests
    {
        public class when_generating_a_list_of_90_days_with_1_weekly_1_dollar_payment
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static List<CalendarDay> result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Weekly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.GetDayRangeWithPaymentsFor(DateTime.Today, 90, 0);

            It should_have_a_balance_of_minus_12_dollars_on_the_last_day = () => result[89].EndOfDayBalance.ShouldEqual(-13.00M);
        }
    }
}
