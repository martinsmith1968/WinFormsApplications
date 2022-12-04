using System.Drawing;
using AutoFixture;
using FluentAssertions;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Parsers;
using Xunit;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace QuickCalendar.Domain.Tests.Parsers;

public class CalendarSetParserTests
{
    private static readonly Fixture AutoFixture = new();

    private static CalendarSetDates BuildDatesInstance()
        => AutoFixture.Build<CalendarSetDates>()
            .With(x => x.DatesGenerators,
                new INotableDatesGenerator[]
                {
                    new NotableDatesFixedDateGenerator()
                    {
                        Date = DateTime.UtcNow.Date,
                        DescriptionTemplate = "Today"
                    }
                }.ToList())
            .With(x => x.MonthlyDatesGenerators,
                new INotableDatesGenerator[]
                {
                    new NotableDatesStartDateEndDateGenerator()
                    {
                        StartDate = DateTime.UtcNow.Date,
                        EndDate = DateTime.UtcNow.Date.AddYears(1),
                        DescriptionTemplate = "Month: {MMM yyyy}"
                    }
                }.ToList())
            .With(x => x.AnnualDatesGenerators,
                new INotableDatesGenerator[]
                {
                    new NotableDatesStartDateRepeatCountGenerator()
                    {
                        StartDate = DateTime.Parse("1968-08-11"),
                        RepeatCount = 100,
                        IntervalPeriod = IntervalPeriod.Create(IntervalType.Years, 1),
                        DescriptionTemplate = "My {Sequence} Birthday"
                    }
                }.ToList())
            .Create();

    private static CalendarSetVisuals BuildCalendarSetVisuals()
        => AutoFixture.Build<CalendarSetVisuals>()
            .With(x => x.VisibleDimensions, new Size(4, 3))
            .With(x => x.FirstDayOfWeek, DayOfWeek.Monday)
            .With(x => x.FirstVisibleMonth, 1)
            .With(x => x.ManualWindowLocation, new Point(100, 100))
            .Create();

    private static CalendarSet BuildCalendarSetInstance(CalendarSetVisuals? visuals = null, CalendarSetDates? dates = null)
        => AutoFixture.Build<CalendarSet>()
            .With(x => x.VisualDetails, visuals ?? BuildCalendarSetVisuals())
            .With(x => x.Dates, dates ?? BuildDatesInstance())
            .Create();

    [Fact]
    public void Parse_can_write_a_CalendarSet_successfully()
    {
        var x1 = BuildCalendarSetVisuals();
        var x2 = new CalendarSetDates()
        {
            DatesGenerators =
            {
                new NotableDatesFixedDateGenerator()
                {
                    Date = DateTime.UtcNow.Date,
                    DescriptionTemplate = "Today"
                }
            }
        };
        var instance = BuildCalendarSetInstance(x1, x2);

        // Act
        var result = CalendarSetParser.GenerateJson(instance);

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Parser_can_read_and_populate_a_CalendarSet_successfully()
    {
        var instance = BuildCalendarSetInstance();

        var definitionText = CalendarSetParser.GenerateJson(instance)
            ?? string.Empty;

        // Act
        var result = CalendarSetParser.ParseFromJson(definitionText);

        // Asert
        result.Should().NotBeNull();
        result.Name.Should().Be(instance.Name);
        result.Version.Should().Be(instance.Version);
        result.Description.Should().Be(instance.Description);
        result.DateDisplayFormat.Should().Be(instance.DateDisplayFormat);
        result.MinimumDate.Should().Be(instance.MinimumDate);
        result.MaximumDate.Should().Be(instance.MaximumDate);

        result.VisualDetails.Should().NotBeNull();
        result.VisualDetails.Should().BeEquivalentTo(instance.VisualDetails);

        result.Dates.Should().NotBeNull();
        result.Dates.Should().BeEquivalentTo(instance.Dates);
    }
}
