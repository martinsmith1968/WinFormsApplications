using System.Drawing;
using DNX.Common.Interfaces;

namespace QuickCalendar.Domain.Models;

public class CalendarSet :
    ICopyable<CalendarSet>,
    ICloneable<CalendarSet>
{
    private const int CurrentModelVersion = 1;

    public const string MissingFileName = "Untitled";

    public const string DefaultDescription = "A default Calendar";

    public const string DefaultFontName = "Segoe UI";
    public const float DefaultFontSize = 9;

    public CalendarSet()
        : this(null, null)
    {
    }

    public CalendarSet(string description)
        : this(null, description)
    {
    }


    public CalendarSet(FileInfo? fileInfo, string? description = null)
    {
        FileInfo        = fileInfo;
        Description     = description;
        DisplayFontName = DefaultFontName;
        DisplayFontSize = DefaultFontSize;
    }

    public int Version { get; set; } = CurrentModelVersion;

    public FileInfo? FileInfo { get; private set; }

    public string FileName => Path.GetFileName(FullFileName);

    public string FullFileName => FileInfo?.FullName ?? MissingFileName;

    public string? Description { get; set; }

    public string DisplayFontName { get; set; }

    public float DisplayFontSize { get; set; }

    public DateTime MinimumDate { get; set; } = DateTime.MinValue;

    public DateTime MaximumDate { get; set; } = DateTime.MaxValue;

    public string DateDisplayFormat { get; set; } = DateFormats.NamedDateFormats.First().Key;

    public CalendarSetVisuals VisualDetails { get; set; } = new();

    public CalendarSetDates Dates { get; set; } = new();

    public static CalendarSet Default => new(null, DefaultDescription);

    public void SetFileInfo(FileInfo fileInfo) => FileInfo = fileInfo;

    public void SetFileName(string fileName) => FileInfo = new FileInfo(fileName);

    public void CopyFrom(CalendarSet other)
    {
        Version           = other.Version;
        FileInfo          = other.FileInfo;
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
