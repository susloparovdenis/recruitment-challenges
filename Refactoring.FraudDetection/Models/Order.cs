// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int DealId { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string CreditCard { get; set; }

        public bool HasSameAdress(Order other) => State == other.State
                                                  && ZipCode == other.ZipCode
                                                  && Street == other.Street
                                                  && City == other.City;
    }
}