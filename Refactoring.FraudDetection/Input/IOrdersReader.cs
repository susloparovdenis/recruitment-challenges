using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Input
{
    public interface IOrdersReader
    {
        List<Order> ReadOrdersFromFile(string filePath);
    }
}