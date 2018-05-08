using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Normalization;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class NormalizationTests
    {
        [TestMethod]
        public void Normalizes_EmailWithDotAndPlus()
        {
            var order = new Order() {Email = "bu.gs+asd@bunny.com"};
            OrderNormalizationRules.NormalizeEmail(order);
            order.Email.ShouldBeEquivalentTo("bugs@bunny.com");
        }
    }
}
