using QuickCalendar.Domain.Extensions;

namespace QuickCalendar.Domain.Models;

public class DateTimeRange
{
    public static DateTimeRange Default => new(DateTime.UtcNow);

    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public bool IsRange => EndDate > StartDate;

    public DateTimeRange(DateTime date)
        : this(date, date)
    {
    }

    public DateTimeRange(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate <= endDate ? startDate : endDate;
        EndDate = endDate >= startDate ? endDate : startDate;
    }

    public int GetMonthRange()
    {
        return StartDate.GetMonthsSpan(EndDate);
    }
}
