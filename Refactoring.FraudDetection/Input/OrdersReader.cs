using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Input
{
    public class OrdersReader : IOrdersReader
    {
        public List<Order> ReadOrdersFromFile(string filePath) =>
            File.ReadAllLines(filePath).Select(ParseLine).ToList();

        private static Order ParseLine(string str)
        {
            var items = str.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            var order = new Order
            {
                OrderId = int.Parse(items[0]),
                DealId = int.Parse(items[1]),
                Email = items[2].ToLower(),
                Street = items[3].ToLower(),
                City = items[4].ToLower(),
                State = items[5].ToLower(),
                ZipCode = items[6],
                CreditCard = items[7]
            };
            return order;
        }
    }
}