using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Normalization
{
    public interface IOrderNormalizer
    {
        void Normalize(Order order);
    }
}