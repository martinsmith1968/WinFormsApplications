using System.Globalization;
using AutoFixture;
using DNX.Common.Interfaces;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using Shouldly;
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
        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);

        result.First().Date.ShouldBe(now);
        result.First().Description.ShouldNotBeNullOrWhiteSpace();
        result.First().Description.ShouldBe($"Today is {now:yyyyMMdd} - {instance.Sequence}");
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
        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);

        result.First().Date.ShouldBe(now);
        result.First().Description.ShouldNotBeNullOrWhiteSpace();
        result.First().Description.ShouldBe($"Sprint {now:yyyy}.{instance.Sequence:00}");
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
        result.ShouldNotBeNullOrWhiteSpace();
        result.ShouldContain($"\"{nameof(TestNotableDatesGenerator.DateToUse)}\":\"{instance.DateToUse:s}\"");
        result.ShouldContain($"\"{nameof(TestNotableDatesGenerator.Sequence)}\":{instance.Sequence}");
        result.ShouldContain($"\"{nameof(TestNotableDatesGenerator.Interval)}\":\"{instance.Interval:c}\"");
        result.ShouldContain($"\"{nameof(TestNotableDatesGenerator.DescriptionTemplate)}\":\"{instance.DescriptionTemplate}\"");
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
        result.DateToUse.ShouldBe(instance.DateToUse);
        result.Sequence.ShouldBe(instance.Sequence);
        result.Interval.ShouldBe(instance.Interval);
        result.DescriptionTemplate.ShouldBe(instance.DescriptionTemplate);
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
        result.ShouldBe(expected);
    }

    [Fact]
    public void GetDefinitionText_can_report_properties_successfully()
    {
        var instance = AutoFixture.Create<TestNotableDatesGenerator>();

        // Act
        var result = instance.GetDefinitionText();

        // Assert
        result.ShouldNotBeNullOrWhiteSpace();
        result.ShouldContain(nameof(TestNotableDatesGenerator.DateToUse));
        result.ShouldContain(instance.DateToUse.ToString(CultureInfo.CurrentCulture));
        result.ShouldContain(nameof(TestNotableDatesGenerator.Sequence));
        result.ShouldContain(instance.Sequence.ToString());
        result.ShouldContain(nameof(TestNotableDatesGenerator.DescriptionTemplate));
        result.ShouldContain(instance.DescriptionTemplate);
    }

    public static TheoryData<TestNotableDatesGenerator, string> CopyFrom_Data()
    {
        var data = new TheoryData<TestNotableDatesGenerator, string>();

        var instance1 = AutoFixture.Create<TestNotableDatesGenerator>();
        data.Add(instance1, instance1.GetDefinitionValue());

        var instance2 = AutoFixture.Build<TestNotableDatesGenerator>()
            .With(x => x.DescriptionTemplate, (string?)null)
            .Create();
        data.Add(instance2, instance2.GetDefinitionValue());

        return data;
    }
}
