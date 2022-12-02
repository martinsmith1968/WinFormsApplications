using AutoFixture;
using DNX.Helpers.Strings;
using FluentAssertions;
using QuickCalendar.Domain.Generators;
using Xunit;

#pragma warning disable CS8602

namespace QuickCalendar.Domain.Tests.Generators;

public class NotableDateGeneratorFactoryTests
{
    private static readonly Fixture AutoFixture = new();

    [Theory]
    [MemberData(nameof(Create_Data))]
    public void Create_can_generate_an_instance_of_a_known_generator(string name, Type expectedType)
    {
        var sut = new NotableDateGeneratorFactory();

        var properties = new Dictionary<string, object>();

        // Act
        var instance = sut.Create(name, properties);

        // Assert
        instance.Should().NotBeNull();
        instance.GetType().Should().Be(expectedType);
    }

    [Fact]
    public void Create_fails_when_it_cant_find_the_name_of_a_known_generator()
    {
        var name = AutoFixture.Create<string>();

        var properties = new Dictionary<string, object>();

        var sut = new NotableDateGeneratorFactory();

        // Act
        var instance = sut.Create(name, properties);

        instance.Should().BeNull();
    }

    public static IEnumerable<object[]> Create_Data()
    {
        return NotableDateGeneratorFactory.FactoryCandidateTypes.Select(t => new object[] { t.Name, t })
            .Union(
                NotableDateGeneratorFactory.FactoryCandidateTypes.Select(t => new object[] { t.Name.RemoveStartsWith("NotableDates"), t })
            )
            .Union(
                NotableDateGeneratorFactory.FactoryCandidateTypes.Select(t => new object[] { t.Name.RemoveEndsWith("Generator"), t })
            )
            .Union(
                NotableDateGeneratorFactory.FactoryCandidateTypes.Select(t => new object[] { t.Name.RemoveStartsAndEndsWith("NotableDates", "Generator"), t })
            )
            .ToArray();
    }
}
