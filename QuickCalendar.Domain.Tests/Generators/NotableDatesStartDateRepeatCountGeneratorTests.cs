using FluentAssertions;
using QuickCalendar.Domain.Generators;
using Xunit;

namespace QuickCalendar.Domain.Tests.Generators;

public class NotableDatesStartDateRepeatCountGeneratorTests
{
    [Fact]
    public void GeneratorTypeName_is_determined_correctly()
    {
        var instance = new NotableDatesStartDateRepeatCountGenerator();

        // Act
        var result = instance.GeneratorTypeName;

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("StartDateRepeatCount");
    }

    [Fact]
    public void Generate_should_return_the_expected_number_of_dates()
    {
        var now = DateTime.UtcNow.Date;
        var repeatCount = DateTime.UtcNow.Second + 1;

        var instance = new NotableDatesStartDateRepeatCountGenerator()
        {
            StartDate = now,
            RepeatCount = 10,
            Interval = TimeSpan.FromDays(14),
            DescriptionTemplate = "Day {sequence}, {yyyy-MMM-dd}"
        };

        // Act
        var result = instance.Generate();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(instance.RepeatCount);

        for (var i = 0; i < instance.RepeatCount; i++)
        {
            var date = now.AddDays(instance.Interval.TotalDays * i);
            var desc = $"Day {i + 1}, {date:yyyy-MMM-dd}";

            result.Skip(i).First().Date.Should().Be(date);
            result.Skip(i).First().Description.Should().Be(desc);
        }
    }
}
