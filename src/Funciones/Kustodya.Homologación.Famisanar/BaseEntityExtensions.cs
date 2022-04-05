using System;

namespace Kustodya.Homologacion.Famisanar
{
    public static class BaseEntityExtensions
    {
        public static DateTime? ToDateTime(this string javaTimeStamp)
        {
            if (!long.TryParse(javaTimeStamp, out long timestamp))
                return null;
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(timestamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
