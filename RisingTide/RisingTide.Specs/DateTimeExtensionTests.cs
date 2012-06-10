using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using RisingTide.Models;

namespace RisingTide.Specs
{
    public class DateTimeExtensionTests
    {
        public class when_asking_for_the_last_day_of_january_2012
        {
            static DateTime aDayInJanuary;
            static DateTime result;
            Establish context = () =>
                {
                    aDayInJanuary = new DateTime(2012, 1, 5);
                };

            Because of = () => result = aDayInJanuary.LastDayOfMonth();

            It should_be_january_31 = () => result.Date.ShouldEqual(new DateTime(2012, 1, 31).Date);
        }

        public class when_asking_for_the_last_day_of_february_2012_a_leap_year
        {
            static DateTime aDayInFebruary;
            static DateTime result;
            Establish context = () =>
            {
                aDayInFebruary = new DateTime(2012, 2, 5);
            };

            Because of = () => result = aDayInFebruary.LastDayOfMonth();

            It should_be_february_29 = () => result.Date.ShouldEqual(new DateTime(2012, 2, 29).Date);
        }

        public class when_asking_for_the_last_day_of_february_2013_a_non_leap_year
        {
            static DateTime aDayInFebruary;
            static DateTime result;
            Establish context = () =>
            {
                aDayInFebruary = new DateTime(2013, 2, 5);
            };

            Because of = () => result = aDayInFebruary.LastDayOfMonth();

            It should_be_february_28 = () => result.Date.ShouldEqual(new DateTime(2013, 2, 28).Date);
        }

        public class when_asking_for_the_last_day_of_march_2012
        {
            static DateTime aDayInMarch;
            static DateTime result;
            Establish context = () =>
            {
                aDayInMarch = new DateTime(2012, 3, 5);
            };

            Because of = () => result = aDayInMarch.LastDayOfMonth();

            It should_be_march_31 = () => result.Date.ShouldEqual(new DateTime(2012, 3, 31).Date);
        }

        public class when_asking_for_the_last_day_of_april_2012
        {
            static DateTime aDayInApril;
            static DateTime result;
            Establish context = () =>
            {
                aDayInApril = new DateTime(2012, 4, 5);
            };

            Because of = () => result = aDayInApril.LastDayOfMonth();

            It should_be_april_30 = () => result.Date.ShouldEqual(new DateTime(2012, 4, 30).Date);
        }

        public class when_asking_for_the_last_day_of_may_2012
        {
            static DateTime aDayInMay;
            static DateTime result;
            Establish context = () =>
            {
                aDayInMay = new DateTime(2012, 5, 5);
            };

            Because of = () => result = aDayInMay.LastDayOfMonth();

            It should_be_may_31 = () => result.Date.ShouldEqual(new DateTime(2012, 5, 31).Date);
        }

        public class when_asking_for_the_last_day_of_june_2012
        {
            static DateTime aDayInJune;
            static DateTime result;
            Establish context = () =>
            {
                aDayInJune = new DateTime(2012, 6, 5);
            };

            Because of = () => result = aDayInJune.LastDayOfMonth();

            It should_be_june_30 = () => result.Date.ShouldEqual(new DateTime(2012, 6, 30).Date);
        }

        public class when_asking_for_the_last_day_of_july_2012
        {
            static DateTime aDayInJuly;
            static DateTime result;
            Establish context = () =>
            {
                aDayInJuly = new DateTime(2012, 7, 5);
            };

            Because of = () => result = aDayInJuly.LastDayOfMonth();

            It should_be_july_31 = () => result.Date.ShouldEqual(new DateTime(2012, 7, 31).Date);
        }

        public class when_asking_for_the_last_day_of_august_2012
        {
            static DateTime aDayInAugust;
            static DateTime result;
            Establish context = () =>
            {
                aDayInAugust = new DateTime(2012, 8, 5);
            };

            Because of = () => result = aDayInAugust.LastDayOfMonth();

            It should_be_august_31 = () => result.Date.ShouldEqual(new DateTime(2012, 8, 31).Date);
        }

        public class when_asking_for_the_last_day_of_september_2012
        {
            static DateTime aDayInSeptember;
            static DateTime result;
            Establish context = () =>
            {
                aDayInSeptember = new DateTime(2012, 9, 5);
            };

            Because of = () => result = aDayInSeptember.LastDayOfMonth();

            It should_be_september_30 = () => result.Date.ShouldEqual(new DateTime(2012, 9, 30).Date);
        }

        public class when_asking_for_the_last_day_of_october_2012
        {
            static DateTime aDayInOctober;
            static DateTime result;
            Establish context = () =>
            {
                aDayInOctober = new DateTime(2012, 10, 5);
            };

            Because of = () => result = aDayInOctober.LastDayOfMonth();

            It should_be_october_31 = () => result.Date.ShouldEqual(new DateTime(2012, 10, 31).Date);
        }

        public class when_asking_for_the_last_day_of_november_2012
        {
            static DateTime aDayInNovember;
            static DateTime result;
            Establish context = () =>
            {
                aDayInNovember = new DateTime(2012, 11, 5);
            };

            Because of = () => result = aDayInNovember.LastDayOfMonth();

            It should_be_november_30 = () => result.Date.ShouldEqual(new DateTime(2012, 11, 30).Date);
        }

        public class when_asking_for_the_last_day_of_december_2012
        {
            static DateTime aDayInDecember;
            static DateTime result;
            Establish context = () =>
            {
                aDayInDecember = new DateTime(2012, 12, 5);
            };

            Because of = () => result = aDayInDecember.LastDayOfMonth();

            It should_be_december_31 = () => result.Date.ShouldEqual(new DateTime(2012, 12, 31).Date);
        }
    }
}
