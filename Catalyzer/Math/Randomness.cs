using System;

namespace Catalyzer
{
    public enum RandomTextOption
    {
        LowerCharacterOnly = 0,
        UpperCharacterOnly = 1,
        MixedCharacterOnly = 2,
        NumberOnly = 3,
        LowerWithNumber = 4,
        UpperWithNumber = 5,
        All = 6
    }

    public class Randomness
    {
        private static readonly Random Random = new Random();

        private static readonly string LowerSet = "abcdefghijklmnopqrstuvwxyz";

        private static readonly string UpperSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static readonly string NumberSet = "1234567890";

        public static int RandomInteger(int max)
        {
            return Random.Next(max);
        }

        public static int RandomInteger(int min, int max)
        {
            return Random.Next(min, max);
        }

        public static int RandomOdd(int max)
        {
            return Random.Next(max / 2) * 2 + 1;
        }

        public static int RandomOdd(int min, int max)
        {
            return Random.Next(min / 2, max / 2) * 2 + 1;
        }

        public static int RandomEven(int max)
        {
            return Random.Next(max / 2 + max % 2) * 2;
        }

        public static int RandomEven(int min, int max)
        {
            return Random.Next(min / 2 + min % 2, max / 2 + max % 2) * 2;
        }

        public static double RandomDouble(double max)
        {
            return Random.NextDouble() * max;
        }

        public static double RandomDouble(double min, double max)
        {
            var delta = max - min;
            return min + Random.NextDouble() * delta;
        }

        public static string RandomText(int length, RandomTextOption option)
        {
            var characterSet = string.Empty;
            var rangeLength = 0;
            switch (option)
            {
                case RandomTextOption.LowerCharacterOnly:
                    characterSet = LowerSet;
                    rangeLength = LowerSet.Length;
                    break;
                case RandomTextOption.UpperCharacterOnly:
                    characterSet = UpperSet;
                    rangeLength = UpperSet.Length;
                    break;
                case RandomTextOption.MixedCharacterOnly:
                    characterSet = LowerSet + UpperSet;
                    rangeLength = LowerSet.Length + UpperSet.Length;
                    break;
                case RandomTextOption.NumberOnly:
                    characterSet = NumberSet;
                    rangeLength = NumberSet.Length;
                    break;
                case RandomTextOption.LowerWithNumber:
                    characterSet = LowerSet + NumberSet;
                    rangeLength = LowerSet.Length + NumberSet.Length;
                    break;
                case RandomTextOption.UpperWithNumber:
                    characterSet = UpperSet + NumberSet;
                    rangeLength = UpperSet.Length + NumberSet.Length;
                    break;
                case RandomTextOption.All:
                    characterSet = LowerSet + UpperSet + NumberSet;
                    rangeLength = LowerSet.Length + UpperSet.Length + NumberSet.Length;
                    break;
            }

            var ret = string.Empty;
            for (var i = 0; i < length; i++)
            {
                ret += characterSet[Random.Next(rangeLength)];
            }
            return ret;
        }
    }
}