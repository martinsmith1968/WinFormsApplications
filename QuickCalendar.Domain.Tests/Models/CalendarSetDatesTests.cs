using AutoFixture;
using Bogus;
using FluentAssertions;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Tests.Models;

internal class CalendarSetDatesTests
{
    private static readonly Fixture AutoFixture = new();
    private static readonly Faker Faker = new();
    private static readonly Random Randomizer = new();

    internal static CalendarSetDates CreateRandomInstance()
    {
        var now = DateTime.UtcNow;

        var result = new CalendarSetDates();

        result.DatesGenerators.Add(
            new NotableDatesFixedDateGenerator()
            {
                Date = new DateTime(now.Year, now.Month, Randomizer.Next(1, 28)),
                DescriptionTemplate = "Date: {o}",
            }
        );

        result.DatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                IntervalPeriod = IntervalPeriodTests.CreateRandomInstance(),
                StartDate = new DateTime(now.Year, 1, 1),
                EndDate = new DateTime(now.Year + 1, 1, 1),
                DescriptionTemplate = "Date: {o}",
            }
        );

        result.DatesGenerators.Add(
            new NotableDatesStartDateRepeatCountGenerator()
            {
                IntervalPeriod = IntervalPeriodTests.CreateRandomInstance(),
                StartDate = new DateTime(now.Year, 1, 1),
                RepeatCount = Randomizer.Next(1, 10),
                DescriptionTemplate = "Date: {o}",
            }
        );

        result.MonthlyDatesGenerators.Add(
            new NotableDatesFixedDateGenerator()
            {
                Date = new DateTime(now.Year, now.Month, Randomizer.Next(1, 28)),
                DescriptionTemplate = "Date: {o}",
            }
        );

        result.MonthlyDatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                IntervalPeriod = IntervalPeriodTests.CreateRandomInstance(),
                StartDate = new DateTime(now.Year, 1, 1),
                EndDate = new DateTime(now.Year + 1, 1, 1),
                DescriptionTemplate = "Date: {o}",
            }
        );

        result.MonthlyDatesGenerators.Add(
            new NotableDatesStartDateRepeatCountGenerator()
            {
                IntervalPeriod = IntervalPeriodTests.CreateRandomInstance(),
                StartDate = new DateTime(now.Year, 1, 1),
                RepeatCount = Randomizer.Next(1, 10),
                DescriptionTemplate = "Date: {o}",
            }
        );

        result.AnnualDatesGenerators.Add(
            new NotableDatesFixedDateGenerator()
            {
                Date = new DateTime(now.Year, now.Month, Randomizer.Next(1, 28)),
                DescriptionTemplate = "Date: {o}",
            }
        );

        result.AnnualDatesGenerators.Add(
            new NotableDatesStartDateEndDateGenerator()
            {
                IntervalPeriod = IntervalPeriodTests.CreateRandomInstance(),
                StartDate = new DateTime(now.Year, 1, 1),
                EndDate = new DateTime(now.Year + 1, 1, 1),
                DescriptionTemplate = "Date: {o}",
            }
        );

        result.AnnualDatesGenerators.Add(
            new NotableDatesStartDateRepeatCountGenerator()
            {
                IntervalPeriod = IntervalPeriodTests.CreateRandomInstance(),
                StartDate = new DateTime(now.Year, 1, 1),
                RepeatCount = Randomizer.Next(1, 10),
                DescriptionTemplate = "Date: {o}",
            }
        );

        result.AllDatesGenerators.Should().NotBeEmpty();
        result.AllDates.Should().NotBeEmpty();

        return result;
    }

    public static void AssertAreEqual(CalendarSetDates instance1, CalendarSetDates instance2)
    {
        instance1.Should().NotBeNull();
        instance2.Should().NotBeNull();

        instance1.DatesGenerators.Count.Should().Be(instance2.DatesGenerators.Count);
        instance1.DatesGenerators.Should().BeEquivalentTo(instance2.DatesGenerators);

        instance1.AnnualDatesGenerators.Count.Should().Be(instance2.AnnualDatesGenerators.Count);
        instance1.AnnualDatesGenerators.Should().BeEquivalentTo(instance2.AnnualDatesGenerators);

        instance1.MonthlyDatesGenerators.Count.Should().Be(instance2.MonthlyDatesGenerators.Count);
        instance1.MonthlyDatesGenerators.Should().BeEquivalentTo(instance2.MonthlyDatesGenerators);
    }
}
