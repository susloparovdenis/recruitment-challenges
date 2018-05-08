// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Models
{
    public class FraudResult
    {
        public FraudResult(int orderId, bool isFraudulent)
        {
            OrderId = orderId;
            IsFraudulent = isFraudulent;
        }

        public int OrderId { get; private set; }

        public bool IsFraudulent { get; private set; }
    }
}