namespace QuickCalendar.Domain.Models;

public class CalendarSize
{
    public static readonly IList<CalendarSize> AllowedCalendarSizes = new List<CalendarSize>()
    {
        new(1, 1, "(1 x 1) Single Month"),
        new(1, 2, "(1 x 2) Custom"),
        new(1, 3, "(1 x 3) Custom"),
        new(1, 4, "(1 x 4) Custom"),
        new(1, 5, "(1 x 5) Custom"),
        new(1, 6, "(1 x 6) Custom"),
        new(2, 1, "(2 x 1) Custom"),
        new(2, 2, "(2 x 2) Custom"),
        new(2, 3, "(2 x 3) Custom"),
        new(2, 4, "(2 x 4) Custom"),
        new(2, 5, "(2 x 5) Custom"),
        new(2, 6, "(2 x 6) Custom"),
        new(3, 1, "(3 x 1) Custom"),
        new(3, 2, "(3 x 2) Custom"),
        new(3, 3, "(3 x 3) Custom"),
        new(3, 4, "(3 x 4) Portrait"),
        new(4, 1, "(4 x 1) Custom"),
        new(4, 2, "(4 x 2) Custom"),
        new(4, 3, "(4 x 3) Landscape"),
        new(5, 1, "(5 x 1) Custom"),
        new(5, 2, "(5 x 2) Custom"),
        new(6, 1, "(6 x 1) Custom"),
        new(6, 2, "(6 x 2) Custom"),
    };

    public static CalendarSize Default => AllowedCalendarSizes.First();

    public int Width { get; }

    public int Height { get; }

    public string Text { get; }

    public CalendarSize(int width, int height, string text)
    {
        Width = width;
        Height = height;
        Text = text;
    }

    public override string ToString() => Text;
}
