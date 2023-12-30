using AutoFixture;
using FluentAssertions;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Models.Types;
using Xunit;

namespace QuickCalendar.Domain.Tests.Generators;

public class NotableDatesStartDateRepeatCountGeneratorTests
{
    private static readonly Fixture AutoFixture = new();

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
            IntervalPeriod = IntervalPeriod.Create(IntervalPeriodType.Days, 14),
            DescriptionTemplate = "Day {sequence}, {yyyy-MMM-dd}"
        };

        // Act
        var result = instance.Generate();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(instance.RepeatCount);

        for (var i = 0; i < instance.RepeatCount; i++)
        {
            var date = now.AddDays(instance.IntervalPeriod.Value * i);
            var desc = $"Day {i + 1}, {date:yyyy-MMM-dd}";

            result.Skip(i).First().Date.Should().Be(date);
            result.Skip(i).First().Description.Should().Be(desc);
        }
    }

    [Theory]
    [MemberData(nameof(CopyFrom_Data))]
    public void CopyFrom_can_populate_properties_as_expected(NotableDatesStartDateRepeatCountGenerator generator, string expected)
    {
        var instance = new NotableDatesStartDateRepeatCountGenerator();
        instance.CopyFrom(generator);

        var result = instance.GetDefinitionValue();

        result.Should().Be(expected);
    }

    public static TheoryData<NotableDatesStartDateRepeatCountGenerator, string> CopyFrom_Data()
    {
        var data = new TheoryData<NotableDatesStartDateRepeatCountGenerator, string>();

        var instance1 = AutoFixture.Create<NotableDatesStartDateRepeatCountGenerator>();
        data.Add(instance1, instance1.GetDefinitionValue());

        var instance2 = AutoFixture.Build<NotableDatesStartDateRepeatCountGenerator>()
            .With(x => x.DescriptionTemplate, (string?)null)
            .Create();
        data.Add(instance2, instance2.GetDefinitionValue());

        return data;
    }
}
