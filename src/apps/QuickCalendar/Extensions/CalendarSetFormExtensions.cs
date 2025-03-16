using QuickCalendar.Domain.Models;

namespace QuickCalendar.Extensions;

public static class CalendarSetFormExtensions
{
    public static Font GetFont(this CalendarSet calendarSet)
    {
        try
        {
            return new Font(calendarSet.DisplayFontName, calendarSet.DisplayFontSize);
        }
        catch
        {
            return new Font(CalendarSet.DefaultFontName, CalendarSet.DefaultFontSize);
        }
    }
}
