using System.Drawing;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Models.Types;

namespace QuickCalendar.Domain.Repositories;

public class CalendarSetBuilder
{
    public static CalendarSet BuildMyCustomCalendarSet()
    {
        var calendarSet = new CalendarSet("A Calendar of Sprint Dates")
        {
            VisualDetails =
            {
                FirstDayOfWeek = DayOfWeek.Monday,
                FirstVisibleMonth = 1,
                ShowToday = true,
                ShowTodayCircle = true,
                ShowWeekNumbers = true,
                ManualWindowLocation = new Point(400, 250),
                VisibleDimensions = new Size(4, 3)
            }
        };

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2022, 1, 12),
                EndDate = new DateTime(2022, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalPeriodType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy.MM.dd}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2023, 1, 11),
                EndDate = new DateTime(2023, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalPeriodType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2024, 1, 10),
                EndDate = new DateTime(2024, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalPeriodType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2025, 1, 8),
                EndDate = new DateTime(2025, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalPeriodType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2026, 1, 7),
                EndDate = new DateTime(2026, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalPeriodType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        calendarSet.Dates.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = new DateTime(2027, 1, 6),
                EndDate = new DateTime(2027, 12, 31),
                IntervalPeriod = IntervalPeriod.Create(IntervalPeriodType.Days, 14),
                DescriptionTemplate = "Sprint {yyyy}.{sequence:00}"
            }
        );

        return calendarSet;
    }
}
