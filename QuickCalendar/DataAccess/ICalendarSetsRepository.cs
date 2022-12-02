using QuickCalendar.Domain.Models;

namespace QuickCalendar.DataAccess;

public interface ICalendarSetsRepository
{
    CalendarSet? LoadNamedCalendarSet(string name);

    void SaveNamedCalendarSet(CalendarSet calendarSet);
}
