using System.Text.RegularExpressions;
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
            var regex = new Regex(@"(?:\.|\+.*)(?=.*?@)");
            order.Email = regex.Replace(order.Email, "");
        }
    }
}