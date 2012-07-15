using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RisingTide.Models
{
    public static class CashFlowScorer
    {
        public static double CalculateScore(decimal initialBalance, decimal balanceAfter30Days, decimal balanceAfter90Days, decimal balanceAfter180Days, decimal balanceAfter365Days)
        {
            const double scoreForPositiveBalanceAfter30Days = 0.5;
            const double scoreForPositiveBalanceAfter90Days = 1.0;
            const double scoreForPositiveBalanceAfter180Days = 1.5;
            const double scoreForPositiveBalanceAfter365Days = 2.0;

            double score = 0;
            if (balanceAfter30Days >= initialBalance)
            {
                score += scoreForPositiveBalanceAfter30Days;
            }
            else
            {
                score -= scoreForPositiveBalanceAfter30Days;
            }

            if (balanceAfter90Days >= initialBalance)
            {
                score += scoreForPositiveBalanceAfter90Days;
            }
            else
            {
                score -= scoreForPositiveBalanceAfter90Days;
            }

            if (balanceAfter180Days >= initialBalance)
            {
                score += scoreForPositiveBalanceAfter180Days;
            }
            else
            {
                score -= scoreForPositiveBalanceAfter180Days;
            }

            if (balanceAfter365Days >= initialBalance)
            {
                score += scoreForPositiveBalanceAfter365Days;
            }
            else
            {
                score -= scoreForPositiveBalanceAfter365Days;
            }

            return score;
        }
    }
}