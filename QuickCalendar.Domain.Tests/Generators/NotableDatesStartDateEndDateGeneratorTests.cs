using FluentAssertions;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using Xunit;

namespace QuickCalendar.Domain.Tests.Generators;

public class NotableDatesStartDateEndDateGeneratorTests
{
    [Fact]
    public void GeneratorTypeName_is_determined_correctly()
    {
        var instance = new NotableDatesStartDateEndDateGenerator();

        // Act
        var result = instance.GeneratorTypeName;

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("StartDateEndDate");
    }

    [Fact]
    public void Generate_should_return_the_expected_number_of_dates()
    {
        var now = DateTime.UtcNow.Date;
        var expectedCount = (365 / 14) + 1;

        var instance = new NotableDatesStartDateEndDateGenerator()
        {
            StartDate = now,
            EndDate = now.AddDays(365),
            IntervalPeriod = IntervalPeriod.Create(IntervalType.Days, 14),
            DescriptionTemplate = "Day {sequence}, {yyyy-MMM-dd}"
        };

        // Act
        var result = instance.Generate();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(expectedCount);

        for (var i = 0; i < expectedCount; i++)
        {
            var date = now.AddDays(instance.IntervalPeriod.Value * i);
            var desc = $"Day {i + 1}, {date:yyyy-MMM-dd}";

            result.Skip(i).First().Date.Should().Be(date);
            result.Skip(i).First().Description.Should().Be(desc);
        }
    }
}
