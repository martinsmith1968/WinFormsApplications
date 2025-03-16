namespace QuickCalendar.Domain.Models;

public class DateRange : DateTimeRange
{
    public new static DateRange Default => new(DateTime.UtcNow.Date);

    public DateRange(DateTime date)
        : this(date.Date, date.Date)
    {
    }

    public DateRange(DateTime startDate, DateTime endDate)
        : base(startDate.Date, endDate.Date)
    {
    }
}
