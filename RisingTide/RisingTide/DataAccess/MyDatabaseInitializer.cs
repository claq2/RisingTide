using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RisingTide.Models;

namespace RisingTide.DataAccess
{
    public class MyDatabaseInitializer : DropCreateDatabaseIfModelChanges<RisingTideContext>
    {
        protected override void Seed(RisingTideContext context)
        {
            var recurrences = new List<Recurrence>() 
            {
                new Recurrence { Name = Recurrence.None },
                new Recurrence { Name = Recurrence.Weekly },
                new Recurrence { Name = Recurrence.Biweekly },
                new Recurrence { Name = Recurrence.Monthly },
                new Recurrence { Name = Recurrence.Bimonthly },
                new Recurrence { Name = Recurrence.LastDayOfMonth }
            };

            recurrences.ForEach(r => context.Recurrences.Add(r));
            context.SaveChanges();

            var paymentTypes = new List<PaymentType>()
            {
                new PaymentType { Name = PaymentType.Debit},
                new PaymentType { Name = PaymentType.Credit}
            };

            paymentTypes.ForEach(p => context.PaymentTypes.Add(p));
            context.SaveChanges();

            //var scheduledPayment = new ScheduledPayment()
            //{
            //    PaymentTypeId = paymentTypes[0].Id,
            //    RecurrenceId = recurrences[1].Id,
            //    Amount = 25.00M,
            //    DueDate = DateTime.Today.AddDays(1),
            //    PayOnDate = DateTime.Today.AddDays(1),
            //    Payee = "Cogeco"
            //};

            //context.ScheduledPayments.Add(scheduledPayment);
            //context.SaveChanges();

            User user0 = new User(context) { Username = "jmclachl", Payments = new List<ScheduledPayment>() };
            context.Users.Add(user0);
            context.SaveChanges();

            var scheduledPayment1 = new ScheduledPayment()
            {
                PaymentTypeId = paymentTypes[0].Id,
                RecurrenceId = recurrences[1].Id,
                Amount = 75.00M,
                DueDate = DateTime.Today.AddDays(1),
                PayOnDate = DateTime.Today.AddDays(1),
                Subject = "Bell"
            };

            user0.AddScheduledPayment(scheduledPayment1);


            base.Seed(context);
            //Add a User and Role Sample!      
            //Membership.CreateUser("jmclachlan", "test123");     
            //Roles.CreateRole("Admin");
            //Roles.AddUsersToRole(new[] { "jmclachlan" }, "Admin");    
        }
    }
}
