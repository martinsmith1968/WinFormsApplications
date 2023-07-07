using System.Drawing;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Interfaces;

namespace QuickCalendar.Domain.Models;

public class CalendarSet : ICopyable<CalendarSet>
{
    private const int CurrentModelVersion = 1;

    public const string DefaultName = "Default";
    public const string DefaultDescription = "A default Calendar";

    public const string DefaultFontName = "Segoe UI";
    public const int DefaultFontSize = 9;

    public CalendarSet(string name, string? description = null)
    {
        Name            = name;
        Description     = description;
        DisplayFontName = DefaultFontName;
        DisplayFontSize = DefaultFontSize;
    }

    public int Version => CurrentModelVersion;

    public string Name { get; set; }

    public string? Description { get; set; }

    public string DisplayFontName { get; set; }

    public float DisplayFontSize { get; set; }

    public DateTime MinimumDate { get; set; } = DateTime.MinValue;

    public DateTime MaximumDate { get; set; } = DateTime.MaxValue;

    public string DateDisplayFormat { get; set; } = DateFormats.NamedDateFormats.First().Key;

    public CalendarSetVisuals VisualDetails { get; set; } = new();

    public CalendarSetDates Dates { get; } = new();

    public static CalendarSet Default => new(DefaultName, DefaultDescription);

    public static CalendarSet BuildMyCustomCalendarSet()
    {
        var calendarSet = new CalendarSet(CalendarSet.DefaultName, CalendarSet.DefaultDescription)
        {
            VisualDetails =
            {
                FirstDayOfWeek = DayOfWeek.Monday,
                FirstVisibleMonth = 1,
                ShowToday = true,
                ShowTodayCircle = true,
                ShowWeekNumbers = true,
                CloseOnEscape = true,
                ManualWindowLocation = new Point(400, 250),
                VisibleDimensions = new Size(4, 3)
            }
        };

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2022, 1, 12),
                EndDate = new DateTime(2022, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy.MM.dd}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2023, 1, 11),
                EndDate = new DateTime(2023, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2024, 1, 10),
                EndDate = new DateTime(2024, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2025, 1, 8),
                EndDate = new DateTime(2025, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2026, 1, 7),
                EndDate = new DateTime(2026, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2027, 1, 6),
                EndDate = new DateTime(2027, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        return calendarSet;
    }

    public void CopyFrom(CalendarSet other)
    {
        Name = other.Name;
        Description = other.Description;
        MinimumDate = other.MinimumDate;
        MaximumDate = other.MaximumDate;
        DateDisplayFormat = other.DateDisplayFormat;
        VisualDetails.CopyFrom(other.VisualDetails);
        Dates.CopyFrom(other.Dates);
    }
}
