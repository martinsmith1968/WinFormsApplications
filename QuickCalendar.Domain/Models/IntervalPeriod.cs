using QuickCalendar.Domain.Extensions;
using QuickCalendar.Domain.Interfaces;

namespace QuickCalendar.Domain.Models;

public enum IntervalType
{
    Days = 1,
    Weeks,
    Months,
    Years
}

public class IntervalPeriod : ICopyable<IntervalPeriod>
{
    public static IntervalPeriod Default => new()
    {
        IntervalType = IntervalType.Days,
        Value = 1
    };

    public static IntervalPeriod Create(IntervalType intervalType, uint value)
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

    public uint Value { get; set; }

    public IntervalType IntervalType { get; set; }

    public DateTime AddTo(DateTime dateTime)
    {
        return IntervalType switch
        {
            IntervalType.Days => dateTime.AddDays(Value.ToInt32()),
            IntervalType.Months => dateTime.AddMonths(Value.ToInt32()),
            IntervalType.Weeks => dateTime.AddDays(Value.ToInt32() * 7),
            IntervalType.Years => dateTime.AddYears(Value.ToInt32()),
            _ => dateTime
        };
    }

    public void CopyFrom(IntervalPeriod other)
    {
        Value = other.Value;
        IntervalType = other.IntervalType;
    }
}
