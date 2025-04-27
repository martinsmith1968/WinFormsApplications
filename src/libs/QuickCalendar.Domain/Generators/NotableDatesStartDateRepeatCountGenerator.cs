using DNX.Common.Interfaces;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Generators;

public class NotableDatesStartDateRepeatCountGenerator : BaseNotableDatesGenerator,
    ICopyable<NotableDatesStartDateRepeatCountGenerator>,
    ICloneable<NotableDatesStartDateRepeatCountGenerator>
{
    public DateTime StartDate { get; set; }

    public int RepeatCount { get; set; }

    public IntervalPeriod IntervalPeriod { get; set; } = IntervalPeriod.Default;

    public int SequenceStart { get; set; } = 1;

    public int SequenceIncrement { get; set; } = 1;

    public override IList<NotableDate> Generate()
    {
        var list = new List<NotableDate>();

        var date = StartDate;
        var sequence = SequenceStart;
        foreach (var _ in Enumerable.Range(1, RepeatCount))
        {
            var description = InterpolateTemplate(DescriptionTemplate, date, sequence);

            var notableDate = new NotableDate(date, description);

            list.Add(notableDate);
            date = IntervalPeriod.AddTo(date);

            sequence += SequenceIncrement;
        }

        return list;
    }

    public void CopyFrom(NotableDatesStartDateRepeatCountGenerator other)
    {
        base.CopyFrom(other);
        StartDate = other.StartDate;
        RepeatCount = other.RepeatCount;
        IntervalPeriod.CopyFrom(other.IntervalPeriod);
        SequenceStart = other.SequenceStart;
        SequenceIncrement = other.SequenceIncrement;
    }

    public NotableDatesStartDateRepeatCountGenerator Clone()
    {
        var other = new NotableDatesStartDateRepeatCountGenerator();
        other.CopyFrom(this);
        return other;
    }
}
