using System;

namespace SimpleTimeTracker.Core.Extensions
{
    public static class StringExtensions
    {
        public static Guid ToGuid(this string value)
        {
            Guid result;
            if (Guid.TryParse(value, out result))
            {
                return result;
            }

            return Guid.Empty;
        }

        public static double ToDouble(this string value)
        {
            double result;
            if (double.TryParse(value, out result))
            {
                return result;
            }

            return 0;
        }

    }
}
