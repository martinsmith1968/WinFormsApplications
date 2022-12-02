using FluentAssertions;
using QuickCalendar.Domain.Generators;
using Xunit;

namespace QuickCalendar.Domain.Tests.Generators;

public class NotableDatesFixedDateGeneratorTests
{
    [Fact]
    public void GeneratorTypeName_is_determined_correctly()
    {
        var instance = new NotableDatesFixedDateGenerator();

        // Act
        var result = instance.GeneratorTypeName;

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("FixedDate");
    }

    [Fact]
    public void Generate_should_return_the_expected_number_of_dates()
    {
        var now = DateTime.UtcNow.Date;

        var instance = new NotableDatesFixedDateGenerator()
        {
            Date = now,
            DescriptionTemplate = "Day {sequence}, {yyyy-MMM-dd}"
        };

        // Act
        var result = instance.Generate();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(1);
        result.First().Date.Should().Be(now);
        result.First().Description.Should().Be($"Day 1, {now:yyyy-MMM-dd}");
    }
}
