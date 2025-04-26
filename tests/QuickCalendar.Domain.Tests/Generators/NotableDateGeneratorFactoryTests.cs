using AutoFixture;
using DNX.Helpers.Strings;
using Shouldly;
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
        instance.ShouldNotBeNull();
        instance.GetType().ShouldBe(expectedType);
    }

    [Fact]
    public void Create_fails_when_it_cant_find_the_name_of_a_known_generator()
    {
        var name = AutoFixture.Create<string>();

        var properties = new Dictionary<string, object>();

        var sut = new NotableDateGeneratorFactory();

        // Act
        var instance = sut.Create(name, properties);

        instance.ShouldBeNull();
    }

    public static TheoryData<string, Type> Create_Data()
    {
        var data = new TheoryData<string, Type>();

        NotableDateGeneratorFactory.FactoryCandidateTypes
            .ToList()
            .ForEach(t => data.Add(t.Name, t));

        NotableDateGeneratorFactory.FactoryCandidateTypes
            .ToList()
            .ForEach(t => data.Add(t.Name.RemoveStartsWith("NotableDates"), t));

        NotableDateGeneratorFactory.FactoryCandidateTypes
            .ToList()
            .ForEach(t => data.Add(t.Name.RemoveEndsWith("Generator"), t));

        NotableDateGeneratorFactory.FactoryCandidateTypes
            .ToList()
            .ForEach(t => data.Add(t.Name.RemoveStartsAndEndsWith("NotableDates", "Generator"), t));

        return data;
    }
}
