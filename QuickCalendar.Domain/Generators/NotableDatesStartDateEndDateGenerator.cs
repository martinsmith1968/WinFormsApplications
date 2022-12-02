using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Generators;

public class NotableDatesStartDateEndDateGenerator : BaseNotableDatesGenerator
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public IntervalPeriod IntervalPeriod { get; set; } = IntervalPeriod.Default;

    public override IList<NotableDate> Generate()
    {
        var list = new List<NotableDate>();

        var sequence = 0;
        var date = StartDate;
        while (date <= EndDate)
        {
            ++sequence;

            var description = InterpolateTemplate(DescriptionTemplate, date, sequence);

            var notableDate = new NotableDate(date, description);

            list.Add(notableDate);
            date = IntervalPeriod.AddTo(date);
        }

        return list;
    }
}
