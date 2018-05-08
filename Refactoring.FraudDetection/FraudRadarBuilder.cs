using System;
using Autofac;
using Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection;
using Payvision.CodeChallenge.Refactoring.FraudDetection.FraudDetection.Rules;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Input;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Models;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Normalization;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class FraudRadarBuilder
    {
        private readonly IContainer _container;

        private readonly Action<Order>[] _normalizationRules =
        {
            OrderNormalizationRules.NormalizeEmail,
            OrderNormalizationRules.NormalizeState,
            OrderNormalizationRules.NormalizeStreet
        };

        public FraudRadarBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<OrdersReader>().As<IOrdersReader>();

            builder.RegisterType<CompositeOrderNormalizer>().As<IOrderNormalizer>()
                .WithParameter("rules", _normalizationRules);

            builder.RegisterType<SameAddressDifferentCards>().As<ICrossCheckRule>();
            builder.RegisterType<SameEmailDifferentCards>().As<ICrossCheckRule>();
            builder.RegisterType<FraudCrossChecker>().As<IFraudChecker>();

            builder.RegisterType<FraudRadar>();

            _container = builder.Build();
        }

        public FraudRadar Build() => _container.Resolve<FraudRadar>();
    }
}