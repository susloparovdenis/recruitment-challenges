// -----------------------------------------------------------------------
// <copyright file="BitCounter.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            if(input < 0)
                throw new ArgumentException("The number should be not negative", nameof(input));
            var ar = new List<int>(32) { 0 };
            for (var pos = 0; input != 0; pos++)
            {
                if ((input & 1) == 1)
                    ar.Add(pos);
                input = input >> 1;
            }
            ar[0] = ar.Count - 1;
            return ar;
        }
    }
}