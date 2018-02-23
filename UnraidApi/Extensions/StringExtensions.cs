using System;

namespace UnraidApi.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string s)
        {
            if (int.TryParse(s, out int value))
                return value;

            return 0;
        }

        public static long ToLong(this string s)
        {
            if (long.TryParse(s, out long value))
                return value;

            return 0;
        }

        public static bool ToBool(this string s)
        {
            return IsTrue(s);
        }

        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }

        private static bool IsTrue(string s)
        {
            try
            {
                if (s == null)
                    return false;

                s = s.Trim();
                s = s.ToLower();

                switch (s)
                {
                    case "true":
                        return true;
                    case "t":
                        return true;
                    case "1":
                        return true;
                    case "yes":
                        return true;
                    case "y":
                        return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
