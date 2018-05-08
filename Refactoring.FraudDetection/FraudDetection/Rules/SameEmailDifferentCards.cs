using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection.Rules
{
    public class SameEmailDifferentCards : ICrossCheckRule
    {
        public bool IsFraudulent(Order other, Order current)
        {
            return other.DealId == current.DealId
                   && other.Email == current.Email
                   && other.CreditCard != current.CreditCard;
        }
    }
}