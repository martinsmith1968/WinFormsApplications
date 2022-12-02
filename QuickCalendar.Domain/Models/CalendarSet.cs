using System.Drawing;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Interfaces;

namespace QuickCalendar.Domain.Models;

public class CalendarSet : ICopyable<CalendarSet>
{
    private const string ModelVersion = "1";

    public const string DefaultName = "Default";
    public const string DefaultDescription = "A default Calendar";

    public CalendarSet(string name, string? description = null)
    {
        Name        = name;
        Description = description;
    }

    public string Version => ModelVersion;

    public string Name { get; set; }

    public string? Description { get; set; }

    public DateTime MinimumDate { get; set; } = DateTime.MinValue;

    public DateTime MaximumDate { get; set; } = DateTime.MaxValue;

    public string DateDisplayFormat { get; set; } = DateFormats.NamedDateFormats.First().Key;

    public CalendarSetVisuals VisualDetails { get; } = new();

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
