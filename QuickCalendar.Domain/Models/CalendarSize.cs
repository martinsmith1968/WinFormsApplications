namespace QuickCalendar.Domain.Models;

public class CalendarSize(int width, int height, string description)
{
    public int Width { get; } = width;

    public int Height { get; } = height;

    public string Description { get; } = description;

    public override string ToString() => Description;
}
