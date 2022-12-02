using FluentAssertions;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using Xunit;

namespace QuickCalendar.Domain.Tests.Generators;

internal class TestNotableDatesGenerator : BaseNotableDatesGenerator
{
    public DateTime DateToUse { get; set; }

    public int Sequence { get; set; }

    public override IList<NotableDate> Generate()
    {
        return new List<NotableDate>()
        {
            new(DateToUse, InterpolateTemplate(DescriptionTemplate, DateToUse, Sequence))
        };
    }
}

public class BaseNotableDatesGeneratorTests
{
    [Fact]
    public void Generate_should_create_descriptions_using_appropriate_values()
    {
        var now = DateTime.UtcNow;

        var instance = new TestNotableDatesGenerator()
        {
            DateToUse = now,
            DescriptionTemplate = "Today is {yyyyMMdd} - {sequence}",
            Sequence = now.Second + 1
        };

        // Act
        var result = instance.Generate();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(1);

        result.First().Date.Should().Be(now);
        result.First().Description.Should().NotBeNullOrWhiteSpace();
        result.First().Description.Should().Be($"Today is {now:yyyyMMdd} - {instance.Sequence}");
    }

    [Fact]
    public void Generate_should_create_descriptions_using_appropriate_values_with_formatting()
    {
        var now = DateTime.UtcNow;

        var instance = new TestNotableDatesGenerator()
        {
            DateToUse = now,
            DescriptionTemplate = "Sprint {yyyy}.{sequence:00}",
            Sequence = now.Second + 1
        };

        // Act
        var result = instance.Generate();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(1);

        result.First().Date.Should().Be(now);
        result.First().Description.Should().NotBeNullOrWhiteSpace();
        result.First().Description.Should().Be($"Sprint {now:yyyy}.{instance.Sequence:00}");
    }

    [Fact]
    public void GetPropertyValuesText_should_generate_appropriate_values_text()
    {
        var now = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second);

        var instance = new TestNotableDatesGenerator()
        {
            DateToUse = now,
            DescriptionTemplate = "Sprint {yyyy}.{sequence:00}",
            Sequence = now.Second + 1
        };

        // Act
        var result = instance.GetDefinitionValue();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain($"\"{nameof(TestNotableDatesGenerator.DateToUse)}\":\"{instance.DateToUse:s}\"");
        result.Should().Contain($"\"{nameof(TestNotableDatesGenerator.Sequence)}\":{instance.Sequence}");
        result.Should().Contain($"\"{nameof(TestNotableDatesGenerator.DescriptionTemplate)}\":\"{instance.DescriptionTemplate}\"");
    }

    [Fact]
    public void PopulateFrom_can_populate_properties_successfully()
    {
        var now = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second);

        var instance = new TestNotableDatesGenerator()
        {
            DateToUse = now,
            DescriptionTemplate = "Sprint {yyyy}.{sequence:00}",
            Sequence = now.Second + 1
        };

        var text = instance.GetDefinitionValue();

        // Act
        var result = new TestNotableDatesGenerator();
        result.PopulateFromDefinitionValue(text);

        // Assert
        result.DateToUse.Should().Be(instance.DateToUse);
        result.Sequence.Should().Be(instance.Sequence);
        result.DescriptionTemplate.Should().Be(instance.DescriptionTemplate);
    }
}
