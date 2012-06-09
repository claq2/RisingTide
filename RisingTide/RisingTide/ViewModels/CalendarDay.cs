using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RisingTide.ViewModels
{
    public class CalendarDay
    {
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public decimal EndOfDayBalance { get; set; }
        public List<SinglePayment> Payments { get; set; }

        public CalendarDay()
        {
            this.Payments = new List<SinglePayment>();
        }
    }
}