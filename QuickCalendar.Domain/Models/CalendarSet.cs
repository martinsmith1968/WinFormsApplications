using QuickCalendar.Domain.Interfaces;

namespace QuickCalendar.Domain.Models;

public class CalendarSet :
    ICopyable<CalendarSet>,
    ICloneable<CalendarSet>
{
    private const int CurrentModelVersion = 1;

    public const string DefaultName = "Default";
    public const string DefaultDescription = "A default Calendar";

    public const string DefaultFontName = "Segoe UI";
    public const float DefaultFontSize = 9;

    public CalendarSet()
        : this(DefaultName)
    {
    }

    public CalendarSet(string name)
        : this(name, null)
    {
    }

    public CalendarSet(string name, string? description = null)
    {
        Name            = name;
        Description     = description;
        DisplayFontName = DefaultFontName;
        DisplayFontSize = DefaultFontSize;
    }

    public int Version { get; set; } = CurrentModelVersion;

    public string Name { get; set; }

    public string? Description { get; set; }

    public string DisplayFontName { get; set; }

    public float DisplayFontSize { get; set; }

    public DateTime MinimumDate { get; set; } = DateTime.MinValue;

    public DateTime MaximumDate { get; set; } = DateTime.MaxValue;

    public string DateDisplayFormat { get; set; } = DateFormats.NamedDateFormats.First().Key;

    public CalendarSetVisuals VisualDetails { get; set; } = new();

    public CalendarSetDates Dates { get; set; } = new();

    public static CalendarSet Default => new(DefaultName, DefaultDescription);

    public void CopyFrom(CalendarSet other)
    {
        Version           = other.Version;
        Name              = other.Name;
        DisplayFontName   = other.DisplayFontName;
        DisplayFontSize   = other.DisplayFontSize;
        Description       = other.Description;
        MinimumDate       = other.MinimumDate;
        MaximumDate       = other.MaximumDate;
        DateDisplayFormat = other.DateDisplayFormat;

        VisualDetails.CopyFrom(other.VisualDetails);
        Dates.CopyFrom(other.Dates);
    }

    public CalendarSet Clone()
    {
        var other = new CalendarSet();
        other.CopyFrom(this);
        return other;
    }

    public DateTime? FindPreviousMarkedDate(DateTime startDate)
    {
        var candidate = Dates.Dates
            .Where(x => x.Date < startDate)
            .OrderByDescending(x => x.Date)
            .FirstOrDefault();

        return candidate?.Date;
    }

    public DateTime? FindNextMarkedDate(DateTime startDate)
    {
        var candidate = Dates.Dates
            .Where(x => x.Date > startDate)
            .OrderBy(x => x.Date)
            .FirstOrDefault();

        return candidate?.Date;
    }
}
