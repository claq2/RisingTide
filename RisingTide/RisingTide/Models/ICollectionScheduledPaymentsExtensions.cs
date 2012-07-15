using System;
using System.Collections.Generic;
using System.Linq;
using RisingTide.ViewModels;

namespace RisingTide.Models
{
    public static class ICollectionScheduledPaymentsExtensions
    {
        public static List<CalendarDay> GetDayRangeWithPaymentsFor(this ICollection<ScheduledPayment> payments, DateTime startDate, int numberOfDays, decimal initialBalance)
        {
            List<CalendarDay> result = new List<CalendarDay>();
            decimal currentBalance = initialBalance;
            for (int i = 0; i < numberOfDays; i++)
            {
                DateTime currentDate = startDate.AddDays(i).Date;
                result.Add(new CalendarDay() { Date = currentDate, Payments = new List<SinglePayment>() });
                result[i].EndOfDayBalance = currentBalance;
                foreach (ScheduledPayment scheduledPayment in payments)
                {
                    if (scheduledPayment.Recurrence.Name == Recurrence.None && scheduledPayment.PayOnDate != currentDate)
                    {
                        continue;
                    }

                    DateTime nextPaymentDate = scheduledPayment.NextPaymentDateAsOf(currentDate);
                    if (nextPaymentDate == currentDate)
                    {
                        SinglePayment singlePayment = new SinglePayment()
                        {
                            Amount = scheduledPayment.Amount * (scheduledPayment.PaymentType.Name == PaymentType.Debit ? -1 : 1),
                            Subject = scheduledPayment.Subject,
                            ScheduledPaymentId = scheduledPayment.Id,
                            IncludeInCashFlowAnalysis = scheduledPayment.IncludeInCashFlowAnalysis
                        };

                        result[i].Payments.Add(singlePayment);

                        if (scheduledPayment.IncludeInCashFlowAnalysis)
                        {
                            result[i].EndOfDayBalance += singlePayment.Amount;
                        }
                    }
                }

                result[i].Payments.Sort();
                currentBalance = result[i].EndOfDayBalance;
            }

            return result;
        }

        public static List<SinglePaymentWithDate> GetUpcomingPayments(this ICollection<ScheduledPayment> payments, DateTime startDate)
        {
            DateTime dateOfStartDate = startDate.Date;
            List<SinglePaymentWithDate> result = new List<SinglePaymentWithDate>();
            foreach (var scheduledPayment in payments)
            {
                if (scheduledPayment.Recurrence.Name == Recurrence.None && scheduledPayment.PayOnDate < dateOfStartDate)
                {
                    continue;
                }

                result.Add(new SinglePaymentWithDate()
                {
                    Amount = scheduledPayment.Amount * (scheduledPayment.PaymentType.Name == PaymentType.Debit ? -1 : 1),
                    Subject = scheduledPayment.Subject,
                    IncludeInCashFlowAnalysis = scheduledPayment.IncludeInCashFlowAnalysis,
                    PaymentDate = scheduledPayment.NextPaymentDateAsOf(dateOfStartDate),
                    PaymentType = new PaymentType() { Name = scheduledPayment.PaymentType.Name },
                    ScheduledPaymentId = scheduledPayment.Id
                });
            }

            result.Sort();

            return result;
        }

        public static bool IsCashFlowScorePositive(this ICollection<ScheduledPayment> payments)
        {
            decimal balanceOnFirstDay = payments.GetDayRangeWithPaymentsFor(DateTime.Now.Date, 1, 0).First().EndOfDayBalance;
            decimal balanceAfter30Days = payments.GetDayRangeWithPaymentsFor(DateTime.Now.Date, 30, 0).Last().EndOfDayBalance;
            decimal balanceAfter90Days = payments.GetDayRangeWithPaymentsFor(DateTime.Now.Date, 90, 0).Last().EndOfDayBalance;
            decimal balanceAfter180Days = payments.GetDayRangeWithPaymentsFor(DateTime.Now.Date, 180, 0).Last().EndOfDayBalance;
            decimal balanceAfter365Days = payments.GetDayRangeWithPaymentsFor(DateTime.Now.Date, 365, 0).Last().EndOfDayBalance;

            return CashFlowScorer.CalculateScore(balanceOnFirstDay, balanceAfter30Days, balanceAfter90Days, balanceAfter180Days, balanceAfter365Days) > 0;
        }
    }
}
