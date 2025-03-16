using QuickCalendar.Domain.Models;

namespace QuickCalendar.Models;

public static class AllowedCalendarSizes
{
    public static readonly IList<CalendarSize> Values = new List<CalendarSize>()
    {
        new(1, 1, "(1 x 1) Single Month"),
        new(1, 2, "(1 x 2) Custom"),
        new(1, 3, "(1 x 3) Quarter Portrait"),
        new(1, 4, "(1 x 4) Custom"),
        new(1, 5, "(1 x 5) Custom"),
        new(1, 6, "(1 x 6) Custom"),
        new(2, 1, "(2 x 1) Custom"),
        new(2, 2, "(2 x 2) Custom"),
        new(2, 3, "(2 x 3) Half-Year Portrait"),
        new(2, 4, "(2 x 4) Custom"),
        new(2, 5, "(2 x 5) Custom"),
        new(2, 6, "(2 x 6) Custom"),
        new(3, 1, "(3 x 1) Quarter Landscape"),
        new(3, 2, "(3 x 2) Half-Year Landscape"),
        new(3, 3, "(3 x 3) Custom"),
        new(3, 4, "(3 x 4) Year Portrait"),
        new(4, 1, "(4 x 1) Custom"),
        new(4, 2, "(4 x 2) Custom"),
        new(4, 3, "(4 x 3) Year Landscape"),
        new(5, 1, "(5 x 1) Custom"),
        new(5, 2, "(5 x 2) Custom"),
        new(6, 1, "(6 x 1) Custom"),
        new(6, 2, "(6 x 2) Custom"),
    };

    public static CalendarSize Default => Values.First();
}
