using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using RisingTide.Models;

namespace RisingTide.Specs
{
    [Subject("ScheduledPayment Creation")]
    public class when_creating_a_scheduled_payment
    {
        static ScheduledPayment payment;
        Because of = () => payment = new ScheduledPayment();
        It should_not_be_deleted = () => payment.IsDeleted.ShouldBeFalse();
        It should_not_be_included_in_projections = () => payment.IncludeInProjection.ShouldBeFalse();
    }

    public class some_other_test
    {
    }
}
