using AutoFixture;
using FluentAssertions;
using QuickCalendar.Domain.Generators;
using Xunit;

namespace QuickCalendar.Domain.Tests.Generators;

public class NotableDatesFixedDateGeneratorTests
{
    private static readonly Fixture AutoFixture = new();

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

    [Theory]
    [MemberData(nameof(CopyFrom_Data))]
    public void CopyFrom_can_populate_properties_as_expected(NotableDatesFixedDateGenerator generator, string expected)
    {
        var instance = new NotableDatesFixedDateGenerator();
        instance.CopyFrom(generator);

        // Act
        var result = instance.GetDefinitionValue();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(CopyFrom_Data))]
    public void Clone_can_populate_properties_as_expected(NotableDatesFixedDateGenerator generator, string expected)
    {
        var instance = new NotableDatesFixedDateGenerator();
        instance.CopyFrom(generator);

        var other = instance.Clone();

        // Act
        var result = other.GetDefinitionValue();

        // Assert
        result.Should().Be(expected);
    }

    public static TheoryData<NotableDatesFixedDateGenerator, string> CopyFrom_Data()
    {
        var data = new TheoryData<NotableDatesFixedDateGenerator, string>();

        var instance1 = AutoFixture.Create<NotableDatesFixedDateGenerator>();
        data.Add(instance1, instance1.GetDefinitionValue());

        var instance2 = AutoFixture.Build<NotableDatesFixedDateGenerator>()
            .With(x => x.DescriptionTemplate, (string?)null)
            .Create();
        data.Add(instance2, instance2.GetDefinitionValue());

        return data;
    }
}
