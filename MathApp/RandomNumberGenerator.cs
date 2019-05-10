using System;
using System.Collections.Generic;

namespace MathApp
{
    public static class RandomNumberGenerator
    {
        private static Random Random { get; } = new Random();

        public static int GenerateNumber()
        {
            if (Random.NextDouble() < 0.7)
                return Random.Next(1, 100);

            return Random.Next(1, 999);
        }

        public static int GenerateNumber(int startRange, int endRange) => Random.Next(startRange, endRange);

    }
}
