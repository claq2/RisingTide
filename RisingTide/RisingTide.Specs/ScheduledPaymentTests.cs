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
            It should_have_todays_date_for_due_date = () => payment.DueDate.ShouldEqual(DateTime.Today.Date);
            It should_have_todays_date_for_payment_date = () => payment.PayOnDate.ShouldEqual(DateTime.Today.Date);
        }

        public class when_asking_for_the_next_payment_date_of_a_nonrecurring_scheduled_payment_with_todays_date
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.None } };
            };
            Because of = () => result = payment.NextPaymentDateAsOf(DateTime.Today);
            It should_be_today = () => result.ShouldEqual(DateTime.Today);
        }

        public class when_asking_for_the_next_payment_date_of_a_nonrecurring_scheduled_payment_with_a_past_date
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.None }, PayOnDate = DateTime.Today.AddDays(-1) };
            };
            Because of = () => result = payment.NextPaymentDateAsOf(DateTime.Today);
            It should_be_min_datetime = () => result.ShouldEqual(DateTime.MinValue);
        }

        public class when_asking_for_the_next_payment_date_of_a_weekly_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.Weekly } };
            };
            Because of = () => result = payment.NextPaymentDateAsOf(DateTime.Today.AddDays(1));
            It should_be_7_days_from_tomorrow = () => result.ShouldEqual(DateTime.Today.AddDays(7));
        }

        public class when_asking_for_the_next_payment_date_of_a_biweekly_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.Biweekly } };
            };
            Because of = () => result = payment.NextPaymentDateAsOf(DateTime.Today.AddDays(1));
            It should_be_14_days_from_tomorrow = () => result.ShouldEqual(DateTime.Today.AddDays(14));
        }

        public class when_asking_for_the_next_payment_date_of_a_monthly_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.Monthly } };
            };
            Because of = () => result = payment.NextPaymentDateAsOf(DateTime.Today.AddDays(1));
            It should_be_a_month_from_tomorrow = () => result.ShouldEqual(DateTime.Today.AddMonths(1));
        }

        public class when_asking_for_the_next_payment_date_of_a_bimonthly_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.Bimonthly } };
            };
            Because of = () => result = payment.NextPaymentDateAsOf(DateTime.Today.AddDays(1));
            It should_be_2_months_from_tomorrow = () => result.ShouldEqual(DateTime.Today.AddMonths(2));
        }

        public class when_asking_for_the_next_payment_date_of_an_end_of_month_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.LastDayOfMonth } };
            };
            Because of = () => result = payment.NextPaymentDateAsOf(DateTime.Today.AddDays(1));
            It should_be_the_last_day_of_this_month = () => result.ShouldEqual(DateTime.Today.LastDayOfMonth());
        }

        public class when_asking_for_the_next_payment_date_of_an_end_of_month_scheduled_payment_may_31
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.LastDayOfMonth }, PayOnDate = new DateTime(2012, 5, 31) };
            };
            Because of = () => result = payment.NextPaymentDateAsOf(new DateTime(2012, 5, 31));
            It should_be_may_31 = () => result.ShouldEqual(new DateTime(2012, 5, 31));
        }

        public class when_asking_for_the_next_due_date_of_a_nonrecurring_scheduled_payment_with_todays_date
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.None } };
            };
            Because of = () => result = payment.NextDueDateAsOf(DateTime.Today);
            It should_be_today = () => result.ShouldEqual(DateTime.Today);
        }

        public class when_asking_for_the_next_due_date_of_a_nonrecurring_scheduled_payment_with_a_past_date
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.None }, DueDate = DateTime.Today.AddDays(-1) };
            };
            Because of = () => result = payment.NextDueDateAsOf(DateTime.Today);
            It should_be_min_datetime = () => result.ShouldEqual(DateTime.MinValue);
        }

        public class when_asking_for_the_next_due_date_of_a_weekly_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.Weekly } };
            };
            Because of = () => result = payment.NextDueDateAsOf(DateTime.Today.AddDays(1));
            It should_be_7_days_from_tomorrow = () => result.ShouldEqual(DateTime.Today.AddDays(7));
        }

        public class when_asking_for_the_next_due_date_of_a_biweekly_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.Biweekly } };
            };
            Because of = () => result = payment.NextDueDateAsOf(DateTime.Today.AddDays(1));
            It should_be_14_days_from_tomorrow = () => result.ShouldEqual(DateTime.Today.AddDays(14));
        }

        public class when_asking_for_the_next_due_date_of_a_monthly_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.Monthly } };
            };
            Because of = () => result = payment.NextDueDateAsOf(DateTime.Today.AddDays(1));
            It should_be_a_month_from_tomorrow = () => result.ShouldEqual(DateTime.Today.AddMonths(1));
        }

        public class when_asking_for_the_next_due_date_of_a_bimonthly_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.Bimonthly } };
            };
            Because of = () => result = payment.NextDueDateAsOf(DateTime.Today.AddDays(1));
            It should_be_2_months_from_tomorrow = () => result.ShouldEqual(DateTime.Today.AddMonths(2));
        }

        public class when_asking_for_the_next_due_date_of_an_end_of_month_scheduled_payment
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.LastDayOfMonth } };
            };
            Because of = () => result = payment.NextDueDateAsOf(DateTime.Today.AddDays(1));
            It should_be_the_last_day_of_this_month = () => result.ShouldEqual(DateTime.Today.LastDayOfMonth());
        }

        public class when_asking_for_the_next_due_date_of_an_end_of_month_scheduled_payment_may_31
        {
            static ScheduledPayment payment;
            static DateTime result;
            Establish context = () =>
            {
                payment = new ScheduledPayment() { Recurrence = new Recurrence() { Name = Recurrence.LastDayOfMonth }, DueDate = new DateTime(2012, 5, 31) };
            };
            Because of = () => result = payment.NextDueDateAsOf(new DateTime(2012, 5, 31));
            It should_be_may_31 = () => result.ShouldEqual(new DateTime(2012, 5, 31));
        }
    }
}