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


    }
}
