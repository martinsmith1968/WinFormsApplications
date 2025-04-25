using DNX.Common.Interfaces;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Generators;

public class NotableDatesStartDateEndDateGenerator : BaseNotableDatesGenerator,
    ICopyable<NotableDatesStartDateEndDateGenerator>,
    ICloneable<NotableDatesStartDateEndDateGenerator>
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public IntervalPeriod IntervalPeriod { get; set; } = IntervalPeriod.Default;

    public int SequenceStart { get; set; } = 1;

    public int SequenceIncrement { get; set; } = 1;

    public override IList<NotableDate> Generate()
    {
        var list = new List<NotableDate>();

        var sequence = SequenceStart;
        var date = StartDate;
        while (date <= EndDate)
        {
            var description = InterpolateTemplate(DescriptionTemplate, date, sequence);

            var notableDate = new NotableDate(date, description);

            list.Add(notableDate);
            date = IntervalPeriod.AddTo(date);

            sequence += SequenceIncrement;
        }

        return list;
    }

    public void CopyFrom(NotableDatesStartDateEndDateGenerator other)
    {
        base.CopyFrom(other);
        StartDate = other.StartDate;
        EndDate = other.EndDate;
        IntervalPeriod.CopyFrom(other.IntervalPeriod);
        SequenceStart = other.SequenceStart;
        SequenceIncrement = other.SequenceIncrement;
    }

    public NotableDatesStartDateEndDateGenerator Clone()
    {
        var other = new NotableDatesStartDateEndDateGenerator();
        other.CopyFrom(this);
        return other;
    }
}
