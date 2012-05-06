using System;
using System.Collections.Generic;
using System.Linq;
using RisingTide.ViewModels;

namespace RisingTide.Models
{
    public static class MyExtensions
    {
        public static List<CalendarDay> GetThem(this ICollection<ScheduledPayment> coll)
        {
            List<CalendarDay> result = new List<CalendarDay>();
            return result;
        }
    }
}
