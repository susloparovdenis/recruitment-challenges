using System;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Normalization
{
    public static class OrderNormalizationRules
    {
        public static void NormalizeState(Order order)
        {
            order.State = order.State.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }

        public static void NormalizeStreet(Order order)
        {
            order.Street = order.Street.Replace("st.", "street").Replace("rd.", "road");
        }

        public static void NormalizeEmail(Order order)
        {
            var aux = order.Email.Split(new[] {'@'}, StringSplitOptions.RemoveEmptyEntries);
            aux[0] = aux[0].Replace(".", "");
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            if (atIndex > 0)
            {
                aux[0] = aux[0].Remove(atIndex);
            }
            order.Email = string.Join("@", aux[0], aux[1]);
        }
    }
}