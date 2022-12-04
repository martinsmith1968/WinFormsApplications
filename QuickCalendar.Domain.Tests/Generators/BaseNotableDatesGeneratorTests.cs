using System.Globalization;
using AutoFixture;
using FluentAssertions;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Interfaces;
using QuickCalendar.Domain.Models;
using Xunit;

namespace QuickCalendar.Domain.Tests.Generators;

public class TestNotableDatesGenerator : BaseNotableDatesGenerator, ICopyable<TestNotableDatesGenerator>
{
    public DateTime DateToUse { get; set; }

    public int Sequence { get; set; }

    public TimeSpan Interval { get; set; }

    public override IList<NotableDate> Generate()
    {
        return new List<NotableDate>()
        {
            new(DateToUse, InterpolateTemplate(DescriptionTemplate, DateToUse, Sequence))
        };
    }

    public void CopyFrom(TestNotableDatesGenerator other)
    {
        base.CopyFrom(other);
        DateToUse = other.DateToUse;
        Sequence = other.Sequence;
        Interval = other.Interval;
    }
}

public class BaseNotableDatesGeneratorTests
{
    private static readonly Fixture AutoFixture = new();

    [Fact]
    public void Generate_should_create_descriptions_using_appropriate_values()
    {
        var now = DateTime.UtcNow;

        var instance = new TestNotableDatesGenerator()
        {
            DateToUse = now,
            DescriptionTemplate = "Today is {yyyyMMdd} - {sequence}",
            Sequence = now.Second + 1,
            Interval = TimeSpan.FromSeconds(DateTime.UtcNow.Millisecond)
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
            Sequence = now.Second + 1,
            Interval = TimeSpan.FromSeconds(DateTime.UtcNow.Millisecond)
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
            Sequence = now.Second + 1,
            Interval = TimeSpan.FromSeconds(DateTime.UtcNow.Millisecond)
        };

        // Act
        var result = instance.GetDefinitionValue();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain($"\"{nameof(TestNotableDatesGenerator.DateToUse)}\":\"{instance.DateToUse:s}\"");
        result.Should().Contain($"\"{nameof(TestNotableDatesGenerator.Sequence)}\":{instance.Sequence}");
        result.Should().Contain($"\"{nameof(TestNotableDatesGenerator.Interval)}\":\"{instance.Interval:c}\"");
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
            Sequence = now.Second + 1,
            Interval = TimeSpan.FromSeconds(DateTime.UtcNow.Millisecond)
        };

        var text = instance.GetDefinitionValue();

        // Act
        var result = new TestNotableDatesGenerator();
        result.PopulateFromDefinitionValue(text);

        // Assert
        result.DateToUse.Should().Be(instance.DateToUse);
        result.Sequence.Should().Be(instance.Sequence);
        result.Interval.Should().Be(instance.Interval);
        result.DescriptionTemplate.Should().Be(instance.DescriptionTemplate);
    }

    [Theory]
    [MemberData(nameof(CopyFrom_Data))]
    public void CopyFrom_can_populate_properties_as_expected(TestNotableDatesGenerator generator, string expected)
    {
        var instance = new TestNotableDatesGenerator();
        instance.CopyFrom(generator);

        // Act
        var result = instance.GetDefinitionValue();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void GetDefinitionText_can_report_properties_successfully()
    {
        var instance = AutoFixture.Create<TestNotableDatesGenerator>();

        // Act
        var result = instance.GetDefinitionText();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain(nameof(TestNotableDatesGenerator.DateToUse));
        result.Should().Contain(instance.DateToUse.ToString(CultureInfo.CurrentCulture));
        result.Should().Contain(nameof(TestNotableDatesGenerator.Sequence));
        result.Should().Contain(instance.Sequence.ToString());
        result.Should().Contain(nameof(TestNotableDatesGenerator.DescriptionTemplate));
        result.Should().Contain(instance.DescriptionTemplate);
    }

    public static IEnumerable<object[]> CopyFrom_Data()
    {
        var instance1 = AutoFixture.Create<TestNotableDatesGenerator>();
        yield return new object[] { instance1, instance1.GetDefinitionValue() };

        var instance2 = AutoFixture.Build<TestNotableDatesGenerator>()
            .With(x => x.DescriptionTemplate, (string?)null)
            .Create();
        yield return new object[] { instance2, instance2.GetDefinitionValue() };
    }
}
