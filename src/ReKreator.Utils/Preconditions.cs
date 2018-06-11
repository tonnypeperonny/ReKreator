using System;

namespace ReKreator.Utils
{
    public static class Preconditions
    {
        public static T CheckNotNull<T>(T argument, string paramName) where T : class
        {
            if (argument == null)
                throw new ArgumentNullException(paramName);

            return argument;
        }

        public static void CheckArgument(bool expression, string parameter, string message)
        {
            if (!expression)
                throw new ArgumentException(message, parameter);
        }
        
        public static void CheckArgumentRange(string paramName, int value, int minInclusive, int maxInclusive)
        {
            if (value < minInclusive || value > maxInclusive)
            {
                ThrowArgumentOutOfRangeException(paramName, value, minInclusive, maxInclusive);
            }
        }
        
        private static void ThrowArgumentOutOfRangeException<T>(string paramName, T value, T minInclusive, T maxInclusive)
        {
            throw new ArgumentOutOfRangeException(paramName, value,
                $"Value should be in range [{minInclusive}-{maxInclusive}]");
        }
    }
}
