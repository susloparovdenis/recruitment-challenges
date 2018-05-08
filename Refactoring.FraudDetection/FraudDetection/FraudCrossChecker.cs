using System.Collections.Generic;
using System.Linq;
using Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection.Rules;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection
{
    public class FraudCrossChecker : IFraudChecker
    {
        private readonly List<ICrossCheckRule> _rules;

        public FraudCrossChecker(IEnumerable<ICrossCheckRule> rules)
        {
            _rules = rules.ToList();
        }

        public List<FraudResult> Check(IList<Order> orders)
        {
            var fraudResults = new List<FraudResult>();
            for (var i = 0; i < orders.Count; i++)
            {
                var other = orders[i];
                for (var j = i + 1; j < orders.Count; j++)
                {
                    var current = orders[j];

                    var isFraudulent = GetCheckResults(current, other).Any(b => b);
                    if (isFraudulent)
                        fraudResults.Add(new FraudResult(current.OrderId, true));
                }
            }

            return fraudResults;
        }

        private IEnumerable<bool> GetCheckResults(Order current, Order other)
        {
            return _rules.Select(r => r.IsFraudulent(other, current));
        }
    }
}