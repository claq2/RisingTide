using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using RisingTide.Models;

namespace RisingTide.Specs
{
    public class CashFlowScorerTests
    {
        public class when_all_balances_are_minus_1
        {
            static decimal initialBalance;
            static decimal balanceAfter30Days;
            static decimal balanceAfter90Days;
            static decimal balanceAfter180Days;
            static decimal balanceAfter365Days;
            static double result;
            Establish context = () =>
            {
                initialBalance = 0;
                balanceAfter30Days = -1;
                balanceAfter90Days = -1;
                balanceAfter180Days = -1;
                balanceAfter365Days = -1;
            };

            Because of = () => result = CashFlowScorer.CalculateScore(initialBalance, balanceAfter30Days, balanceAfter90Days, balanceAfter180Days, balanceAfter365Days);

            It should_have_a_score_of_minus_5 = () => result.ShouldEqual(-5.0);
        }

        public class when_all_balances_are_0
        {
            static decimal initialBalance;
            static decimal balanceAfter30Days;
            static decimal balanceAfter90Days;
            static decimal balanceAfter180Days;
            static decimal balanceAfter365Days;
            static double result;
            Establish context = () =>
            {
                initialBalance = 0;
                balanceAfter30Days = 0;
                balanceAfter90Days = 0;
                balanceAfter180Days = 0;
                balanceAfter365Days = 0;
            };

            Because of = () => result = CashFlowScorer.CalculateScore(initialBalance, balanceAfter30Days, balanceAfter90Days, balanceAfter180Days, balanceAfter365Days);

            It should_have_a_score_of_plus_5 = () => result.ShouldEqual(5.0);
        }

        public class when_first_2_balances_are_minus_1_and_last_2_balances_are_0
        {
            static decimal initialBalance;
            static decimal balanceAfter30Days;
            static decimal balanceAfter90Days;
            static decimal balanceAfter180Days;
            static decimal balanceAfter365Days;
            static double result;
            Establish context = () =>
            {
                initialBalance = 0;
                balanceAfter30Days = -1;
                balanceAfter90Days = -1;
                balanceAfter180Days = 0;
                balanceAfter365Days = 0;
            };

            Because of = () => result = CashFlowScorer.CalculateScore(initialBalance, balanceAfter30Days, balanceAfter90Days, balanceAfter180Days, balanceAfter365Days);

            It should_have_a_score_of_plus_2 = () => result.ShouldEqual(2.0);
        }

        public class when_first_balance_is_minus_1_and_last_3_balances_are_0
        {
            static decimal initialBalance;
            static decimal balanceAfter30Days;
            static decimal balanceAfter90Days;
            static decimal balanceAfter180Days;
            static decimal balanceAfter365Days;
            static double result;
            Establish context = () =>
            {
                initialBalance = 0;
                balanceAfter30Days = -1;
                balanceAfter90Days = 0;
                balanceAfter180Days = 0;
                balanceAfter365Days = 0;
            };

            Because of = () => result = CashFlowScorer.CalculateScore(initialBalance, balanceAfter30Days, balanceAfter90Days, balanceAfter180Days, balanceAfter365Days);

            It should_have_a_score_of_plus_4 = () => result.ShouldEqual(4.0);
        }

        public class when_first_3_balances_are_0_and_last_balance_is_minus_1
        {
            static decimal initialBalance;
            static decimal balanceAfter30Days;
            static decimal balanceAfter90Days;
            static decimal balanceAfter180Days;
            static decimal balanceAfter365Days;
            static double result;
            Establish context = () =>
            {
                initialBalance = 0;
                balanceAfter30Days = 0;
                balanceAfter90Days = 0;
                balanceAfter180Days = 0;
                balanceAfter365Days = -1;
            };

            Because of = () => result = CashFlowScorer.CalculateScore(initialBalance, balanceAfter30Days, balanceAfter90Days, balanceAfter180Days, balanceAfter365Days);

            It should_have_a_score_of_plus_1 = () => result.ShouldEqual(1.0);
        }

        public class when_first_balance_is_0_and_last_3_balances_are_minus_1
        {
            static decimal initialBalance;
            static decimal balanceAfter30Days;
            static decimal balanceAfter90Days;
            static decimal balanceAfter180Days;
            static decimal balanceAfter365Days;
            static double result;
            Establish context = () =>
            {
                initialBalance = 0;
                balanceAfter30Days = 0;
                balanceAfter90Days = -1;
                balanceAfter180Days = -1;
                balanceAfter365Days = -1;
            };

            Because of = () => result = CashFlowScorer.CalculateScore(initialBalance, balanceAfter30Days, balanceAfter90Days, balanceAfter180Days, balanceAfter365Days);

            It should_have_a_score_of_minus_4_point_5 = () => result.ShouldEqual(-4.0);
        }
    }
}
