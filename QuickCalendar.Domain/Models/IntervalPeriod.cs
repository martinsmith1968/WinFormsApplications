namespace QuickCalendar.Domain.Models;

public enum IntervalType
{
    Days = 1,
    Weeks,
    Months,
    Years
}

public class IntervalPeriod
{
    public static IntervalPeriod Default => new()
    {
        IntervalType = IntervalType.Days,
        Value = 1
    };

    public static IntervalPeriod Create(IntervalType intervalType, int value)
    {
        if (!Enum.GetNames(typeof(IntervalType)).Contains(intervalType.ToString()))
            throw new ArgumentOutOfRangeException(nameof(intervalType), $"{nameof(IntervalType)} is unknown");
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(Value)} is unknown");

        return new IntervalPeriod
        {
            IntervalType = intervalType,
            Value = value
        };
    }

    public int Value { get; set; }

    public IntervalType IntervalType { get; set; }

    public DateTime AddTo(DateTime dateTime)
    {
        return IntervalType switch
        {
            IntervalType.Days => dateTime.AddDays(Value),
            IntervalType.Months => dateTime.AddMonths(Value),
            IntervalType.Weeks => dateTime.AddDays(Value * 4),
            IntervalType.Years => dateTime.AddYears(Value),
            _ => dateTime
        };
    }
}
