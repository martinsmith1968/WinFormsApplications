using QuickCalendar.Domain.Interfaces;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Generators;

public class NotableDatesStartDateRepeatCountGenerator : BaseNotableDatesGenerator, ICopyable<NotableDatesStartDateRepeatCountGenerator>
{
    public DateTime StartDate { get; set; }

    public int RepeatCount { get; set; }

    public IntervalPeriod IntervalPeriod { get; set; } = IntervalPeriod.Default;

    public override IList<NotableDate> Generate()
    {
        var list = new List<NotableDate>();

        var date = StartDate;
        foreach (var sequence in Enumerable.Range(1, RepeatCount))
        {
            var description = InterpolateTemplate(DescriptionTemplate, date, sequence);

            var notableDate = new NotableDate(date, description);

            list.Add(notableDate);
            date = IntervalPeriod.AddTo(date);
        }

        return list;
    }

    public void CopyFrom(NotableDatesStartDateRepeatCountGenerator other)
    {
        base.CopyFrom(other);
        StartDate = other.StartDate;
        RepeatCount = other.RepeatCount;
        IntervalPeriod.CopyFrom(other.IntervalPeriod);
    }
}
