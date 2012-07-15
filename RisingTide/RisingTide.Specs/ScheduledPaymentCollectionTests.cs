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
        public class when_generating_a_list_of_90_days_with_1_weekly_1_dollar_payment_and_0_initial_balance
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static List<CalendarDay> result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Weekly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.GetDayRangeWithPaymentsFor(DateTime.Today, 90, 0);

            It should_have_a_balance_of_minus_1_dollar_on_the_first_day = () => result[0].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_second_day = () => result[1].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_seventh_day = () => result[6].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_2_dollars_on_the_eighth_day = () => result[7].EndOfDayBalance.ShouldEqual(-2.00M);
            It should_have_a_balance_of_minus_13_dollars_on_the_last_day = () => result[89].EndOfDayBalance.ShouldEqual(-13.00M);
        }

        public class when_generating_a_list_of_90_days_with_1_biweekly_1_dollar_payment_and_0_initial_balance
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static List<CalendarDay> result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Biweekly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.GetDayRangeWithPaymentsFor(DateTime.Today, 90, 0);

            It should_have_a_balance_of_minus_1_dollar_on_the_first_day = () => result[0].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_second_day = () => result[1].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_forteenth_day = () => result[13].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_2_dollars_on_the_fifteenth_day = () => result[15].EndOfDayBalance.ShouldEqual(-2.00M);
            It should_have_a_balance_of_minus_7_dollars_on_the_last_day = () => result[89].EndOfDayBalance.ShouldEqual(-7.00M);
        }

        public class when_generating_a_list_of_90_days_with_1_monthly_1_dollar_payment_and_0_initial_balance
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static List<CalendarDay> result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Monthly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.GetDayRangeWithPaymentsFor(DateTime.Today, 90, 0);

            It should_have_a_balance_of_minus_1_dollar_on_the_first_day = () => result[0].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_second_day = () => result[1].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_forteenth_day = () => result[13].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_2_dollars_a_month_from_today = () =>
            {
                int index = (DateTime.Today.AddMonths(1) - DateTime.Today).Days;
                result[index].EndOfDayBalance.ShouldEqual(-2.00M);
            };
            It should_have_a_balance_of_minus_3_dollars_on_the_last_day = () => result[89].EndOfDayBalance.ShouldEqual(-3.00M);
        }

        public class when_generating_a_list_of_90_days_with_1_bimonthly_1_dollar_payment_and_0_initial_balance
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static List<CalendarDay> result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Bimonthly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.GetDayRangeWithPaymentsFor(DateTime.Today, 90, 0);

            It should_have_a_balance_of_minus_1_dollar_on_the_first_day = () => result[0].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_second_day = () => result[1].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_forteenth_day = () => result[13].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_2_dollars_a_month_from_today = () =>
            {
                int index = (DateTime.Today.AddMonths(2) - DateTime.Today).Days;
                result[index].EndOfDayBalance.ShouldEqual(-2.00M);
            };
            It should_have_a_balance_of_minus_2_dollars_on_the_last_day = () => result[89].EndOfDayBalance.ShouldEqual(-2.00M);
        }

        public class when_generating_a_list_of_90_days_with_1_weekly_1_dollar_payment_and_20_initial_balance
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static List<CalendarDay> result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Weekly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.GetDayRangeWithPaymentsFor(DateTime.Today, 90, 20);

            It should_have_a_balance_of_19_dollars_on_the_first_day = () => result[0].EndOfDayBalance.ShouldEqual(19.00M);
            It should_have_a_balance_of_19_dollars_on_the_second_day = () => result[1].EndOfDayBalance.ShouldEqual(19.00M);
            It should_have_a_balance_of_19_dollars_on_the_seventh_day = () => result[6].EndOfDayBalance.ShouldEqual(19.00M);
            It should_have_a_balance_of_18_dollars_on_the_eighth_day = () => result[7].EndOfDayBalance.ShouldEqual(18.00M);
            It should_have_a_balance_of_7_dollars_on_the_last_day = () => result[89].EndOfDayBalance.ShouldEqual(7.00M);
        }

        public class when_generating_a_list_of_90_days_with_1_biweekly_1_dollar_payment_and_20_initial_balance
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static List<CalendarDay> result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Biweekly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.GetDayRangeWithPaymentsFor(DateTime.Today, 90, 20);

            It should_have_a_balance_of_19_dollars_on_the_first_day = () => result[0].EndOfDayBalance.ShouldEqual(19.00M);
            It should_have_a_balance_of_19_dollars_on_the_second_day = () => result[1].EndOfDayBalance.ShouldEqual(19.00M);
            It should_have_a_balance_of_19_dollars_on_the_forteenth_day = () => result[13].EndOfDayBalance.ShouldEqual(19.00M);
            It should_have_a_balance_of_18_dollars_on_the_fifteenth_day = () => result[15].EndOfDayBalance.ShouldEqual(18.00M);
            It should_have_a_balance_of_13_dollars_on_the_last_day = () => result[89].EndOfDayBalance.ShouldEqual(13.00M);
        }

        public class when_generating_the_upcoming_payments_with_1_nonrecurring_payment
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static List<SinglePaymentWithDate> result;
            Establish context = () =>
                {
                    scheduledPayments = new Collection<ScheduledPayment>();
                    scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.None }, Amount = 1.00M });
                };

            Because of = () => result = scheduledPayments.GetUpcomingPayments(DateTime.Now);

            It should_have_1_payment_of_1_dollar = () => result[0].Amount.ShouldEqual(-1.00M);
            It should_have_1_payment_with_todays_date = () => result[0].PaymentDate.ShouldEqual(DateTime.Now.Date);
        }

        public class when_generating_a_list_of_90_days_with_1_lastdayofmonth_1_dollar_payment_on_may_31_and_0_initial_balance
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static List<CalendarDay> result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                // Add payment with date May 31, 2012
                scheduledPayments.Add(new ScheduledPayment() 
                {
                    PaymentType = new PaymentType() { Name = PaymentType.Debit }, 
                    Recurrence = new Recurrence() { Name = Recurrence.LastDayOfMonth }, 
                    Amount = 1.00M, 
                    PayOnDate = new DateTime(2012, 5, 31) 
                });
            };

            Because of = () => result = scheduledPayments.GetDayRangeWithPaymentsFor(new DateTime(2012, 5, 31), 90, 0);

            It should_have_a_balance_of_minus_1_dollar_on_the_first_day = () => result[0].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_second_day = () => result[1].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_1_dollar_on_the_forteenth_day = () => result[13].EndOfDayBalance.ShouldEqual(-1.00M);
            It should_have_a_balance_of_minus_2_dollars_on_june_30 = () => result[30].EndOfDayBalance.ShouldEqual(-2.00M);
            It should_have_a_balance_of_minus_3_dollars_on_the_last_day = () => result[89].EndOfDayBalance.ShouldEqual(-3.00M);
        }
    }
}