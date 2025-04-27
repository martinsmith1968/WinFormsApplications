using AutoFixture;
using Bogus;
using Shouldly;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using Xunit;

namespace QuickCalendar.Domain.Tests.Models;

public class CalendarSetDatesTests
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

        result.AllDatesGenerators.ShouldNotBeEmpty();
        result.AllDates.ShouldNotBeEmpty();

        return result;
    }

    internal static void AssertAreEqual(CalendarSetDates instance1, CalendarSetDates instance2)
    {
        instance1.ShouldNotBeNull();
        instance2.ShouldNotBeNull();

        instance1.DatesGenerators.Count.ShouldBe(instance2.DatesGenerators.Count);
        instance1.DatesGenerators.ShouldBeEquivalentTo(instance2.DatesGenerators);

        instance1.AnnualDatesGenerators.Count.ShouldBe(instance2.AnnualDatesGenerators.Count);
        instance1.AnnualDatesGenerators.ShouldBeEquivalentTo(instance2.AnnualDatesGenerators);

        instance1.MonthlyDatesGenerators.Count.ShouldBe(instance2.MonthlyDatesGenerators.Count);
        instance1.MonthlyDatesGenerators.ShouldBeEquivalentTo(instance2.MonthlyDatesGenerators);
    }

    [Fact]
    public void CopyFrom_can_copy_all_properties_correctly()
    {
        var source = CreateRandomInstance();

        // Act
        var target = new CalendarSetDates();
        target.CopyFrom(source);

        // Assert
        AssertAreEqual(source, target);
    }

    [Fact]
    public void Clone_can_copy_all_properties_correctly()
    {
        var source = CreateRandomInstance();

        // Act
        var target = source.Clone();

        // Assert
        AssertAreEqual(source, target);
    }
}
