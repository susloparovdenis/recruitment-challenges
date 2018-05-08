using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection.Rules
{
    class SameAddressDifferentCards : ICrossCheckRule
    {
        public bool IsFraudulent(Order current, Order other)
        {
            if (current == null)
            {
                throw new System.ArgumentNullException(nameof(current));
            }

            return current.DealId == other.DealId &&
                   current.HasSameAdress(other) &&
                   current.CreditCard != other.CreditCard;
        }
    }
}