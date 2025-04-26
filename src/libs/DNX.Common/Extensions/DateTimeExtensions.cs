using DNX.Extensions.Linq;

namespace DNX.Common.Extensions;

public static class DateTimeExtensions
{
    public static readonly DateTime CalendarMinValue = new(1953, 1, 1);
    public static readonly DateTime CalendarMaxValue = new(9998, 12, 31);

    public static DateTime MinOf(params DateTime[] values)
    {
        return values.HasAny()
            ? values.Min()
            : DateTime.MinValue;
    }

    public static DateTime MaxOf(params DateTime[] values)
    {
        return values.HasAny()
            ? values.Max()
            : DateTime.MaxValue;
    }

    public static int GetMonthsSpan(this DateTime dateTime, DateTime other)
    {
        var startDate = MinOf(dateTime, other);
        var endDate = MaxOf(dateTime, other);

        var startNumber = (startDate.Year * 100) + startDate.Month;
        var endNumber = (endDate.Year * 100) + endDate.Month;

        return (endNumber - startNumber) + 1;
    }
}
