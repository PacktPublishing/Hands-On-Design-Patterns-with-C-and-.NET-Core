using System;

namespace FlixOne.CQRS.Helper
{
    public static class Extension
    {
        public static bool IsValidGuid(this string inputString)
        {
            Guid.TryParse(inputString, out var guidOutput);
            return guidOutput != Guid.Empty;
        }
        public static Guid ToValidGuid(this string inputString)
        {
            return IsValidGuid(inputString) ? new Guid(inputString) : new Guid();
        }
    }
}