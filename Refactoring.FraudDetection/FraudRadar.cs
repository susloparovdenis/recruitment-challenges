// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Input;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Normalization;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class FraudRadar
    {
        private readonly IFraudChecker _fraudChecker;
        private readonly IOrderNormalizer _orderNormalizer;
        private readonly IOrdersReader _ordersReader;

        public FraudRadar(IOrderNormalizer orderNormalizer, IFraudChecker fraudChecker, IOrdersReader ordersReader)
        {
            _orderNormalizer = orderNormalizer;
            _fraudChecker = fraudChecker;
            _ordersReader = ordersReader;
        }

        public IEnumerable<FraudResult> Check(string filePath)
        {
            var orders = _ordersReader.ReadOrdersFromFile(filePath);
            foreach (var order in orders) _orderNormalizer.Normalize(order);

            return _fraudChecker.Check(orders);
        }
    }
}