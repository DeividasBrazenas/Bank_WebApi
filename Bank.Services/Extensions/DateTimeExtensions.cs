namespace Bank.Services.Extensions
{
    using System;

    public static class DateTimeExtensions
    {
        public static int TotalMonths(this DateTime start, DateTime end)
        {
            return Math.Abs((start.Year * 12 + start.Month) - (end.Year * 12 + end.Month));
        }
    }
}