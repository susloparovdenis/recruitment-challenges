using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection;
using Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection.Rules;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class FraudCheckerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithNullArgument_ThrowsException()
        {
            var fraudCrossChecker = new FraudCrossChecker(null);
        }

        [TestMethod]
        public void Check_TwoRulesFirstFails_OnlyFailingExecuted()
        {
            // Arrange
            var failingRule = A.Fake<ICrossCheckRule>();
            A.CallTo(() => failingRule.IsFraudulent(A<Order>._, A<Order>._)).Returns(true);
            var validRule = A.Fake<ICrossCheckRule>();
            A.CallTo(() => validRule.IsFraudulent(A<Order>._, A<Order>._)).Returns(false);
            var fraudCrossChecker = new FraudCrossChecker(new[] {failingRule, validRule});

            // Act
            fraudCrossChecker.Check(new List<Order>() {new Order(), new Order()});

            // Assert
            A.CallTo(() => failingRule.IsFraudulent(A<Order>._, A<Order>._)).MustHaveHappened();
            A.CallTo(() => validRule.IsFraudulent(A<Order>._, A<Order>._)).MustNotHaveHappened();
        }
    }
}
