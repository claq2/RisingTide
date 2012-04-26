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
                new Recurrence { Name = "None"},
                new Recurrence { Name = "Weekly"},
                new Recurrence { Name = "Biweekly"},
                new Recurrence { Name = "Monthly"},
                new Recurrence { Name = "Bimonthly"}
            };

            recurrences.ForEach(r => context.Recurrences.Add(r));
            context.SaveChanges();

            var paymentTypes = new List<PaymentType>()
            {
                new PaymentType { Name = "Debit"},
                new PaymentType { Name = "Credit"}
            };

            paymentTypes.ForEach(p => context.PaymentTypes.Add(p));
            context.SaveChanges();

            var scheduledPayment = new ScheduledPayment()
            {
                PaymentTypeId = paymentTypes[0].Id,
                RecurrenceId = recurrences[1].Id,
                Amount = 25.00M,
                FirstPayment = DateTime.Today.AddDays(1),
                Payee = "Cogeco",
                IsDeleted = false
            };
            context.ScheduledPayments.Add(scheduledPayment);
            context.SaveChanges();

            base.Seed(context);
            //Add a User and Role Sample!      
            //Membership.CreateUser("jmclachlan", "test123");     
            //Roles.CreateRole("Admin");
            //Roles.AddUsersToRole(new[] { "jmclachlan" }, "Admin");    
        }
    }
}