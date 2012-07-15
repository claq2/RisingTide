using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using System.Collections.ObjectModel;
using RisingTide.ViewModels;
using RisingTide.Models;

namespace RisingTide.Specs
{
    public class ScheduledPaymentCollectionCashFlowTests
    {
        public class when_checking_cash_flow_with_1_weekly_1_dollar_payment
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static bool result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Weekly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.IsCashFlowScorePositive();

            It should_have_a_negative_cash_flow = () => result.ShouldBeFalse();
        }

        public class when_checking_cash_flow_with_1_weekly_1_dollar_credit
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static bool result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Credit }, Recurrence = new Recurrence() { Name = Recurrence.Weekly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.IsCashFlowScorePositive();

            It should_have_a_negative_cash_flow = () => result.ShouldBeTrue();
        }

        public class when_checking_cash_flow_with_1_one_time_25_dollar_credit_and_1_monthly_1_dollar_payment
        {
            static Collection<ScheduledPayment> scheduledPayments;
            static bool result;
            Establish context = () =>
            {
                scheduledPayments = new Collection<ScheduledPayment>();
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Credit }, Recurrence = new Recurrence() { Name = Recurrence.None }, Amount = 25.00M });
                scheduledPayments.Add(new ScheduledPayment() { PaymentType = new PaymentType() { Name = PaymentType.Debit }, Recurrence = new Recurrence() { Name = Recurrence.Monthly }, Amount = 1.00M });
            };

            Because of = () => result = scheduledPayments.IsCashFlowScorePositive();

            It should_have_a_negative_cash_flow = () => result.ShouldBeFalse();
        }
    }
}