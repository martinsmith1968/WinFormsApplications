using AutoFixture;
using Shouldly;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Models.Types;
using Xunit;

namespace QuickCalendar.Domain.Tests.Generators;

public class NotableDatesStartDateEndDateGeneratorTests
{
    private static readonly Fixture AutoFixture = new();
    private static readonly Random Randomizer = new();

    [Fact]
    public void GeneratorTypeName_is_determined_correctly()
    {
        var instance = new NotableDatesStartDateEndDateGenerator();

        // Act
        var result = instance.GeneratorTypeName;

        // Assert
        result.ShouldNotBeNullOrWhiteSpace();
        result.ShouldBe("StartDateEndDate");
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
            IntervalPeriod = IntervalPeriod.Create(IntervalPeriodType.Days, 14),
            DescriptionTemplate = "Day {sequence}, {yyyy-MMM-dd}",
            SequenceStart = Randomizer.Next(1, 10),
            SequenceIncrement = Randomizer.Next(1, 5)
        };

        // Act
        var result = instance.Generate();

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedCount);

        var expectedSequence = instance.SequenceStart;
        for (var i = 0; i < expectedCount; i++)
        {
            var date = now.AddDays(instance.IntervalPeriod.Value * i);
            var desc = $"Day {expectedSequence}, {date:yyyy-MMM-dd}";

            result.Skip(i).First().Date.ShouldBe(date);
            result.Skip(i).First().Description.ShouldBe(desc);

            expectedSequence += instance.SequenceIncrement;
        }
    }

    [Theory]
    [MemberData(nameof(CopyFrom_Data))]
    public void CopyFrom_can_populate_properties_as_expected(NotableDatesStartDateEndDateGenerator generator, string expected)
    {
        var instance = new NotableDatesStartDateEndDateGenerator();
        instance.CopyFrom(generator);

        // Act
        var result = instance.GetDefinitionValue();

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [MemberData(nameof(CopyFrom_Data))]
    public void Clone_can_populate_properties_as_expected(NotableDatesStartDateEndDateGenerator generator, string expected)
    {
        var instance = new NotableDatesStartDateEndDateGenerator();
        instance.CopyFrom(generator);

        var other = instance.Clone();

        // Act
        var result = other.GetDefinitionValue();

        // Assert
        result.ShouldBe(expected);
    }

    public static TheoryData<NotableDatesStartDateEndDateGenerator, string> CopyFrom_Data()
    {
        var data = new TheoryData<NotableDatesStartDateEndDateGenerator, string>();

        var instance1 = AutoFixture.Create<NotableDatesStartDateEndDateGenerator>();
        data.Add(instance1, instance1.GetDefinitionValue());

        var instance2 = AutoFixture.Build<NotableDatesStartDateEndDateGenerator>()
            .With(x => x.DescriptionTemplate, (string?)null)
            .Create();
        data.Add(instance2, instance2.GetDefinitionValue());

        return data;
    }
}
