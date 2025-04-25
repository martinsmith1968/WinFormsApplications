using AutoFixture;
using Bogus;
using DNX.Common.Extensions;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace QuickCalendar.Domain.Tests.Extensions;

internal class SimpleObject1
{
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public int AgeInYears => DateTime.UtcNow.Year - DateOfBirth.Year;
}

public class ObjectExtensionsTests
{
    private static readonly Fixture AutoFixture = new();
    private static readonly Faker Faker = new();
    private static readonly Random Randomizer = new();

    [Fact]
    public void PopulateFrom_with_null_dictionary_has_no_effect()
    {
        var instance = AutoFixture.Create<SimpleObject1>();
        Dictionary<string, object>? dictionary = null;

        // Act
        var instanceJson = JsonConvert.SerializeObject(instance);
        var result = instance.PopulateFromDictionary(dictionary);
        var resultJson = JsonConvert.SerializeObject(result);

        // Assert
        result.Should().NotBeNull();
        resultJson.Should().Be(instanceJson);
    }

    [Fact]
    public void PopulateFrom_with_empty_dictionary_has_no_effect()
    {
        var instance = AutoFixture.Create<SimpleObject1>();
        var dictionary = new Dictionary<string, object>();

        // Act
        var instanceJson = JsonConvert.SerializeObject(instance);
        var result = instance.PopulateFromDictionary(dictionary);
        var resultJson = JsonConvert.SerializeObject(result);

        // Assert
        result.Should().NotBeNull();
        resultJson.Should().Be(instanceJson);
    }

    [Fact]
    public void PopulateFrom_with_dictionary_of_values_applies_as_expected()
    {
        var name = Faker.Name.FullName();
        var dateOfBirth = new DateTime(Randomizer.Next(1900, 2000), Randomizer.Next(1, 12), Randomizer.Next(1, 28));

        var instance = AutoFixture.Create<SimpleObject1>();
        var dictionary = new Dictionary<string, object>()
        {
            [nameof(SimpleObject1.Name)] = name,
            [nameof(SimpleObject1.DateOfBirth)] = dateOfBirth,
        };

        // Act
        var instanceJson = JsonConvert.SerializeObject(instance);
        var result = instance.PopulateFromDictionary(dictionary);
        var resultJson = JsonConvert.SerializeObject(result);

        // Assert
        result.Should().NotBeNull();
        resultJson.Should().NotBe(instanceJson);
        result.Name.Should().Be(name);
        result.DateOfBirth.Should().Be(dateOfBirth);
    }

    [Fact]
    public void PopulateFrom_with_dictionary_of_readonly_values_has_no_effect()
    {
        var ageInYears = Randomizer.Next(50, 100);

        var instance = AutoFixture.Create<SimpleObject1>();
        var dictionary = new Dictionary<string, object>()
        {
            [nameof(SimpleObject1.AgeInYears)] = ageInYears,
        };

        // Act
        var instanceJson = JsonConvert.SerializeObject(instance);
        var result = instance.PopulateFromDictionary(dictionary);
        var resultJson = JsonConvert.SerializeObject(result);

        // Assert
        result.Should().NotBeNull();
        resultJson.Should().Be(instanceJson);
    }
}
