using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RisingTide.Models;
using Machine.Specifications;
using RisingTide.ViewModels;
using System.Collections.ObjectModel;

namespace RisingTide.Specs
{
    public class UserTests
    {
        public class when_generating_a_list_of_90_days_with_1_weekly_1_dollar_payment
        {
            static User user;
            static ScheduledPayment scheduledPayment;
            static List<CalendarDay> result;
            Establish context = () =>
                {
                    user = new User() { Payments = new Collection<ScheduledPayment>() };
                    scheduledPayment = new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Weekly }, Amount = 1.00M };
                    user.AddScheduledPayment(scheduledPayment);
                };

            Because of = () => result = user.GetDayRangeWithPaymentsFor(DateTime.Today, 90, 0);

            It should_have_a_balance_of_minus_12_dollars_on_the_last_day = () => result[89].EndOfDayBalance.ShouldEqual(-13.00M);
        }
    }
}
