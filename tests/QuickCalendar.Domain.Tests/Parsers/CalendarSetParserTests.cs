using System.Drawing;
using AutoFixture;
using FluentAssertions;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Models.Types;
using QuickCalendar.Domain.Parsers;
using QuickCalendar.Domain.Repositories;
using QuickCalendar.Domain.Tests.Models;
using Xunit;
using Xunit.Abstractions;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace QuickCalendar.Domain.Tests.Parsers;

public class CalendarSetParserTests
{
    private static readonly Fixture AutoFixture = new();

    private readonly ITestOutputHelper _outputHelper;

    internal static CalendarSetDates BuildDatesInstance()
    {
        var calendarSetDates = AutoFixture.Create<CalendarSetDates>();

        calendarSetDates.DatesGenerators.Add(
            new NotableDatesFixedDateGenerator()
            {
                Date = DateTime.UtcNow.Date,
                DescriptionTemplate = "Today"
            }
        );

        calendarSetDates.MonthlyDatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.Date.AddYears(1),
                DescriptionTemplate = "Month: {MMM yyyy}"
            }
        );

        calendarSetDates.AnnualDatesGenerators.Add(
            new NotableDatesStartDateRepeatCountGenerator()
            {
                StartDate = DateTime.Parse("1968-08-11"),
                RepeatCount = 100,
                IntervalPeriod = IntervalPeriod.Create(IntervalPeriodType.Years, 1),
                DescriptionTemplate = "My {Sequence} Birthday"
            }
        );

        return calendarSetDates;
    }

    internal static CalendarSetVisuals BuildCalendarSetVisuals()
        => AutoFixture.Build<CalendarSetVisuals>()
            .With(x => x.VisibleDimensions, new Size(4, 3))
            .With(x => x.FirstDayOfWeek, DayOfWeek.Monday)
            .With(x => x.FirstVisibleMonth, 1)
            .With(x => x.ManualWindowLocation, new Point(100, 100))
            .Create();

    internal static CalendarSet BuildCalendarSetInstance(CalendarSetVisuals? visuals = null, CalendarSetDates? dates = null)
    {
        var now = DateTime.UtcNow;
        var calendarSet = new CalendarSet($"A test instance from {now:s}");

        calendarSet.VisualDetails.CopyFrom(visuals ?? BuildCalendarSetVisuals());
        calendarSet.Dates.CopyFrom(dates ?? BuildDatesInstance());

        return calendarSet;
    }

    public CalendarSetParserTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Parse_can_write_a_CalendarSet_successfully()
    {
        var instance = CalendarSetTests.CreateRandomInstance();

        // Act
        var result = CalendarSetParser.GenerateJson(instance);

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Parse_can_write_my_Custom_CalendarSet_successfully()
    {
        var instance = CalendarSetBuilder.BuildMyCustomCalendarSet();

        // Act
        var result = CalendarSetParser.GenerateJson(instance);
        _outputHelper.WriteLine($"{nameof(result)}: {result}");

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GenerateJson_generates_identical_CalendarSets_identically()
    {
        var instance1 = CalendarSetTests.CreateRandomInstance();
        var instance2 = CalendarSet.Default;
        instance2.CopyFrom(instance1);

        // Act
        var result1 = CalendarSetParser.GenerateJson(instance1);
        _outputHelper.WriteLine($"{nameof(result1)}: {result1}");
        var result2 = CalendarSetParser.GenerateJson(instance2);
        _outputHelper.WriteLine($"{nameof(result2)}: {result2}");

        // Assert
        result1.Should().NotBeNullOrWhiteSpace();
        result2.Should().NotBeNullOrWhiteSpace();
        result2.Should().Be(result1);
    }

    [Fact]
    public void GenerateJson_fails_to_generate_JSON_from_an_invalid_CalendarSet()
    {
        var instance1 = CalendarSetTests.CreateRandomInstance();
        instance1.VisualDetails.FirstDayOfWeek = (DayOfWeek)int.MaxValue;

        // Act
        var result1 = CalendarSetParser.GenerateJson(instance1);
        _outputHelper.WriteLine($"{nameof(result1)}: {result1}");

        // Assert
        result1.Should().BeNull();
    }

    [Fact]
    public void Parser_can_read_and_populate_a_CalendarSet_successfully()
    {
        var instance = CalendarSetTests.CreateRandomInstance();

        var definitionText = CalendarSetParser.GenerateJson(instance)
                             ?? string.Empty;

        // Act
        var result = CalendarSetParser.ParseFromJson(definitionText);

        // Assert
        result.Should().NotBeNull();
        CalendarSetTests.AssertAreEqual(result!, instance);

        result.VisualDetails.Should().NotBeNull();
        CalendarSetVisualsTests.AssertAreEqual(instance.VisualDetails, result.VisualDetails);

        result.Dates.Should().NotBeNull();
        CalendarSetDatesTests.AssertAreEqual(instance.Dates, result.Dates);
    }

    [Fact]
    public void Parser_fails_to_read_a_CalendarSet_from_invalid_json()
    {
        var definitionText = Guid.NewGuid().ToString();

        // Act
        var result = CalendarSetParser.ParseFromJson(definitionText);

        // Assert
        result.Should().BeNull();
    }
}
