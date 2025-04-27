using DNX.Common.Extensions;
using DNX.Common.Interfaces;
using QuickCalendar.Domain.Models.Types;

namespace QuickCalendar.Domain.Models;

public class IntervalPeriod : ICopyable<IntervalPeriod>
{
    public static IntervalPeriod Default => new()
    {
        IntervalPeriodType = IntervalPeriodType.Days,
        Value = 1
    };

    public uint Value { get; set; }

    public IntervalPeriodType IntervalPeriodType { get; set; }

    public override string ToString()
    {
        return $"{Value} {IntervalPeriodType}";
    }

    public DateTime AddTo(DateTime dateTime)
    {
        return IntervalPeriodType switch
        {
            IntervalPeriodType.Days => dateTime.AddDays(Value.ToInt32()),
            IntervalPeriodType.Months => dateTime.AddMonths(Value.ToInt32()),
            IntervalPeriodType.Weeks => dateTime.AddDays(Value.ToInt32() * 7),
            IntervalPeriodType.Years => dateTime.AddYears(Value.ToInt32()),
            _ => dateTime
        };
    }

    public void CopyFrom(IntervalPeriod other)
    {
        Value = other.Value;
        IntervalPeriodType = other.IntervalPeriodType;
    }

    public static IntervalPeriod Create(IntervalPeriodType intervalPeriodType, uint value)
    {
        if (!Enum.GetNames(typeof(IntervalPeriodType)).Contains(intervalPeriodType.ToString()))
        {
            throw new ArgumentOutOfRangeException(nameof(intervalPeriodType), $"{nameof(IntervalPeriodType)} is unknown");
        }

        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(Value)} is unknown");
        }

        return new IntervalPeriod
        {
            IntervalPeriodType = intervalPeriodType,
            Value = value
        };
    }
}
