using System;

namespace Infrastructure.Utility
{
    public static class Util
    {
        public static bool IsGuid(string value)
        {
            Guid guid;
            return Guid.TryParse(value, out guid);
        }
    }
}
