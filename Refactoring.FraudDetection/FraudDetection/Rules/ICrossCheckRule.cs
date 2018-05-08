using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection.Rules
{
    public interface ICrossCheckRule
    {
        bool IsFraudulent(Order current, Order other);
    }
}