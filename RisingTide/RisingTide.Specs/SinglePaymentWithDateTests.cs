using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RisingTide.ViewModels;
using RisingTide.Models;
using Machine.Specifications;

namespace RisingTide.Specs
{
    public class SinglePaymentWithDateTests
    {
        public class when_comparing_two_single_payments_with_date_of_the_same_type
        {
            static SinglePaymentWithDate payment1;
            static SinglePaymentWithDate payment2;

            static int result;

            Establish context = () =>
            {
                payment1 = new SinglePaymentWithDate();
                payment1.PaymentType.Name = PaymentType.Credit;
                payment2 = new SinglePaymentWithDate();
                payment2.PaymentType.Name = PaymentType.Credit;
            };

            Because of = () => result = payment1.CompareTo(payment2);

            It should_be_that_the_single_payment_with_dates_are_equal_in_ordering = () => result.ShouldEqual(0);
        }

        public class when_comparing_a_debit_single_payment_with_date_to_a_credit_single_payment
        {
            static SinglePaymentWithDate payment1;
            static SinglePaymentWithDate payment2;

            static int result;

            Establish context = () =>
            {
                payment1 = new SinglePaymentWithDate();
                payment1.PaymentType.Name = PaymentType.Debit;
                payment2 = new SinglePaymentWithDate();
                payment2.PaymentType.Name = PaymentType.Credit;
            };

            Because of = () => result = payment1.CompareTo(payment2);

            It should_be_that_the_debit_single_payment_with_date_comes_after_the_credit_single_payment_with_date = () => result.ShouldEqual(1);
        }

        public class when_comparing_a_credit_single_payment_with_date_to_a_debit_single_payment
        {
            static SinglePaymentWithDate payment1;
            static SinglePaymentWithDate payment2;

            static int result;

            Establish context = () =>
            {
                payment1 = new SinglePaymentWithDate();
                payment1.PaymentType.Name = PaymentType.Credit;
                payment2 = new SinglePaymentWithDate();
                payment2.PaymentType.Name = PaymentType.Debit;
            };

            Because of = () => result = payment1.CompareTo(payment2);

            It should_be_that_the_credit_single_payment_with_date_comes_before_the_debit_single_payment_with_date = () => result.ShouldEqual(-1);
        }
    }
}