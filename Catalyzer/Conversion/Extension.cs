using System;

namespace Catalyzer.Conversion
{
    public static class Extension
    {
        public static string ToString(this object value, string @default = default)
        {
            try
            {
                return value?.ToString() ?? @default;
            }
            catch
            {
                return @default;
            }
        }

        public static bool ToBoolean(this object value, bool @default = default)
        {
            try
            {
                return value == null ? @default : Convert.ToBoolean(value);
            }
            catch
            {
                return @default;
            }
        }

        public static int ToInt(this object value, int @default = default)
        {
            try
            {
                return value == null ? @default : Convert.ToInt32(value);
            }
            catch
            {
                return @default;
            }
        }

        public static long ToLong(this object value, long @default = default)
        {
            try
            {
                return value == null ? @default : Convert.ToInt64(value);
            }
            catch
            {
                return @default;
            }
        }

        public static double ToDouble(this object value, double @default = default)
        {
            try
            {
                return value == null ? @default : Convert.ToDouble(value);
            }
            catch
            {
                return @default;
            }
        }

        public static decimal ToDecimal(this object value, decimal @default = default)
        {
            try
            {
                return value == null ? @default : Convert.ToDecimal(value);
            }
            catch
            {
                return @default;
            }
        }

        public static DateTime? ToDateTime(this object value, DateTime? @default = default)
        {
            try
            {
                return value == null ? @default : Convert.ToDateTime(value);
            }
            catch
            {
                return @default;
            }
        }

        public static DateTime? ToDateTime(this string value, string format, DateTime? @default = default)
        {
            if (DateTime.TryParseExact(value, format, null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }

            return @default;
        }

        public static Guid ToGuid(this object value, Guid @default = default)
        {
            try
            {
                return value == null ? @default : Guid.Parse(value.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public static long ToUnixEpoch(this DateTime time, long @default = default)
        {
            try
            {
                return (time.Ticks - 621355968000000000) / 10000000;
            }
            catch
            {
                return @default;
            }
        }

        public static DateTime? FromUnixEpochToUTC(this long value, DateTime? @default = default)
        {
            try
            {
                return new DateTime(value * 10000000 + 621355968000000000);
            }
            catch
            {
                return @default;
            }
        }

        public static long ToJsEpoch(this DateTime time, long @default = default)
        {
            try
            {
                return (time.Ticks - 621355968000000000) / 10000;
            }
            catch
            {
                return @default;
            }
        }

        public static DateTime? FromJsEpochToUTC(this long value, DateTime? @default = default)
        {
            try
            {
                return new DateTime(value * 10000 + 621355968000000000);
            }
            catch
            {
                return @default;
            }
        }
    }
}