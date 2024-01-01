using AutoFixture;
using Bogus;
using FluentAssertions;
using QuickCalendar.Domain.Models;
using Xunit;

namespace QuickCalendar.Domain.Tests.Models;

public class CalendarSetTests
{
    private static readonly Fixture AutoFixture = new();
    private static readonly Faker Faker = new();
    private static readonly Random Randomizer = new();

    internal static CalendarSet CreateRandomInstance()
    {
        var now = DateTime.UtcNow;

        var datesInstance = CalendarSetDatesTests.CreateRandomInstance();

        return AutoFixture.Build<CalendarSet>()
            .With(x => x.Name, Faker.Commerce.ProductName)
            .With(x => x.Description, Faker.Commerce.ProductDescription)
            .With(x => x.Version, Randomizer.Next(1, 10))
            .With(x => x.DateDisplayFormat, "o")
            .With(x => x.MinimumDate, now.Date.Subtract(TimeSpan.FromDays(14)))
            .With(x => x.MaximumDate, now.Date.Add(TimeSpan.FromDays(14)))
            .With(x => x.VisualDetails, CalendarSetVisualsTests.CreateRandomInstance())
            .Do(x => datesInstance.AnnualDatesGenerators.ToList().ForEach(i => x.Dates.AnnualDatesGenerators.Add(i)))
            .Do(x => datesInstance.MonthlyDatesGenerators.ToList().ForEach(i => x.Dates.MonthlyDatesGenerators.Add(i)))
            .Do(x => datesInstance.DatesGenerators.ToList().ForEach(i => x.Dates.DatesGenerators.Add(i)))
            .Create();
    }

    internal static void AssertAreEqual(CalendarSet instance1, CalendarSet instance2)
    {
        instance1.Should().NotBeNull();
        instance2.Should().NotBeNull();

        instance2.Version.Should().Be(instance1.Version);
        instance2.Name.Should().Be(instance1.Name);
        instance2.Description.Should().Be(instance1.Description);
        instance2.DisplayFontName.Should().Be(instance1.DisplayFontName);
        instance2.DisplayFontSize.Should().Be(instance1.DisplayFontSize);
        instance2.MinimumDate.Should().Be(instance1.MinimumDate);
        instance2.MaximumDate.Should().Be(instance1.MaximumDate);
        instance2.DateDisplayFormat.Should().Be(instance1.DateDisplayFormat);
    }

    [Fact]
    public void Constructor_populates_properties_correctly()
    {
        var name = AutoFixture.Create<string>();

        // Act
        var instance = new CalendarSet(name);

        // Assert
        instance.Should().NotBeNull();
        instance.Name.Should().Be(name);
        instance.Description.Should().BeNull();
        instance.MaximumDate.Should().Be(DateTime.MaxValue);
        instance.MinimumDate.Should().Be(DateTime.MinValue);
        instance.VisualDetails.Should().NotBeNull();
        instance.Dates.Should().NotBeNull();
    }

    [Fact]
    public void CopyFrom_can_copy_all_properties_correctly()
    {
        var source = CreateRandomInstance();

        // Act
        var target = new CalendarSet(CalendarSet.DefaultName);
        target.CopyFrom(source);

        // Assert
        AssertAreEqual(source, target);
        CalendarSetVisualsTests.AssertAreEqual(source.VisualDetails, target.VisualDetails);
        CalendarSetDatesTests.AssertAreEqual(source.Dates, target.Dates);
    }
}
