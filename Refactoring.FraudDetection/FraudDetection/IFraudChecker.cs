using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection
{
    public interface IFraudChecker
    {
        List<FraudResult> Check(IList<Order> orders);
    }
}