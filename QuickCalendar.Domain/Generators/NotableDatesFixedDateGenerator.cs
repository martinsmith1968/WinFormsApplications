using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Generators;

public class NotableDatesFixedDateGenerator : BaseNotableDatesGenerator
{
    public DateTime Date { get; set; }

    public override IList<NotableDate> Generate()
    {
        return new List<NotableDate>()
            {
                new(Date, InterpolateTemplate(DescriptionTemplate, Date, 1))
            };
    }
}
