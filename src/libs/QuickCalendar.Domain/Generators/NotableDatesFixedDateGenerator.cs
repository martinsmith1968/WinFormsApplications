using DNX.Common.Interfaces;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Generators;

public class NotableDatesFixedDateGenerator : BaseNotableDatesGenerator,
    ICopyable<NotableDatesFixedDateGenerator>,
    ICloneable<NotableDatesFixedDateGenerator>
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

    public NotableDatesFixedDateGenerator Clone()
    {
        var other = new NotableDatesFixedDateGenerator();
        other.CopyFrom(this);
        return other;
    }
}
