namespace QuickCalendar.Domain.Models;

public class DateRange
{
    public static DateRange Default => new(DateTime.UtcNow.Date);

    public DateRange(DateTime date)
        : this(date, date)
    {
    }

    public DateRange(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate <= endDate ? startDate : endDate;
        EndDate = endDate >= startDate ? endDate : startDate;
    }

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public bool IsRange => EndDate > StartDate;
}
