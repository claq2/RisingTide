using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RisingTide.Models;
using Machine.Specifications;

namespace RisingTide.Specs
{
    public class PaymentTypeTests
    {
        [Subject("PaymentType comparison")]
        public class when_comparing_two_payment_types_with_the_same_name
        {
            static PaymentType type1;
            static PaymentType type2;
            static bool result;

            Establish context = () =>
                {
                    type1 = new PaymentType { Name = PaymentType.Credit };
                    type2 = new PaymentType { Name = PaymentType.Credit };
                };

            Because of = () => result = type1.Equals(type2);

            It should_be_true_that_the_types_are_equal = () => result.ShouldBeTrue();
        }

        [Subject("PaymentType comparison")]
        public class when_comparing_two_payment_types_with_different_names
        {
            static PaymentType type1;
            static PaymentType type2;
            static bool result;

            Establish context = () =>
            {
                type1 = new PaymentType { Name = PaymentType.Credit };
                type2 = new PaymentType { Name = PaymentType.Debit };
            };

            Because of = () => result = type1.Equals(type2);

            It should_be_true_that_the_types_are_not_equal = () => result.ShouldBeFalse();
        }
    }
}
