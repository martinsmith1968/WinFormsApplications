using DNX.Helpers.Linq;

namespace QuickCalendar.Domain.Extensions;

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
}
