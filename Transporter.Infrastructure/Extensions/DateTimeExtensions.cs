using System;

namespace Transporter.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToEpochTicks(this DateTime dateTime)
        {
            var epoch = new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc);
            var time = dateTime.Subtract(new TimeSpan(epoch.Ticks));

            return time.Ticks / 10000;
        }
    }
}