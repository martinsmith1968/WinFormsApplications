using QuickCalendar.Domain.Interfaces;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Generators;

public class NotableDatesFixedDateGenerator : BaseNotableDatesGenerator, ICopyable<NotableDatesFixedDateGenerator>
{
    public DateTime Date { get; set; }

    public override IList<NotableDate> Generate()
    {
        return new List<NotableDate>()
            {
                new(Date, InterpolateTemplate(DescriptionTemplate, Date, 1))
            };
    }

    public void CopyFrom(NotableDatesFixedDateGenerator other)
    {
        base.CopyFrom(other);
        Date = other.Date;
    }
}
