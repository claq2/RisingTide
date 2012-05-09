using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RisingTide.Models;
using Machine.Specifications;
using RisingTide.ViewModels;
using System.Collections.ObjectModel;
using RisingTide.Specs.Mocks;
using RisingTide.DataAccess;

namespace RisingTide.Specs
{
    public class UserTests
    {
        public class when_adding_a_scheduled_payment_to_a_user
        {
            static User user;
            static ScheduledPayment scheduledPayment;
            static IDomainContext domainContext;
            Establish context = () =>
            {
                domainContext = new InMemoryDomainContext();
                user = new User(domainContext) { Payments = new Collection<ScheduledPayment>() };
                domainContext.Save<User>(user);
                scheduledPayment = new ScheduledPayment()
                {
                    Amount = 25.00M,
                    Payee = "Rogers",
                    PaymentType = new PaymentType() { Name = PaymentType.Debit },
                    Recurrence = new Recurrence() { Name = Recurrence.Monthly }
                };
            };
            Because of = () =>
            {
                user.AddScheduledPayment(scheduledPayment);
            };
            It should_have_attached_the_scheduled_payment_to_the_user = () =>
            {
                user.Payments.Contains(scheduledPayment).ShouldBeTrue();
            };
        }

        public class when_deleting_a_scheduled_payment_for_a_user
        {
            static User user;
            static ScheduledPayment scheduledPayment;
            static IDomainContext domainContext;
            Establish context = () =>
            {
                domainContext = new InMemoryDomainContext();
                user = new User(domainContext) { Payments = new Collection<ScheduledPayment>() };
                domainContext.Save<User>(user);
                scheduledPayment = new ScheduledPayment()
                {
                    Amount = 25.00M,
                    Payee = "Rogers",
                    PaymentType = new PaymentType() { Name = PaymentType.Debit },
                    Recurrence = new Recurrence() { Name = Recurrence.Monthly }
                };
                user.AddScheduledPayment(scheduledPayment);
            };
            Because of = () =>
            {
                user.DeleteScheduledPayment(scheduledPayment);
            };
            It should_have_removed_the_scheduled_payment_from_the_user = () =>
            {
                user.Payments.Contains(scheduledPayment).ShouldBeFalse();
            };
        }
    }
}
