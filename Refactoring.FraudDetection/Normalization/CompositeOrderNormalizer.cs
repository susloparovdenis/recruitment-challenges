using System;
using System.Collections.Generic;
using System.Linq;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Normalization
{
    public class CompositeOrderNormalizer : IOrderNormalizer
    {
        private readonly List<Action<Order>> _rules;

        public CompositeOrderNormalizer(IEnumerable<Action<Order>> rules)
        {
            _rules = rules.ToList();
        }

        public void Normalize(Order order)
        {
            foreach (var normalizationRule in _rules)
            {
                normalizationRule(order);
            }
        }
    }
}